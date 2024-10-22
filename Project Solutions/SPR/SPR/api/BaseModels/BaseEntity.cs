namespace api.BaseModels
{
    public abstract class BaseEntity
    {
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
