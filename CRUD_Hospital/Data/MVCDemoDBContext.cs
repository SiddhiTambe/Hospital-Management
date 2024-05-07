using CRUD_Hospital.Models;
using Microsoft.EntityFrameworkCore;



namespace CRUD_Hospital.Data
{
    public class MVCDemoDBContext : DbContext
    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
    }
}
