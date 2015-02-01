using System;
using System.Data.Entity;
using System.Threading.Tasks;
using GCloud.Authorization.Contract;
using GCloud.DataAccess.Contract;
using GCloud.Models;

namespace GCloud.DataAccess.EF
{
    public class GCloudUnitOfWork : IGCloudUnitOfWork
    {
        #region Private variables
        /// <summary>
        /// Breeze Context Provider wrapper
        /// </summary>
        private readonly GCloudContext _dbContext;

        private IRepository<Customer> _customerRepository;
        private IRepository<Rate> _rateRepository;
        private IRepository<Plan> _planRepository;
        private IRepository<FrequencyPeriod> _frecuencyPeriodRepository;
        private IRepository<Contact> _contactRepository;
        private IRepository<Address> _addressRepository;
        private IRepository<PhoneNumber> _phoneNumberRepository;
        private IRepository<Tenant> _tenantRepository;
        private IRepository<User> _userRepository;
        private IRepository<Rol> _rolRepository;
        private IRepository<Audit> _auditRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<Group> _groupRepository;
        private IRepository<Gym> _gymRepository;
        private IRepository<PaymentType> _paymentTypeRepository;
        
        private readonly IUserSession _userContext;

        #endregion

        #region Constructor

        public GCloudUnitOfWork(GCloudContext gCloudContext, IUserSession userContext)
        {
            _dbContext = gCloudContext;
            _userContext = userContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// GCloud Context
        /// </summary>
        public DbContext Context
        {
            get { return _dbContext; }
        }

        /// <summary>
        /// Customer Repository
        /// </summary>
        public IRepository<Customer> CustomerRepository
        {
            get { return _customerRepository ?? (_customerRepository = new GenericTenantRepository<Customer>(Context, _userContext)); }
            set { _customerRepository = value; }
        }

        /// <summary>
        /// Address Repository
        /// </summary>
        public IRepository<Address> AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = new GenericTenantRepository<Address>(Context, _userContext)); }
            set { _addressRepository = value; }
        }

        /// <summary>
        /// Rate Repository
        /// </summary>
        public IRepository<Rate> RateRepository
        {
            get { return _rateRepository ?? (_rateRepository = new GenericTenantRepository<Rate>(Context, _userContext)); }
            set { _rateRepository = value; }
        }

        /// <summary>
        /// Plan Repository
        /// </summary>
        public IRepository<Plan> PlanRepository
        {
            get { return _planRepository ?? (_planRepository = new GenericTenantRepository<Plan>(Context, _userContext)); }
            set { _planRepository = value; }
        }

        /// <summary>
        /// Group Repository
        /// </summary>
        public IRepository<Group> GroupRepository
        {
            get { return _groupRepository ?? (_groupRepository = new GenericTenantRepository<Group>(Context, _userContext)); }
            set { _groupRepository = value; }
        }


        /// <summary>
        /// FrequencyPeriod Repository
        /// </summary>
        public IRepository<FrequencyPeriod> FrequencyPeriodRepository
        {
            get { return _frecuencyPeriodRepository ?? (_frecuencyPeriodRepository = new BaseGenericRepository<FrequencyPeriod>(Context, _userContext)); }
            set { _frecuencyPeriodRepository = value; }
        }

        /// <summary>
        /// Gym Repository
        /// </summary>
        public IRepository<Gym> GymRepository
        {
            get { return _gymRepository ?? (_gymRepository = new GenericTenantRepository<Gym>(Context, _userContext)); }
            set { _gymRepository = value; }
        }

        /// <summary>
        /// Contact Repository
        /// </summary>
        public IRepository<Contact> ContactRepository
        {
            get { return _contactRepository ?? (_contactRepository = new GenericTenantRepository<Contact>(Context, _userContext)); }
            set { _contactRepository = value; }
        }

        /// <summary>
        /// PhoneNumber Repository
        /// </summary>
        public IRepository<PhoneNumber> PhoneNumberRepository
        {
            get { return _phoneNumberRepository ?? (_phoneNumberRepository = new GenericTenantRepository<PhoneNumber>(Context, _userContext)); }
            set { _phoneNumberRepository = value; }
        }

        /// <summary>
        /// Country Repository
        /// </summary>
        public IRepository<Country> CountryRepository
        {
            get { return _countryRepository ?? (_countryRepository = new BaseGenericRepository<Country>(Context, _userContext)); }
            set { _countryRepository = value; }
        }

        /// <summary>
        /// Audit Repository
        /// </summary>
        public IRepository<Audit> AuditRepository
        {
            get { return _auditRepository ?? (_auditRepository = new BaseGenericRepository<Audit>(Context, _userContext)); }
            set { _auditRepository = value; }
        }

        /// <summary>
        /// Tenant Repository
        /// </summary>
        public IRepository<Tenant> TenantRepository
        {
            get { return _tenantRepository ?? (_tenantRepository = new BaseGenericRepository<Tenant>(Context, _userContext)); }
            set { _tenantRepository = value; }
        }

        /// <summary>
        /// User Repository
        /// </summary>
        public IRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericTenantRepository<User>(Context, _userContext)); }
            set { _userRepository = value; }
        }

        /// <summary>
        /// Rol Repository
        /// </summary>
        public IRepository<Rol> RolRepository
        {
            get { return _rolRepository ?? (_rolRepository = new BaseGenericRepository<Rol>(Context, _userContext)); }
            set { _rolRepository = value; }
        }

        /// <summary>
        /// PaymentType Repository
        /// </summary>
        public IRepository<PaymentType> PaymentTypeRepository
        {
            get { return _paymentTypeRepository ?? (_paymentTypeRepository = new BaseGenericRepository<PaymentType>(Context, _userContext)); }
            set { _paymentTypeRepository = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Save on sql server the current dirty entities on cache
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Save async on sql server the current dirty entities on cache
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
