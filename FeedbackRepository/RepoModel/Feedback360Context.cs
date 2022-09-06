using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackRepository.RepoModel
{
    public class Feedback360Context : DbContext
    {
        public DbSet<UserDetail> UsersInfo { get; set; }
        public DbSet<RoleDetail> RoleInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NSGROUP-NSPLAP0\\SQLEXPRESS;Database=Feedback360DB;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
