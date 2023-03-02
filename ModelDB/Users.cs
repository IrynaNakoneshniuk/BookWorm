

namespace BookWorm.ModelDB
{
    public class Users
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public Users(string? email, string? password, string? name, string? surname)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
        }
    }
}
