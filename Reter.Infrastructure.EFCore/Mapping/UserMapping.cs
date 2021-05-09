using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reter.Infrastructure.EFCore.Mapping
{
    public class UserMapping:IEntityTypeConfiguration<Domain.UserAgg.User>
    {
        public void Configure(EntityTypeBuilder<Domain.UserAgg.User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.FirstName);
            builder.Property(p => p.LastName);
            builder.Property(p => p.UserName);
            builder.Property(p => p.Email);
            builder.Property(p => p.Phone);
            builder.Property(p => p.Status);
            builder.Property(p => p.CreationTime);
        }
    }
}