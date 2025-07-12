using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Asp_MongoDB.Entites
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid id { get; set; }

        [BsonElement("FirstName")]
        public string Name { get; set; }
        public string BigName => Name.ToUpper();
        public float Mark { get; set; }
        public int Age { get; set; }

    }
}
