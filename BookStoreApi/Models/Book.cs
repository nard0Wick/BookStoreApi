﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;
        public decimal Price {  get; set; }
        [BsonElement("Category")]
        public string Cathegory { get; set; } = null!;
        public string Author { get; set; } = null!;

    }
}
