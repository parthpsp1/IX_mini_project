using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.DataAccess;
using MiniProjectBackendAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.Service
{
    public interface IUserService
    {
        IEnumerable<Users> Users(string id);
        //UsersModel Users(string id);
        Task<Users> Users(Users users);
        Users Users(Users users, string id);
        Users Remove(string id);
    }

    public class UserService : IUserService
    {
        private readonly IUserDA _userDA;

        public UserService(IUserDA userDA)
        {
            _userDA = userDA;
        }
        public IEnumerable<Users> Users(string id)
        {
            var get_all_users = _userDA.Users(id);
            List<Users> user_list = new();
            foreach (var element in get_all_users)
            {
                user_list.Add(new Users
                {
                    Id = element.Id,
                    Username = element.UserName,
                    FirstName = element.FirstName,
                    LastName = element.LastName,
                    Email = element.Email,
                    PhoneNumber = element.PhoneNumber,
                    AlternatePhoneNumber = element.AlternatePhoneNumber,
                    TenthPercentage = element.TenthPercentage,
                    TwelthPercentage = element.TwelthPercentage,
                    DiplomaPercentage = element.DiplomaPercentage,
                    BachlorsPercentage = element.BachlorsPercentage,
                    MastersPercentage = element.MastersPercentage,
                    DoctoratePhDPercentage = element.DoctoratePhDPercentage,
                    Certification = element.Certification,
                });
            }
            return user_list;
        }
        public Users Remove(string id)
        {
            var remove_user = _userDA.Users(id);
            if (remove_user == null)
            {
                return null;
            }
            else
            {
                return new Users
                {
                };
            }
        }

        public async Task<Users> Users(Users users)
        {
            var new_user = new AuthenticateUser
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                PhoneNumber = users.PhoneNumber,
                AlternatePhoneNumber = users.AlternatePhoneNumber,
                TenthPercentage = users.TenthPercentage,
                TwelthPercentage = users.TwelthPercentage,
                DiplomaPercentage = users.DiplomaPercentage,
                BachlorsPercentage = users.BachlorsPercentage,
                MastersPercentage = users.MastersPercentage,
                DoctoratePhDPercentage = users.DoctoratePhDPercentage,
                Certification = users.Certification
            };

            var add_new_user = await _userDA.Users(new_user);
            return new Users
            {
                FirstName = add_new_user.FirstName
            };
        }

        //public UsersModel Users(string id)
        //{
        //    var get_user_by_id = _userDA.Users(id);
        //    if (get_user_by_id == null)
        //        return null;
        //    else
        //    {
        //        return new UsersModel
        //        {
        //        };
        //    }
        //}

        public Users Users(Users users, string id)
        {
            var update_user = new AuthenticateUser
            {
                UserName = users.Username,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                PhoneNumber = users.PhoneNumber,
                AlternatePhoneNumber = users.AlternatePhoneNumber,
                TenthPercentage = users.TenthPercentage,
                TwelthPercentage = users.TwelthPercentage,
                DiplomaPercentage = users.DiplomaPercentage,
                BachlorsPercentage = users.BachlorsPercentage,
                MastersPercentage = users.MastersPercentage,
                DoctoratePhDPercentage = users.DoctoratePhDPercentage,
                Certification = users.Certification
            };
            var updated_user = _userDA.Users(update_user, id);
            return new Users
            {
                FirstName = updated_user.FirstName
            };
        }
    }
}
