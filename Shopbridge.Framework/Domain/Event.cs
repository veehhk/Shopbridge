namespace Shopbridge.Framework.Domain
{
    using System;
    
    public abstract class Event
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime DateTime { get; } = DateTime.UtcNow;
    }
}