using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Data
{
    public class MemeMapper : EntityTypeConfiguration<Meme>
    {
        public MemeMapper()
       {
        this.ToTable("Meme");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.Title).IsRequired();
            this.Property(c => c.Title).HasMaxLength(255);

            this.Property(c => c.ImageUrl).IsRequired(); 
            this.Property(c => c.Title).HasMaxLength(255);

            this.Property(c => c.Description).IsOptional();
            this.Property(c => c.Description).HasMaxLength(1000);
         
       }
    }
}
