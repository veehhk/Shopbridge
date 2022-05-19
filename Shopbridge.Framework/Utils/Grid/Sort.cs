namespace Shopbridge.Framework.Utils.Grid
{
    public class Sort
    {
        public Sort()
        {
            Ascending = true;
        }

        public bool Ascending { get; set; }

        public string Property { get; set; }
    }
}