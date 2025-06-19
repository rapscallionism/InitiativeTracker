using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InitiativeTrackerBackend.Models.DTOs
{
    public class Equipment
    {
        [BsonId] // MongoDB requires this for the _id field
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Tags Tags { get; set; }
        public required string OnAction { get; set; }
        public required string OnBonusAction { get; set; }
        public required string OnReaction { get; set; }
        public required string[] Effects { get; set; }
        public required ResetsOn ResetsOn { get; set; }
    }
}
