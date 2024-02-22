using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public User(
            UserId id,
            string firstName,
            string lastName,
            string email,
            string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password
                );
        }
    }
}
