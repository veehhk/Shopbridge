namespace Shopbridge.Framework.Utils.Grid
{
    using System.Collections.Generic;
    
    public sealed class Filter
    {
        public string Property { get; set; }

        public string Comparison { get; set; }

        public string Value { get; set; }
    }

    public sealed class Filters : List<Filter> { }
}