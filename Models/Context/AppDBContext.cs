using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;

namespace Models.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<Role> Role{ get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Data Source=DESKTOP-OJDER5D\\SQLEXPRESS;Initial Catalog=EvaluacionTecnicaDB;user=sa;password=1234;Integrated Security=False");
        //}
    }
}
