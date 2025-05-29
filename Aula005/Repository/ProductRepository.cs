using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product p in ProductData.Products)
                if (p.Id == id)
                    return p;

            return null;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = new List<Product>();

            foreach (Product p in ProductData.Products)
                if (p.Name!.ToLower().Contains(name.ToLower()))
                    ret.Add(p);

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return ProductData.Products;
        }

        public void Save(Product product)
        {
            product.Id = GetCount() + 1;
            ProductData.Products.Add(product);
        }

        public bool Delete(Product product)
        {
            return ProductData.Products.Remove(product);
        }

        public bool DeleteById(int id)
        {
            Product product = Retrieve(id);

            if (product != null)
                return Delete(product);   // Delete(Retrieve(id)); Pode ser feito assim tmb

            return false;
        }

        public void Update(Product newProduct)
        {
            Product oldProduct = Retrieve(newProduct.Id);
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
        }

        public int GetCount()
        {
            return ProductData.Products.Count;
        }
    }
}
