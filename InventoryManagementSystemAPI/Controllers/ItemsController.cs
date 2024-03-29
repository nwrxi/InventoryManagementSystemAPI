﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;
using InventoryManagementSystemAPI.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;
        private readonly IMapper _mapper;

        public ItemsController(IItemsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> GetItems()
        {
            return await _repository.GetItems();
            //var a = await _context.Post.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await _repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "IsItemCreatorOrAdmin")]
        public async Task<IActionResult> PutItem(Guid id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                await _repository.UpdateItem(id, item);
            }
            catch (Exception)
            {
                if (!_repository.ItemExists(id))
                {
                    return NotFound();
                }
                if (_repository.BarcodeExists(item.Barcode))
                {
                    ModelState.AddModelError(nameof(Item.Barcode), "Barcode isn't unique.");
                    return BadRequest(ModelState);
                    //return Problem("Barcode isn't unique", statusCode: (int)HttpStatusCode.BadRequest);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostItem(Item item)
        {
            if (_repository.BarcodeExists(item.Barcode))
            {
                ModelState.AddModelError(nameof(Item.Barcode), "Barcode isn't unique.");
                return BadRequest(ModelState);
                //return Problem("Barcode isn't unique", statusCode: (int)HttpStatusCode.BadRequest);
            }
            await _repository.AddItem(item);
            return CreatedAtAction("GetItem", new { id = item.Id }, _mapper.Map<ItemDto>(item));
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "IsItemCreatorOrAdmin")]
        public async Task<ActionResult<Item>> DeleteItem(Guid id)
        {
            var item = await _repository.DeleteItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
    }
}
