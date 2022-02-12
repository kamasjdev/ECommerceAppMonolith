﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Contacts.Core.DTO
{
    internal class AddressDto
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string CountryName { get; set; }
        public string ZipCode { get; set; }
        public Guid CustomerId { get; set; }
    }
}
