using MNS.Translator.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace MNS.Translator.Infra.Data.EntityConfig
{
    public class TranslationRequestConfig : EntityTypeConfiguration<TranslationRequest>
    {
        public TranslationRequestConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Text)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(c => c.Translation)
                .HasColumnType("nvarchar");

            Property(c => c.ErrorMessage)
                .HasMaxLength(500);

            Property(c => c.Success)
                .IsRequired();

            Property(c => c.Date)
                .IsRequired();

            Property(c => c.Ip)
                .HasMaxLength(20);

            Ignore(c => c.ValidationResult);
            Ignore(c => c.CascadeMode);

            ToTable("TranslationRequest");
        }
    }
}
