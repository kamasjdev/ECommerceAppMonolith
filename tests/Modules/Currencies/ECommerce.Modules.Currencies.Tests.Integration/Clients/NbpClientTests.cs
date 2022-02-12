﻿using ECommerce.Modules.Currencies.Core.Clients;
using ECommerce.Shared.Tests;
using Flurl.Http;
using Humanizer;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;
using Shouldly;
using Microsoft.Extensions.Options;

namespace ECommerce.Modules.Currencies.Tests.Integration.Clients
{
    [Collection("integrationNBP")]
    public class NbpClientTests : IClassFixture<TestApplicationFactory<Program>>
    {
        [Fact]
        public async Task given_valid_code_should_return_rate()
        {
            var code = "eur";
            var content = Common.Extensions.GetSampleCurrencyRateJsonString();
            _wireMockServer.Given(
              Request.Create()
                .WithPath($"/api/exchangerates/rates/a/{code}")
                .UsingGet()).RespondWith(
              Response.Create()
                .WithBody(content)
                .WithStatusCode(200));

            var exchangeRate = await _service.GetCurrencyAsync(code);

            exchangeRate.ShouldNotBeNull();
            exchangeRate.Rates.ShouldNotBeNull();
            exchangeRate.Rates.Count.ShouldBeGreaterThan(0);
            var rate = exchangeRate.Rates.FirstOrDefault();
            rate.ShouldNotBeNull();
            rate.EffectiveDate.ShouldBeGreaterThan(new DateOnly());
            rate.No.ShouldNotBeNull();
            rate.No.ShouldNotBeEmpty();
            rate.Mid.ShouldBeGreaterThan(decimal.Zero);
        }

        [Fact]
        public async Task given_valid_code_and_date_should_return_rate()
        {
            var code = "chf";
            var date = DateOnly.FromDateTime(DateTime.Now);
            var content = Common.Extensions.GetSampleCurrencyRateJsonString(date, code);
            var url = $"/api/exchangerates/rates/a/{code}/{date.ToString("yyyy-MM-dd")}";
            _wireMockServer.Given(
              Request.Create()
                .WithPath(url)
                .UsingGet()).RespondWith(
              Response.Create()
                .WithBody(content)
                .WithStatusCode(200));

            var exchangeRate = await _service.GetCurrencyRateOnDateAsync(code, date);

            exchangeRate.ShouldNotBeNull();
            exchangeRate.Rates.ShouldNotBeNull();
            exchangeRate.Rates.Count.ShouldBeGreaterThan(0);
            var rate = exchangeRate.Rates.FirstOrDefault();
            rate.ShouldNotBeNull();
            rate.EffectiveDate.ShouldBeGreaterThan(new DateOnly());
            rate.No.ShouldNotBeNull();
            rate.No.ShouldNotBeEmpty();
            rate.Mid.ShouldBeGreaterThan(decimal.Zero);
        }

        [Fact]
        public async Task given_proper_code_should_fail_when_server_not_respond_after_2_seconds()
        {
            var code = "eur";
            _wireMockServer.Given(
              Request.Create()
                .WithPath($"/api/exchangerates/rates/a/{code}")
                .UsingGet()).RespondWith(
              Response.Create()
                .WithStatusCode(200)
                // Zwracam odpowiedź po 5 sekundach
                .WithDelay(5.Seconds()));

            // Oczekuję, że zostanie rzucony wyjątek, związany z połączeniem HTTP
            // Gdyż według konfiguracji połączenie HTTP powinno być nawiązane w
            // ciągu 2 sekund.
            var exception = await Record.ExceptionAsync(() => _service.GetCurrencyAsync(code));
            exception.ShouldBeOfType<FlurlHttpException>();
        }

        [Fact]
        public async Task given_valid_code_should_should_return_null_when_not_found_rate()
        {
            var code = "eur";
            _wireMockServer.Given(
              Request.Create()
                .WithPath($"/api/exchangerates/rates/a/{code}")
                .UsingGet()).RespondWith(
              Response.Create()
                .WithStatusCode(404));

            var rate = await _service.GetCurrencyAsync(code);

            rate.ShouldBeNull();
        }

        /// <summary>
        /// Do tworzenia zaślepek używam biblioteki WireMock
        /// </summary>
        private readonly WireMockServer _wireMockServer;
        private readonly INbpClient _service;

        public NbpClientTests(TestApplicationFactory<Program> factory)
        {
            _wireMockServer = WireMockServer.Start();
            // nadpisuje config nbpClientOptions
            var options = factory.Services.GetRequiredService<IOptions<NbpClientOptions>>();
            options.Value.BaseUrl = _wireMockServer.Urls.Single();
            options.Value.Timeout = 2;
            _service = factory.Services.GetRequiredService<INbpClient>();
        }
    }
}
