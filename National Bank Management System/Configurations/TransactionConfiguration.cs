
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank_Management_System.Entites;

namespace National_Bank_Management_System.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionNumber);

            builder.Property(t => t.TransactionDate)
                   .IsRequired();

            builder.Property(t => t.Amount)
                   .HasPrecision(18, 2);

            builder.Property(t => t.TransactionType)
                   .IsRequired();

            builder.Property(t => t.Note);

            builder.Property(t => t.AccountNumber)
                   .IsRequired();

            builder.HasOne(t => t.Account)
                   .WithMany(a => a.Transactions)
                   .HasForeignKey(t => t.AccountNumber);
        }
    }
}