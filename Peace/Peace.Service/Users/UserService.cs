using Peace.Core;
using Peace.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Data;
using Peace.Model;

namespace Peace.Services.Users
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _useRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly ICacheManager _cacheManager;

        public UserService(IRepository<User> useRepository, IRepository<UserRole> userRoleRepository, ICacheManager cacheManager)
        {
            _useRepository = useRepository;
            _userRoleRepository = userRoleRepository;
            _cacheManager = cacheManager;
        }

        public void DeleteUser(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (user.IsSystemAccount) throw new PeaceException(string.Format("系统用户{0}不能删除", user.SystemName));

            user.Deleted = true;
            if (!String.IsNullOrEmpty(user.Email))
                user.Email += "-DELETED";
            if (!String.IsNullOrEmpty(user.Username))
                user.Username += "-DELETED";

            UpdateUser(user);
        }

        public User GetUserById(int userId)
        {
            if (userId == 0)
                return null;

            return _useRepository.GetById(userId);
        }

        public void InsertUser(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            _useRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            _useRepository.Update(user);

        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            var query = from c in _useRepository.Table
                        orderby c.id
                        where c.Email == email
                        select c;

            var user = query.FirstOrDefault();
            return user;
        }

        public IList<User> GetUsersByIds(int[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
                return new List<User>();

            var quey = _useRepository.Table.Where(n => userIds.Contains(n.id));
            var users = quey.ToList();
            return userIds.Select(id => users.Find(x => x.id == id)).Where(user => user != null).ToList();
        }

        public User GetUserByGuid(Guid userGuid)
        {
            return userGuid == Guid.Empty ? null :
                _useRepository.Table.FirstOrDefault(n => n.UserGuid == userGuid);
        }

        public User GetUserBySystemName(string systemName)
        {
            return string.IsNullOrWhiteSpace(systemName) ? null : _useRepository.Table.FirstOrDefault(n => n.SystemName == systemName);
        }

        public User GetUserByUsername(string username)
        {
            return string.IsNullOrWhiteSpace(username) ? null : _useRepository.Table.FirstOrDefault(n => n.Username == username);
        }


        public virtual User InsertGuestUser()
        {
            var customer = new User
            {
                UserGuid = Guid.NewGuid(),
                Active = true,
                LastActivityDateUtc = DateTime.UtcNow,
            };


            //add to 'Guests' role
            //var guestRole = GetUserRoleBySystemName(SystemUserRoleNames.Guests);
            //if (guestRole == null)
            //    throw new PortalException("'Guests' role could not be loaded");
            //customer.UserRoles.Add(guestRole);

            // _useRepository.Insert(customer);
  

            return customer;
        }
    }
}
