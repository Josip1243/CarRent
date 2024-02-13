namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstName, string Lastname, string email, string password);
        AuthenticationResult Login(string username, string password);
    }
}
