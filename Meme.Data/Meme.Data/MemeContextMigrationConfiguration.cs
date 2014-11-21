using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Data
{
    public class MemeContextMigrationConfiguration : DbMigrationsConfiguration<MemeContext>
    {

        public MemeContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

#if DEBUG
        protected override void Seed(MemeContext context)
        {
            new MemeDataSeeder(context).Seed();
        }
#endif
    }
}
