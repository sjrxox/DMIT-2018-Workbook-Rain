﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject] // for the <ObjectDataSource> control
    public class CRUDController
    {
        #region Products CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ListProducts()
        {
            using (var context = new WestWindContext())
            {
                return context.Products.ToList();
            }
        }
        #endregion

        #region Supplies CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]

        public List<Supplier> ListSuppliers()
        {
            using (var context = new WestWindContext())
            {
                return context.Suppliers.Include(nameof(Supplier.Address)).ToList();
                // Avoid magic string ""

            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddSupplier(Supplier Item)
        {
            using (var context = new WestWindContext())
            {
                context.Suppliers.Add(Item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Entry(item);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                var existing = context.Suppliers.Find(item.SupplierID);
                context.Suppliers.Remove(existing);
                context.SaveChanges();
            }
        }


        #endregion


        #region Categories CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListCategories()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }
        #endregion


        #region Addresses CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Address> ListAddresses()
        {
            using (var context = new WestWindContext())
            {
                return context.Addresses.ToList();
            }
        }
        #endregion
    }
}
