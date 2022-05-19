namespace Shopbridge.Framework.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public abstract class Model<TId> : Base<Model<TId>>
    {
        protected Model() { }

#nullable enable

        public TId Id { get; set; }
        #nullable disable

        public bool Status { get; set; }

        protected sealed override IEnumerable<object> Equals()
        {
            yield return Id;
        }
    }
}