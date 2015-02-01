using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GCloud.DataAccess.Contract;
using GCloud.DataAccess.EF.Configurations;
using GCloud.Models;

namespace GCloud.DataAccess.EF
{
    /// <summary>
    /// Context of the Data Base
    /// </summary>
    public class GCloudContext : DbContext
    {

        public GCloudContext(IConnectionStringProvider connStringProvider)
            : base(connStringProvider.GetConnectionString())
        {
            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public GCloudContext()
            : base("GCloudDB")
        {
            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Country entities
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Currency entities
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// FrequencyPeriods entities
        /// </summary>
        public DbSet<FrequencyPeriod> FrequencyPeriods { get; set; }

        /// <summary>
        /// Plan entities
        /// </summary>
        public DbSet<Plan> Plans { get; set; }

        /// <summary>
        /// Rate entities
        /// </summary>
        public DbSet<Rate> Rates { get; set; }
        

        /// <summary>
        /// PaymentType entities
        /// </summary>
        public DbSet<PaymentType> PaymentTypes { get; set; }
        
        /// <summary>
        /// Customer entities
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Addresses entities
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Addresses entities
        /// </summary>
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Contacts entities
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Group entities
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gym entities
        /// </summary>
        public DbSet<Gym> Gyms { get; set; }

        /// <summary>
        /// Users in the system
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Roles authorization
        /// </summary>
        public DbSet<Rol> Roles { get; set; }

        /// <summary>
        /// Audit
        /// </summary>
        public DbSet<Audit> Audits { get; set; }

        /// <summary>
        /// Tenant
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
