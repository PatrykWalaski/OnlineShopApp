using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Dto
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; } // angular gonna generate this basket id
        public List<BasketItemDto> Items { get; set; }
    }
}