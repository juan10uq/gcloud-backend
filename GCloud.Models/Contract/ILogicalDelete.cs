namespace GCloud.Models.Contract
{
    public interface ILogicalDelete
    {
        /// <summary>
        /// Indicates if the entity is active, this is used instead of deleting the entity record in the database
        /// </summary>
        bool Active { get; set; }
    }
}
