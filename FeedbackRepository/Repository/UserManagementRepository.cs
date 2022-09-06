using FeedbackRepository.RepoAbstract;
using FeedbackRepository.RepoModel;
using FeedbackUtility.UtilityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackRepository.Repository
{
  
    public class UserManagementRepository : IUserManagementRepository
    {
        Feedback360Context _context = new Feedback360Context();

        public UserInfoViewModel AuthenticateUser(LoginViewModel loginInfo)
        {


            UserDetail usrData = _context.UsersInfo.FirstOrDefault(uu => uu.UserName == loginInfo.UserName && uu.Password == loginInfo.Password);
            UserInfoViewModel usr = new UserInfoViewModel();
            if (usrData != null)
            {
                RoleDetail role = _context.RoleInfo.FirstOrDefault(e => e.RoleID == usrData.RoleID);

                if(role != null)
                {
                    usr.ID = usrData.ID;
                    usr.UserName = usrData.UserName;
                    usr.Name = string.IsNullOrEmpty(usr.Name) ? "Default User" : usrData.Name;
                    usr.Email = usrData.Email;
                    usr.Mobile = usrData.Mobile;
                    usr.Role = role.RoleName;
                    usr.PasswordChangeDate = usrData.PasswordChangeDate;
                }
                
            }

            return usr;
        }
        public List<RoleInfoViewModel> GetAllAvailableRole()
        {
            List<RoleInfoViewModel> roles= new List<RoleInfoViewModel>();                        
            try
            {
                List<RoleDetail> tmpRoles = _context.RoleInfo.ToList();

                foreach(RoleDetail tmpRole in tmpRoles)
                {
                    RoleInfoViewModel ObjRole = new RoleInfoViewModel();
                    ObjRole.RoleID = tmpRole.RoleID;
                    ObjRole.RoleName = tmpRole.RoleName;
                    roles.Add(ObjRole);
                }
            }
            catch(Exception ex)
            {

            }
            return roles;
        }
        public string RegisterUser(UserDetail user)
        {
            string msg = string.Empty;
            try
            {
                _context.UsersInfo.Add(user);
                _context.SaveChanges();

                if(user.ID > 0)
                {
                    msg = "User Registered successfully";
                }
                else
                {
                    msg = "User Registration Failed! Try again later.";
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public string UpdateUserPassByUserName(string oldPass, string newPass, string userName)
        {
            string msg = string.Empty;
            UserDetail objUser = null;
            try
            {
                objUser = _context.UsersInfo.FirstOrDefault(uu => uu.UserName == userName && uu.Password == oldPass);
                if(objUser == null)
                {
                    msg = "Something went wrong! Please try later";
                }
                else
                {
                    objUser.UserName = userName;
                    objUser.Password = newPass;
                    objUser.PasswordChangeDate = DateTime.Now;
                    objUser.ModifiedDate = DateTime.Now;
                    objUser.ModifiedBy = userName;
                    _context.SaveChanges();

                    msg = "Password Updated Successfully!";
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
