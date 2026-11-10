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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);

            builder.Property(a => a.AccountNumber)
                   .IsRequired();

            builder.Property(a => a.CurrentBalance)
                   .HasPrecision(18, 2);

            builder.Property(a => a.AccountType)
                   .IsRequired();

            builder.Property(a => a.OpeningDate)
                   .IsRequired();

            builder.Property(a => a.BranchCode)
                   .IsRequired();
        }
    }
}
