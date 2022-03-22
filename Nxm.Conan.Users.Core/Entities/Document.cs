namespace Nxm.Conan.Users.Core.Entities
{
    public abstract class Document : IDocument
    {
        public string Id { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
