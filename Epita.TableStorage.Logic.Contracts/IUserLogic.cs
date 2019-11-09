using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.TableStorage.Model;

namespace Epita.TableStorage.Logic.Contracts
{
    public interface IUserLogic
    {
        /// <summary>
        /// Allow to create a user and return the userId of the created user
        /// </summary>
        /// <param name="user">The User to create</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The UserId</returns>
        Task<string> CreateAsync(User user, string password);

        /// <summary>
        /// Return the id of the User
        /// </summary>
        /// <param name="login">the email of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>The UserId</returns>
        Task<string> LoginAsync(string login, string password);

        /// <summary>
        /// Retrieve All the users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAsync(Role? role = null);

        /// <summary>
        /// Get a User by its id
        /// </summary>
        /// <param name="userId">The id of the User</param>
        /// <returns>The User</returns>
        Task<User> GetByIdAsync(string userId);

        /// <summary>
        /// Update a user by its id
        /// </summary>
        /// <param name="userId">The id of the User</param>
        /// <param name="userInformation">The User Information we want to update</param>
        /// <returns></returns>
        Task<bool> UpdateByIdAsync(string userId, UserInformation userInformation);
    }
}