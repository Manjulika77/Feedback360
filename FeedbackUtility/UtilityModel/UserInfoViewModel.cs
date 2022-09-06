using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackUtility.UtilityModel
{
    public class UserInfoViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? PasswordChangeDate { get; set; }

    }
}
