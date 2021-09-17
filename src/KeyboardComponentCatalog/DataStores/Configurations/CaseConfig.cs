using KeyboardComponentCatalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyboardComponentCatalog.DataStores.Configurations
{
    public class CaseConfig : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.CaseName);
            builder.Property(prop => prop.CaseDescription);
            builder.Property(prop => prop.PreviewPicName);
            builder.Property(prop => prop.ModelFileName);
            builder.Property(prop => prop.HoverText);
        }
    }
}