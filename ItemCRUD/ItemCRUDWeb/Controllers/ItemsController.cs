using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemCRUDWeb.Models;
using ItemCRUDWeb.Repository.IRepository;
using ItemCRUDWeb.StaticDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemCRUDWeb.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            return View(new Item() { });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upsert(int? id)
        {
            Item obj = new Item();
            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //flow will come here for update
            obj = await _itemRepository.GetAsync(SD.ItemAPIPath, id.GetValueOrDefault(), HttpContext.Session.GetString("JWToken"));
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public async Task<IActionResult> GetAllItem()
        {
            return Json(new { data = await _itemRepository.GetAllAsync(SD.ItemAPIPath, HttpContext.Session.GetString("JWToken")) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public async Task<IActionResult> Upsert(Item obj)
        {
            if (ModelState.IsValid)
            {
                
                if (obj.ItemId == 0)
                {
                    await _itemRepository.CreateAsync(SD.ItemAPIPath, obj, HttpContext.Session.GetString("JWToken"));
                }
                else
                {
                    await _itemRepository.UpdateAsync(SD.ItemAPIPath + obj.ItemId, obj, HttpContext.Session.GetString("JWToken"));
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obj);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _itemRepository.DeleteAsync(SD.ItemAPIPath, id, HttpContext.Session.GetString("JWToken"));
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete not Successful" });
        }
    }
}