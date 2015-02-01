using GCloud.Models;

namespace GCloud.DataAccess.Contract
{
    public interface IGCloudUnitOfWork : IUnitOfWork
    {
         /// <summary>
        /// PaymentType Repository
        /// </summary>
        IRepository<PaymentType> PaymentTypeRepository { get; set; }

        /// <summary>
        /// Customer Repository
        /// </summary>
        IRepository<Customer> CustomerRepository { get; set; }

        /// <summary>
        /// Plan Repository
        /// </summary>
        IRepository<Plan> PlanRepository { get; set; }

        /// <summary>
        /// Plan Repository
        /// </summary>
        IRepository<Rate> RateRepository { get; set; }

        /// <summary>
        /// FrequencyPeriod Repository
        /// </summary>
        IRepository<FrequencyPeriod> FrequencyPeriodRepository { get; set; }

        /// <summary>
        /// Address Repository
        /// </summary>
        IRepository<Address> AddressRepository { get; set; }

        /// <summary>
        /// Contact Repository
        /// </summary>
        IRepository<Contact> ContactRepository { get; set; }

        /// <summary>
        /// PhoneNumber Repository
        /// </summary>
        IRepository<PhoneNumber> PhoneNumberRepository { get; set; }

        /// <summary>
        /// Country Repository
        /// </summary>
        IRepository<Country> CountryRepository { get; set; }

        /// <summary>
        /// Group Repository
        /// </summary>
        IRepository<Group> GroupRepository { get; set; }

        /// <summary>
        /// Gym Repository
        /// </summary>
        IRepository<Gym> GymRepository { get; set; }

        /// <summary>
        /// Gym Repository
        /// </summary>
        IRepository<Tenant> TenantRepository { get; set; }

        /// <summary>
        /// User Repository
        /// </summary>
        IRepository<User> UserRepository { get; set; }

        /// <summary>
        /// Rol Repository
        /// </summary>
        IRepository<Rol> RolRepository { get; set; }

        /// <summary>
        /// Audit Repository
        /// </summary>
        IRepository<Audit> AuditRepository { get; set; }
    }
}
