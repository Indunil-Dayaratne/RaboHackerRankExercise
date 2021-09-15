using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("inventory/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static readonly List<InventoryItem> _inventoryItems = new List<InventoryItem> { new InventoryItem { Id = 1 }, new InventoryItem { Id = 2 } };

        /*
         private readonly IRepository _repository;

         public ItemController(IRepository repository)
         {
            _repository = repository;
         }
         */

        [HttpGet]
        public async Task<List<InventoryItem>> Get()
        {
            //https://localhost:44378/inventory/item
            //var items = await _repository.GetInventory();
            return _inventoryItems;
        }

        [HttpGet]
        [Route("sort")]
        public async Task<IEnumerable<InventoryItem>> Sort()
        {
            //https://localhost:44378/inventory/item/sort

            //var items = await _repository.GetSorted();

            return _inventoryItems.OrderBy(x => x.Id);
        }

        [HttpGet]
        [Route("query")]
        public async Task<IEnumerable<InventoryItem>> Query(int id)
        {
            //https://localhost:44378/inventory/item/query?id=1
            var inventoryItems = _inventoryItems.Where(x => x.Id == id);
            return inventoryItems;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            //"{\"Id\":1}"
            var inventoryItem = JsonConvert.DeserializeObject<InventoryItem>(value);
            _inventoryItems.Add(inventoryItem);

            //await _repository.AddInventoryItem(inventoryItem);

            return Created("inventory/item", inventoryItem);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] string value)
        {
            var inventoryItem = JsonConvert.DeserializeObject<InventoryItem>(value);
            _inventoryItems.RemoveAll(x => x.Id == inventoryItem.Id);
            _inventoryItems.Add(inventoryItem);

            //await _repository.UpdateInventoryItem(inventoryItem);

            return Ok(inventoryItem);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string value)
        {
            var inventoryItem = JsonConvert.DeserializeObject<InventoryItem>(value);
            _inventoryItems.RemoveAll(x => x.Id == inventoryItem.Id);
            return Ok(inventoryItem);
        }
    }
}
