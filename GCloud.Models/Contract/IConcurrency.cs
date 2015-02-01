namespace GCloud.Models.Contract
{
    public interface IConcurrency
    {
        int RowVersion { get; set; }
    }
}
