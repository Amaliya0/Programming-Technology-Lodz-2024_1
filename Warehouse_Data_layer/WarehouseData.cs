namespace WarehouseDataLayer
{
    public class WarehouseData : WarehouseDataAPI
    {
        private int productIdCounter = 0;
        public int idAssignment()
        {
            productIdCounter++;
            return productIdCounter;
        }

        public override int AddProduct(string productName, int initialQuantity)
        {
            int newProductId = idAssignment();
            ProductCatalog.Add(new CatalogProduct(newProductId, productName));
            Inventory.Add(new InventoryProduct(newProductId, initialQuantity));
            return newProductId;
        }

        public override void RecordIncomingShipment(int productId, int quantity)
        {
            if (Inventory is null)
            {
                throw new InvalidOperationException("Inventory is not initialized.");
            }

            InventoryProduct foundProduct = Inventory.FirstOrDefault(p => p.Id == productId);

            if (foundProduct != null)
            {
                foundProduct.Quantity += quantity;
                var product = ProductCatalog[productId];
                if (product == null)
                {
                    throw new Exception("Product not found in catalog.");
                }
                Invoices.Add($"Received {quantity} units of product {ProductCatalog[productId].Name}");
            }
            else
            {
                throw new InvalidOperationException("Product not found");
            }
        }

        public override bool RecordOutgoingShipment(int productId, int quantity)
        {
            InventoryProduct product = Inventory.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                var catalogProduct = ProductCatalog[productId];
                if (catalogProduct == null)
                {
                    throw new Exception("Product not found in catalog.");
                }
                Invoices.Add($"Shipped {quantity} units of product {catalogProduct.Name}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}