using Microsoft.AspNetCore.Identity;
using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IUserDA
    {
        IEnumerable<AuthenticateUser> Users(string id);
        //AuthenticateUser Users(string id);
        Task<AuthenticateUser> Users(AuthenticateUser users);
        AuthenticateUser Users(AuthenticateUser authenticateUsers, string id);
        AuthenticateUser Remove(string id);
    }

    public class UserDA : IUserDA
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<AuthenticateUser> _userManager;

        public UserDA(ApplicationDbContext context, UserManager<AuthenticateUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IEnumerable<AuthenticateUser> Users(string id)
        {
            var all_users = _userManager.Users.Where(a => a.Id == id);
            return all_users.ToList();
        }
        //public AuthenticateUser Users(string id)
        //{
        //    return _context.Users.FirstOrDefault(element => element.Id == id);
        //}

        public async Task<AuthenticateUser> Users(AuthenticateUser users)
        {
            var add_user = await _context.Users.AddAsync(users);
            _context.SaveChanges();
            return add_user.Entity;
        }
        public AuthenticateUser Users(AuthenticateUser authenticateUser, string id)
        {
            var update_user = _context.Users.Where(element => element.Id == id).ToList();
            foreach (var element in update_user)
            {
                if (element.Id == id)
                {
                    element.FirstName = authenticateUser.FirstName;
                    element.LastName = authenticateUser.LastName;
                    element.PhoneNumber = authenticateUser.PhoneNumber;
                    element.AlternatePhoneNumber = authenticateUser.AlternatePhoneNumber;
                    element.TenthPercentage = authenticateUser.TenthPercentage;
                    element.TwelthPercentage = authenticateUser.TwelthPercentage;
                    element.DiplomaPercentage = authenticateUser.DiplomaPercentage;
                    element.BachlorsPercentage = authenticateUser.BachlorsPercentage;
                    element.MastersPercentage = authenticateUser.MastersPercentage;
                    element.DoctoratePhDPercentage = authenticateUser.DoctoratePhDPercentage;

                    var updated_user = _context.Users.Update(element);
                    _context.SaveChanges();
                    return updated_user.Entity;
                }
            }
            return authenticateUser;
        }

        public AuthenticateUser Remove(string id)
        {
            var remove_user = _context.Users.Where(element => element.Id == id).FirstOrDefault();
            if (remove_user.Id == id)
            {
                _context.Users.Remove(remove_user);
                _context.SaveChanges();
                return remove_user;
            }
            return remove_user;
        }
    }
}
