using System.Collections.Generic;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; } // angular gonna generate this basket id
        public List<BasketItems> Items { get; set; } = new List<BasketItems>();

    }
}