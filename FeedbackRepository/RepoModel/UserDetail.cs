using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackRepository.RepoModel
{
    [Table("UserDetails")]
    public class UserDetail
    {
        [Key]
        [Column(TypeName ="int")]
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ?  Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ? Mobile { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "int")]
        public int RoleID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PasswordChangeDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "bit")]
        public bool? IsActive { get; set; }

    }
}
