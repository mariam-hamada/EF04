using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank_Management_System.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Bank_Management_System.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Name)
                   .IsRequired();

            builder.Property(b => b.Address)
                   .IsRequired();

            builder.Property(b => b.PhoneNumber)
                   .IsRequired();
            
            builder.HasOne(b => b.Manager)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Manager>(m => m.BranchCode);

            builder.HasMany(b => b.Accounts)
                   .WithOne(a => a.Branch)
                   .HasForeignKey(a => a.BranchCode);

            builder.HasData(
                new Branch
                {
                    Code = 1,
                    Name = "Helwan Branch",
                    Address = "Helwan, Cairo",
                    PhoneNumber = "0225551111"
                },
                new Branch
                {
                    Code = 2,
                    Name = "Nasr City Branch",
                    Address = "Nasr City, Cairo",
                    PhoneNumber = "0225552222"
                }
            );

        }
    }
}
