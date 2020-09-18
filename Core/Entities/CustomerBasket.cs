using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CustomerBasket : BaseEntity
    {
        public List<BasketItem> Items { get; set; }
        public Guid Guid { get ; set; }

    }
}