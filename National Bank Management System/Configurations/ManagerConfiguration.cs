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
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.FullName)
                   .IsRequired();

            builder.Property(m => m.Email)
                   .IsRequired();

            builder.Property(m => m.PhoneNumber)
                   .IsRequired();

            builder.Property(m => m.HireDate)
                   .IsRequired();

            builder.Property(m => m.BranchCode)
                   .IsRequired();

            builder.HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@bank.com",
                    PhoneNumber = "01000000001",
                    HireDate = new DateTime(2024, 1, 1),
                    BranchCode = 1
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@bank.com",
                    PhoneNumber = "01000000002",
                    HireDate = new DateTime(2024, 2, 1),
                    BranchCode = 2
                }
            );
        }
    }
}
