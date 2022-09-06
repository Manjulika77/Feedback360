using FeedbackRepository.RepoModel;
using FeedbackUtility.UtilityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackBusiness.BLAbstract
{
    public interface IBLUserManagement
    {
        UserInfoViewModel AuthenticateUser(LoginViewModel loginInfo);
        List<RoleInfoViewModel> GetAllAvailableRole();
        string RegisterUser(UserDetail user);
        string UpdateUserPassByUserName(string oldPass, string newPass, string userName);
    }
}
