namespace Shopbridge.Framework.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity<TId> : Base<Entity<TId>>
    {
        protected Entity() { }

        protected Entity(TId id) => Id = id;

        [Required]
        [Key]
        public TId Id { get; set; }

        public bool Status { get; set;}

        protected sealed override IEnumerable<object> Equals() 
        {
            yield return Id;
        }
    }
}