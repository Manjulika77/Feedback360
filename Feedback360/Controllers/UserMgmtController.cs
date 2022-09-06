using FeedbackBusiness.BLAbstract;
using FeedbackRepository.RepoModel;
using FeedbackUtility.UtilityFunctionality;
using FeedbackUtility.UtilityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Feedback360.Controllers
{
    public class UserMgmtController : Controller
    {
        IBLUserManagement _objBL = null;
        public UserMgmtController(IBLUserManagement objBL)
        {
            _objBL = objBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginInfo)
        {
            UserInfoViewModel usrInfo = _objBL.AuthenticateUser(loginInfo);

            if(usrInfo.UserName != null)
            {
                HttpContext.Session.SetString("CurrUName", usrInfo.UserName);

                // Provide authorization and redirect to Change password if PasswordChangeDate is NULL. 
                // If not null and role is "HR" then redirect to RegisterUser action method

                string[] userRoles = new string[] { usrInfo.Role };

                var claims = new List<Claim>();
                claims.Add(new Claim("username", usrInfo.UserName));   
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usrInfo.UserName));    
                foreach (var eachRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, eachRole));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                if (usrInfo.PasswordChangeDate == null)
                {
                    return RedirectToAction("ChangePassword");
                }
                else
                {
                    return RedirectToAction("FeedbackHome");
                }                    
              
            }
            else
            {
                ViewBag.Msg = "Invalid user ID or password";
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult FeedbackHome()
        {
            return View();
        }

        public IActionResult Instruction()
        {

            return View();
        }

        [Authorize(Roles ="HR, Admin")]
        public IActionResult RegisterUser()
        {
            List<RoleInfoViewModel> roles = _objBL.GetAllAvailableRole();
            ViewBag.AllRoles = roles;
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(UserDetail usr)
        {
            List<RoleInfoViewModel> roles = _objBL.GetAllAvailableRole();
            ViewBag.AllRoles = roles;
            usr.CreatedDate = DateTime.Now;            
            usr.CreatedBy = HttpContext.Session.GetString("CurrUName");
            usr.IsActive = !string.IsNullOrEmpty(usr.UserName);

            try
            {
                Random rand = new Random();
                int pass = rand.Next(10000, 99999);
                usr.Password = $"Feedback{pass.ToString()}";

                string msg = _objBL.RegisterUser(usr);
                ViewBag.msg = msg;

                // For SAVING DATA
                // Here supply usr to Business and then Repo to save new user data  (Refer CRUD operation and complete the data save)

                // SENDING EMAIL
                //string msgBody = "<html><body><B>Dear User,</B><br>Welcome to ABC Ltd. Please use below info to login to the portal.</br>" +
                //    "1. User ID :"+ usr.UserName +"</br>"+
                //    "2. OTP :" + usr.Password + "</br>" +
                //    "3. URL : http://www.abcdefgh.com/LoginPage</br>" +
                //    "</body></html>";
                //string sub = "Confirmation of user registration";
                //string to = usr.Email;
                //string from = "abcd1234@gmail.com";         // It should be a GMAIL address strictly to avail Google free service should be equal to your NETWORK-CREDENTIAL used for EMAIL CODING

                //UtilityActions.SendEmail(to, from, msgBody, sub);

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                ViewBag.msg = err;
            }


            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            string currentUserName = HttpContext.Session.GetString("CurrUName");

            ViewBag.UserName = currentUserName;

            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPwd, string newPwd)
        {
            string currentUserName = HttpContext.Session.GetString("CurrUName");

            // Supply all 3 info like oldPwd, newPwd, currUserName to Business and then to Repo to UPDATE userDetail as per user name and old pwd
            string msg = _objBL.UpdateUserPassByUserName(oldPwd,newPwd,currentUserName);
            ViewBag.msg = msg;

            return View();
        }
    }
}
