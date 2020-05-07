using System;

namespace Domain.Models
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Tenant { get; set; }

        public virtual DateTime SyncDate { get; set; }
    }
}