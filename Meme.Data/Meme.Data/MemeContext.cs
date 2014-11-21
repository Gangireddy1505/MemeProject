using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Data
{
    public class MemeContext : DbContext
    {
        public MemeContext()
            : base("MemeConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MemeContext, MemeContextMigrationConfiguration>());
        }

         public DbSet<Meme> Memes { get; set; }


         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Configurations.Add(new MemeMapper());
            
             base.OnModelCreating(modelBuilder);
         }
    }
}
