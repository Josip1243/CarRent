using Application.Common.Persistence;
using Domain.User;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private static int _idCounter = 0;

        public void Add(User user)
        {
            _idCounter++;
            user.Id = _idCounter;
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
