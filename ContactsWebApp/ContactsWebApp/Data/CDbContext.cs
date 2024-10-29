using ContactsWebApp.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Data
{
    public class CDbContext : DbContext
    {
        public CDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ContactM> TbContacts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
