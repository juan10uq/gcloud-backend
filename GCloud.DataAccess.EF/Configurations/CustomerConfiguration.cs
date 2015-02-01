using System.Data.Entity.ModelConfiguration;
using GCloud.Models;

namespace GCloud.DataAccess.EF
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ///Primaty Key
           // HasKey(c => c.Id);
        }
    }
}
