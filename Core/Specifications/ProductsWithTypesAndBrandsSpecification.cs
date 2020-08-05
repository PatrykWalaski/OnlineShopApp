using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) // first we are calling the base constructor in BaseSpecification class we derive from with expression we send to it
            : base(x => x.Id == id)
        { // get the ^ product where id is equal to id we sent to this constructor, also include types and brand below so its not null when we return it to client
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}