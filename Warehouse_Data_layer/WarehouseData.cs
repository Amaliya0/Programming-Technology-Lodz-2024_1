﻿using System.Collections.Generic;

public class WarehouseData
{
    public Dictionary<int, string> ProductCatalog { get; set; } = new Dictionary<int, string>();
    public List<string> Invoices { get; set; } = new List<string>();
    public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>();
    public Users Users { get; set; } = new Users(); 

    public void AddProduct(int productId, string productName, int initialQuantity)
    {
        ProductCatalog.Add(productId, productName);
        Inventory.Add(productId, initialQuantity);
    }

    public void RecordIncomingShipment(int productId, int quantity)
    {
        Inventory[productId] += quantity;
        Invoices.Add($"Received {quantity} units of product {ProductCatalog[productId]}");
    }

    public bool RecordOutgoingShipment(int productId, int quantity)
    {
        if (Inventory.ContainsKey(productId) && Inventory[productId] >= quantity)
        {
            Inventory[productId] -= quantity;
            Invoices.Add($"Shipped {quantity} units of product {ProductCatalog[productId]}");
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Users
{
    public List<string> Readers { get; set; } = new List<string>(); 
    public List<string> Customers { get; set; } = new List<string>();
    public List<string> Suppliers { get; set; } = new List<string>();
}
