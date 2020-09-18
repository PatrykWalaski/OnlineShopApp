using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    public class CustomerBasketDto
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}