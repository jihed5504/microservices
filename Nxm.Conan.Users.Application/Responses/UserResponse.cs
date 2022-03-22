namespace Nxm.Conan.Users.Application.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public string Language { get; set; }

        public DateTime? BirthdayDate { get; set; }

        public string Civility { get; set; }

        public string Profession { get; set; }

        public string Studylevel { get; set; }

        public string Situation { get; set; }

        public Guid CompanyId { get; set; }

        public string Address { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsVerified { get; set; }
    }
}
