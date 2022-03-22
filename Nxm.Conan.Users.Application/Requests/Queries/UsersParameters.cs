namespace Nxm.Conan.Users.Application.Requests.Queries
{
    public class UsersParameters : QueryStringParameters
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
