
namespace B2S.Infrastructure.Domain
{
    public class AuditEntity<T> : EntityBase<T>
    {
        protected AuditEntity()
        {
        }

        public bool IsActive { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime? DateUpdated { get; private set; }

        public DateTime? DateDeleted { get; private set; }
        
        public void Create(bool isActive = true)
        {
            IsActive = isActive;
            DateCreated = DateTime.Now;
        }

        public void Update()
        {
            DateUpdated = DateTime.Now;
        }

        public void Delete(bool isActive = false)
        {
            isActive = isActive;
            DateDeleted = DateTime.Now;
        }

        public void Activate()
        {
            IsActive = true;
            DateUpdated = DateTime.Now;
            DateDeleted = null;
        }
    }

    /// <summary>
    /// Shortcut audit entity class for entities with Id of type int.
    /// </summary>
    public class AuditEntity : AuditEntity<int>
    {
    }
}