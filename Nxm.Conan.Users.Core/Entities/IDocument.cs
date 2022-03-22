using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nxm.Conan.Users.Core.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        string Id { get; set; }

        DateTime? CreatedAt { get; }
        DateTime? UpdatedAt { get; set; }
    }
}
