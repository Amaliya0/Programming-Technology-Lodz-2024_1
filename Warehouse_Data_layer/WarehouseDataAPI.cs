namespace WarehouseDataLayer
{
    public abstract class WarehouseDataAPI
    {
        public List<CatalogProduct> ProductCatalog { get; set; } = new List<CatalogProduct>();
        public List<string> Invoices { get; set; } = new List<string>();
        public List<InventoryProduct> Inventory { get; set; } = new List<InventoryProduct>();
        public List<Staff> Staff { get; set; } = new List<Staff>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public abstract int AddProduct(string productName, int initialQuantity);
        public abstract void RecordIncomingShipment(int productId, int quantity);
        public abstract bool RecordOutgoingShipment(int productId, int quantity);
    }
}
