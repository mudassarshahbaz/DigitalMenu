using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMenu.Models
{
    public class MenuItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string FkCatId { get; set; }

        public string Availibity { get; set; }

        public int Quantity { get; set; }

        public string EstimatedCookingTime { get; set; }

        public string Timestamp { get; set; }

        public string CreatedBy { get; set; }

        public string Status { get; set; }
    }
}
