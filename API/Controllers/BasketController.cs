using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly StoreContext _context;

        public BasketController(IMapper mapper, IUnitOfWork unitOfWork, StoreContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // [HttpGet("getGuid")]
        // public async Task<ActionResult<string>> getGuid()
        // {
        //     var baskets = await _context.CustomerBaskets.ToListAsync();
        //     if (baskets.Count() <= 0)
        //         return 1;

        //     return Ok(_context.CustomerBaskets.ToList().Last().Id + 1);
        // }

        [HttpGet("{guid}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketByGuid(string guid)
        {
            var basketFromRepo = await _context.CustomerBaskets.Include(x => x.Items).FirstOrDefaultAsync(x => x.Guid.ToString() == guid);

            if (basketFromRepo != null)
                return Ok(basketFromRepo);

            return BadRequest("Error on basket load");
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CustomerBasket>> CreateBasket()
        {
            var basketToAdd = new CustomerBasket()
            {
                Guid = Guid.NewGuid()
            };

            _unitOfWork.Repository<CustomerBasket>().Add(basketToAdd);

            if (await _unitOfWork.Complete() > 0)
                return Ok(await _context.CustomerBaskets.Include(x => x.Items).FirstOrDefaultAsync(x => x.Guid.ToString() == basketToAdd.Guid.ToString()));

            return BadRequest("Error on basket creation");
        }

        [HttpPost("Update")]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            
            var basketForId = await _context.CustomerBaskets.FirstOrDefaultAsync(x => x.Guid.ToString() == basket.Guid);
            if(basketForId != null)
                await _context.Database.ExecuteSqlRawAsync("DELETE FROM [BasketItems] WHERE [BasketItems].CustomerBasketId = " + basketForId.Id);

            var basketFromRepo = await _context.CustomerBaskets.Include(x => x.Items).FirstOrDefaultAsync(x => x.Guid.ToString() == basket.Guid.ToString());

            if(basketFromRepo == null)
                return BadRequest("No basket in db");

            var itemsToAdd = _mapper.Map<List<BasketItem>>(basket.Items);
            foreach (var item in itemsToAdd)
            {
                basketFromRepo.Items.Add(item);
            }

            _context.Update(basketFromRepo);
            
            await _context.SaveChangesAsync();
                
            return Ok(basketFromRepo);
        }

        [HttpDelete("{guid}")]
        public async Task DeleteBasketAsync(string guid)
        {
            var basket = await _context.CustomerBaskets.Include(x => x.Items).FirstOrDefaultAsync(x => x.Guid.ToString() == guid);
            
            foreach (var item in basket.Items)
                _unitOfWork.Repository<BasketItem>().Delete(item);
            _unitOfWork.Repository<CustomerBasket>().Delete(basket);

            await _unitOfWork.Complete();
        }
    }
}