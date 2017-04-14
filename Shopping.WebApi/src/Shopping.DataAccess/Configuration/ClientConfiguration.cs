using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DataAccess.Entities;

namespace Shopping.DataAccess.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();

        }
    }
}
