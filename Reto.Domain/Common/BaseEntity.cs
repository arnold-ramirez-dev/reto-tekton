namespace Reto.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; }
        public string CreatedUser { get; private set; } = string.Empty;
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedUser { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedUser { get; private set; }

        public void SetAuditCreated(string createdUser)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedUser = createdUser ?? string.Empty;
        }

        public void SetAuditUpdated(string updatedUser)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedUser = updatedUser;
        }

        public void SetAuditDeleted(string deletedUser)
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
                DeletedAt = DateTime.UtcNow;
                DeletedUser = deletedUser;
            }
        }

        public void RestoreDeleted()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedUser = null;
        }
    }
}
