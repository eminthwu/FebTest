using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [RoutePrefix("EC")]
    public class ECMallController : ApiController
    {
        [Route("Login/{account}")]
        [HttpPost]
        public bool Login(string account, [FromBody]string password)
        {
            Entity.ECMallEntities1 entity = new Entity.ECMallEntities1();
            var result = entity.UserInfo.Where(u => u.Account == account && u.Password == password).FirstOrDefault();
            return result != null;
        }

        [Route("AddProduct")]
        [HttpPost]
        public int InsertProduct(Product product)
        {
            if (product == null)
                return 0;

            WebApplicationApi.Entity.Product insertP = new Entity.Product()
            {
                ProductCategoryId = product.ProductCategoryId,
                ID = System.Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };

            Entity.ECMallEntities1 entity = new Entity.ECMallEntities1();
            entity.Product.Add(insertP);
            var result = entity.SaveChanges();

            return result;
        }

        [Route("DeleteProduct")]
        [HttpDelete]
        public int RemoveProduct(Guid productId)
        {
            if (productId == null)
                return 0;

            Entity.ECMallEntities1 entity = new Entity.ECMallEntities1();
            entity.Product.Remove(new Entity.Product() { ID = productId });
            var result = entity.SaveChanges();

            return result;
        }

        [Route("EditProduct")]
        [HttpPatch]
        public int AlterProduct(Product product)
        {
            if (product == null || product.ID == null)
                return 0;

            Entity.ECMallEntities1 entity = new Entity.ECMallEntities1();
            var alterProduct = entity.Product.Where(p => p.ID == product.ID).FirstOrDefault();

            if (alterProduct == null)
                return 0;

            alterProduct.Name = product.Name;
            alterProduct.Price = product.Price;
            alterProduct.Amount = product.Amount;

            var result = entity.SaveChanges();

            return result;
        }

        [Route("QueryProduct")]
        [HttpGet]
        public Product QueryProduct(Guid productId)
        {
            if (productId == null)
                return null;

            Entity.ECMallEntities1 entity = new Entity.ECMallEntities1();
            var product = entity.Product.Where(p => p.ID == productId).FirstOrDefault();

            return product == null ? null : new Product()
            {
                ProductCategoryId = product.ProductCategoryId,
                ID = System.Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };
        }
    }
}
