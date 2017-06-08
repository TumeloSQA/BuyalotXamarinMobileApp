using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BuyalotRestService.Models;

namespace BuyalotRestService.Controllers
{
    public class CategoryManagementController : ApiController
    {
        private BuyalotRestServiceContext db = new BuyalotRestServiceContext();

        // GET: api/CategoryManagement
        public IQueryable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories;
        }

        // GET: api/CategoryManagement/5
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult GetProductCategory(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // PUT: api/CategoryManagement/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductCategory(int id, ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productCategory.ProdCategoryID)
            {
                return BadRequest();
            }

            db.Entry(productCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CategoryManagement
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult PostProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductCategories.Add(productCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productCategory.ProdCategoryID }, productCategory);
        }

        // DELETE: api/CategoryManagement/5
        [ResponseType(typeof(ProductCategory))]
        public IHttpActionResult DeleteProductCategory(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();

            return Ok(productCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id)
        {
            return db.ProductCategories.Count(e => e.ProdCategoryID == id) > 0;
        }
    }
}