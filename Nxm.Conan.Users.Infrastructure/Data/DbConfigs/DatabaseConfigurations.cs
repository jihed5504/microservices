namespace Nxm.Conan.Users.Infrastructure.Data.DbConfigs
{
    public class DatabaseConfigurations : IDatabaseConfigurations
    {
        public string CommentCollectionName { get; set; }
        public string InterviewCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string OffersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string EntrepriseCollectionName { get; set; }
        public string CvCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }

    }
}
