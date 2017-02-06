using Peace.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Model;
using Peace.Data;

namespace Peace.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void DeleteUser(User user);
        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>User.</returns>
        User GetUserById(int userId);
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void InsertUser(User user);
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUser(User user);
        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>User.</returns>
        User GetUserByEmail(string email);
        /// <summary>
        /// Get Users by identifiers
        /// </summary>
        /// <param name="userIds">User identifiers</param>
        /// <returns>Users</returns>
        IList<User> GetUsersByIds(int[] userIds);

        /// <summary>
        /// Gets a User by GUID
        /// </summary>
        /// <param name="userGuid">User GUID</param>
        /// <returns>A User</returns>
        User GetUserByGuid(Guid userGuid);

        /// <summary>
        /// Get User by system role
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>User</returns>
        User GetUserBySystemName(string systemName);

        /// <summary>
        /// Get User by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// 插入Guest用户
        /// </summary>
        /// <returns></returns>
        User InsertGuestUser();
    }
}
