using System.Data.Entity;
using GCloud.Models;

namespace GCloud.DataAccess.EF
{
    /// <summary>
    /// Specialized DbContext for hiding a property (TenantId) from
    /// client metadata while keeping it availble for EF operations
    /// that use the base <see cref="GCloudContext"/>.
    /// </summary>
    /// <remarks>
    /// See the StackOverflow question for the scenario behind this class:
    /// http://stackoverflow.com/questions/16275184/how-can-i-tell-breeze-to-completely-ignore-a-property-from-a-code-first-generate/16314379#16314379
    /// </remarks>
    public class GCloudMetadataContext : GCloudContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Customer>().Ignore(t => t.Active);
            modelBuilder.Entity<Customer>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Customer>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Customer>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Customer>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Address>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Address>().Ignore(t => t.Active);
            modelBuilder.Entity<Address>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Address>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Address>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Address>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Contact>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Contact>().Ignore(t => t.Active);
            modelBuilder.Entity<Contact>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Contact>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Contact>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Contact>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Group>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Group>().Ignore(t => t.Active);
            modelBuilder.Entity<Group>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Group>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Group>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Group>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Group>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Group>().Ignore(t => t.Active);
            modelBuilder.Entity<Group>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Group>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Group>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Group>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Gym>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Gym>().Ignore(t => t.Active);
            modelBuilder.Entity<Gym>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Gym>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Gym>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Gym>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.TenantId);
            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.Active);
            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<PhoneNumber>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Plan>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Plan>().Ignore(t => t.Active);
            modelBuilder.Entity<Plan>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Plan>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Plan>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Plan>().Ignore(t => t.UpdatedBy);

            modelBuilder.Entity<Rate>().Ignore(t => t.TenantId);
            modelBuilder.Entity<Rate>().Ignore(t => t.Active);
            modelBuilder.Entity<Rate>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<Rate>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<Rate>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<Rate>().Ignore(t => t.UpdatedBy);


            modelBuilder.Entity<User>().Ignore(t => t.TenantId);
            modelBuilder.Entity<User>().Ignore(t => t.Active);
            modelBuilder.Entity<User>().Ignore(t => t.CreateDate);
            modelBuilder.Entity<User>().Ignore(t => t.UpdateDate);
            modelBuilder.Entity<User>().Ignore(t => t.CreatedBy);
            modelBuilder.Entity<User>().Ignore(t => t.UpdatedBy);


            

        }
    }
}
