namespace Shopbridge.Framework.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public abstract class Domain<TId> : Base<Domain<TId>>
    {
        protected Domain() { }

#nullable enable

        public TId Id { get; set; }
        #nullable disable

        public bool Status { get; set;}

        protected sealed override IEnumerable<object> Equals() 
        {
            yield return Id;
        }
    }
}