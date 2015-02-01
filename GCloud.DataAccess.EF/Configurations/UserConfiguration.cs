using System.Data.Entity.ModelConfiguration;
using GCloud.Models;

namespace GCloud.DataAccess.EF.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(t => t.Roles)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole", "Security");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                });
        }
    }

}
