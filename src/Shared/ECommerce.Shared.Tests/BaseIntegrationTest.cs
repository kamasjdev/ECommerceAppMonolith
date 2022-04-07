﻿using Flurl.Http;

namespace ECommerce.Shared.Tests
{
    public class BaseIntegrationTest
    {
        protected void Authenticate(Guid userId, IFlurlClient client)
        {
            var claims = new Dictionary<string, IEnumerable<string>>();
            claims.Add("permissions", new[] { "items", "item-sale" });
            var jwt = AuthHelper.GenerateJwt(userId.ToString(), "admin", claims: claims);
            client.WithOAuthBearerToken(jwt);
        }
    }
}
