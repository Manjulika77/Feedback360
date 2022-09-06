using FeedbackBusiness.BLAbstract;
using FeedbackRepository.RepoAbstract;
using FeedbackRepository.RepoModel;
using FeedbackUtility.UtilityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackBusiness.BLFeedback
{
    public class BLUserManagement : IBLUserManagement
    {
        IUserManagementRepository _objRepo = null;
        public BLUserManagement(IUserManagementRepository objRepo)
        {
            _objRepo = objRepo;
        }
        public UserInfoViewModel AuthenticateUser(LoginViewModel loginInfo)
        {
            UserInfoViewModel usr = _objRepo.AuthenticateUser(loginInfo);

            return usr;
        }

        public List<RoleInfoViewModel> GetAllAvailableRole()
        {
            List<RoleInfoViewModel> roles = _objRepo.GetAllAvailableRole();
            
            return roles;
        }

        public string RegisterUser(UserDetail user)
        {
            string msg = string.Empty;
            msg = _objRepo.RegisterUser(user);
            return msg;
        }

        public string UpdateUserPassByUserName(string oldPass, string newPass, string userName)
        {
            string msg = string.Empty;
            msg = _objRepo.UpdateUserPassByUserName(oldPass, newPass, userName);
            return msg;
        }

    }
}
