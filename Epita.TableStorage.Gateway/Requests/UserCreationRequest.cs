using Epita.TableStorage.Model;

namespace Epita.TableStorage.Gateway.Requests
{
    public class UserCreationRequest
    {
        public User User { get; set; }

        public string Password { get; set; }
    }
}