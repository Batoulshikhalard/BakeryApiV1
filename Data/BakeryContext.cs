﻿using BakeryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryApi.Data;
public class BakeryContext : DbContext
{
    public BakeryContext(DbContextOptions<BakeryContext> options) 
        : base(options) 
    { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<RawMaterial> RawMaterials { get; set; }
    public DbSet<SupplierRawMaterial> SupplierRawMaterials { get; set; }
}
