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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .IsRequired();

            builder.Property(c => c.Address)
                   .IsRequired();

            builder.Property(c => c.DateOfBirth)
                   .IsRequired();

            builder.Property(c => c.NationalId)
                   .IsRequired();

            builder.Property(c => c.CustomerType)
                   .IsRequired();
        }
    }
}
