namespace Shopbridge.Inventory.Api.Domains
{
    using System;
    using Shopbridge.Framework.Domain;
    
    public class InventoryDomain : Domain<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        #region behaviors

        //Add Domain behaviors for InventoryDomain

        public void DeActivate()
        {
            Status = false;
        }

        #endregion
    }
}
