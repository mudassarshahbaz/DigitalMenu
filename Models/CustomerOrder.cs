using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMenu.Models
{
    public class CustomerOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public string MenuId { get; set; }

        public string OrdersStatus { get; set; }

        public DateTime Timestamp { get; set; }

        public string CreatedBy { get; set; }
    }
}
