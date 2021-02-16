﻿using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp.Shared.Models
{
   
    public class CustomerDbModel
    {
        [BsonId]
     
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Id { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
    }
}
