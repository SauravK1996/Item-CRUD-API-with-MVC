using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItemAPI.Models;
using ItemAPI.Models.Dtos;
using ItemAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemsController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of all Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<ItemDto>))]
        [AllowAnonymous]
        public IActionResult GetItems()
        {
            var objList = _itemRepository.GetItems();

            var objDto = new List<ItemDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<ItemDto>(obj));
            }

            return Ok(objDto);
        }

        /// <summary>
        /// Get individual Item
        /// </summary>
        /// <param name="itemid">The id of the Item list</param>
        /// <returns></returns>

        [HttpGet("{itemid:int}", Name = "GetItem")]
        [ProducesResponseType(200, Type = typeof(ItemDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        
        public IActionResult GetItem(int itemid)
        {
            var obj = _itemRepository.GetItem(itemid);

            if(obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<ItemDto>(obj);
            return Ok(objDto);
        }

        /// <summary>
        /// Create new Item
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ItemDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateItem([FromBody] ItemDto itemDto)
        {
            if(itemDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_itemRepository.ItemExists(itemDto.Title))
            {
                ModelState.AddModelError("","Item already exists!");
                return StatusCode(404, ModelState);
            }

            var itemObj = _mapper.Map<Item>(itemDto);

            if (!_itemRepository.CreateItem(itemObj))
            {
                ModelState.AddModelError("",$"Something went wrong when saving the record {itemObj.Title}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetItem",new { itemId = itemObj.ItemId },itemObj);
        }

        /// <summary>
        /// Update the existing item
        /// </summary>
        /// <param name="itemId">Enter Item id</param>
        /// <param name="itemDto">Enter Updated Item</param>
        /// <returns></returns>
        [HttpPatch("{itemId:int}", Name = "UpdateItem")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateItem(int itemId, [FromBody] ItemDto itemDto)
        {
            if (itemDto == null || itemId!=itemDto.ItemId)
            {
                return BadRequest(ModelState);
            }

            var itemObj = _mapper.Map<Item>(itemDto);

            if (!_itemRepository.UpdateItem(itemObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {itemObj.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Delete the existing Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpDelete("{itemId:int}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteItem(int itemId)
        {
            if (!_itemRepository.ItemExists(itemId))
            {
                return NotFound();
            }

            var itemObj = _itemRepository.GetItem(itemId);

            if (!_itemRepository.DeleteItem(itemObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {itemObj.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}