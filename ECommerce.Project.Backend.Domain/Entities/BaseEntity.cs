namespace ECommerce.Project.Backend.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public bool Deleted { get; protected set; }
    }
}
