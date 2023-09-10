using Microsoft.EntityFrameworkCore;

namespace APIForBlazorApp.Models.DBContexts
{
    public class PatientsContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<ProgressNote> ProgressNotes { get; set; }

        public PatientsContext(DbContextOptions<PatientsContext> options) : base(options)
        {

        }
    }
}