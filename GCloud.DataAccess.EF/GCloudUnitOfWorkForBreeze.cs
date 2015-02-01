using Breeze.ContextProvider;
using GCloud.Authorization.Contract;
using GCloud.Core.Contract;
using GCloud.DataAccess.Contract;
using Newtonsoft.Json.Linq;

namespace GCloud.DataAccess.EF
{
    public class GCloudUnitOfWorkForBreeze : GCloudUnitOfWork, IGCloudUnitOfWorkForBreeze
    {
         private readonly GCloudContextProvider _context;
        private readonly GCloudMetadataProvider _contextMetadataContext;

        // ~/breeze/Metadata
        public string Metadata
        {
            get
            {
                // Returns metadata from a dedicated DbContext that is different from
                // the DbContext used for other operations
                // See ClinPlanMetadataContext for more about the scenario behind this.
                return _contextMetadataContext.Metadata();
            }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _context.SaveChanges(saveBundle);
        }

        public GCloudUnitOfWorkForBreeze(GCloudContextProvider inventoryContext, IUserSession userSession, IGCloudEntitySaveGuard entitySaveGuard, GCloudMetadataProvider contextMetadataContext) : 
            base(inventoryContext.Context, userSession)
        {
            _context = inventoryContext;
            _contextMetadataContext = contextMetadataContext;
            _context.BeforeSaveEntitiesDelegate += entitySaveGuard.BeforeSaveEntities;
            _context.BeforeSaveEntityDelegate += entitySaveGuard.BeforeSaveEntity;
        }
    }
}
