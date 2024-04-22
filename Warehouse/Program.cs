﻿using WarehouseDataLayer;
using WarehouseLogicLayer;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            WarehouseDataAPI warehouseData = new WarehouseData();
            WarehouseLogicAPI warehouseLogic = new WarehouseLogic(warehouseData);

            var idOfProductA = warehouseData.AddProduct("Product A", 100);
            var idOfProductB = warehouseData.AddProduct("Product B", 50);

            Console.WriteLine("Product A id:" + idOfProductA);
            Console.WriteLine("Product B id:" + idOfProductB);

            Staff staffMember = new Staff ("John", "Hendricks", 1);
            Customer customer = new Customer ("Alice", "Murphy", 2);
            Supplier supplier = new Supplier ("Bob", "Moyer", 3);

            warehouseData.Staff.Add(staffMember);
            warehouseData.Customers.Add(customer);
            warehouseData.Suppliers.Add(supplier);

            Console.WriteLine("Users in the warehouse:");
            Console.WriteLine("Staff:");
            foreach (var currentStaffMember in warehouseData.Staff)
            {
                Console.WriteLine($"- {currentStaffMember}");
            }
            Console.WriteLine("\nCustomers:");
            foreach (var currentCustomer in warehouseData.Customers)
            {
                Console.WriteLine($"- {currentCustomer}");
            }
            Console.WriteLine("\nSuppliers:");
            foreach (var currentSupplier in warehouseData.Suppliers)
            {
                Console.WriteLine($"- {currentSupplier}");
            }

            FulfillOrder(warehouseLogic, 1, 75);
            TakeInSupplies(warehouseLogic, 1, 50);
        }

        static void FulfillOrder(WarehouseLogicAPI warehouseLogic, int productId, int quantity)
        {
            bool orderFulfilled = warehouseLogic.FulfillOrder(productId, quantity);

            if (orderFulfilled)
            {
                Console.WriteLine($"The order for product with ID {productId} and quantity {quantity} was fulfilled successfully.");
            }
            else
            {
                Console.WriteLine($"Error occurred while fulfilling the order for product with ID {productId} and quantity {quantity}.");
            }
        }

        static void TakeInSupplies(WarehouseLogicAPI warehouseLogic, int productId, int quantity)
        {
            warehouseLogic.RestockProduct(productId, "Product A", quantity);
            Console.WriteLine($"Received {quantity} units of product with ID {productId}.");
        }
    }
}