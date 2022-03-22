namespace Nxm.Conan.Users.Infrastructure.Data.DbConfigs
{
    public interface IDatabaseConfigurations
    {
        string CommentCollectionName { get; set; }
        string InterviewCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string OffersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string EntrepriseCollectionName { get; set; }
        string CvCollectionName { get; set; }
        string CommentsCollectionName { get; set; }
    }
}
