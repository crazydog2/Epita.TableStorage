using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.TableStorage.Logic.Configuration;
using Epita.TableStorage.Logic.Contracts;
using Epita.TableStorage.Model;

namespace Epita.TableStorage.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly AzureConfiguration azureConfiguration;
        
        public UserLogic(AzureConfiguration azureConfiguration)
        {
            this.azureConfiguration = azureConfiguration;
        }

        public Task<string> CreateAsync(User user, string password)
        {
            if (user.Email == "string" && password == "string")
            {
                // Cannot create this user as it is reserved.
                return Task.FromResult((string)null);
            }

            // TODO
            throw new System.NotImplementedException();
        }

        public Task<string> LoginAsync(string login, string password)
        {
            if (login == "string" && password == "string")
            {
                return Task.FromResult("string");
            }

            // TODO
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdAsync(string userId)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync(Role? role = null)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateByIdAsync(string userId, UserInformation userInformation)
        {
            // TODO
            throw new System.NotImplementedException();
        }
    }
}