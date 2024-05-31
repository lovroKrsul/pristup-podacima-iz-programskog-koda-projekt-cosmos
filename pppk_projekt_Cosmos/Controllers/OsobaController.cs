using pppk_projekt_Cosmos.DAO;
using pppk_projekt_Cosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace pppk_projekt_Cosmos.Controllers
{
    public class OsobaController : Controller
    {
        private static readonly ICosmosDBService service = CosmosServiceDBProvider.CosmosService; 
        // GET: Osoba
        public async  Task<ActionResult> Index()
        {
            return View(await service.GetOsobeAsync("Select * from Item"));
        }

        // GET: Osoba/Details/5
        public async Task<ActionResult> Details(string id) => await ShowItem(id);

        private async Task<ActionResult> ShowItem(string id)
        {
           if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var item = await service.GetOsobaAsync(id);
            if(item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


        // GET: Osoba/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }
        

        // POST: Osoba/Create
        [HttpPost]
        public async Task<ActionResult> Create(Osoba osoba)
        {
            if(ModelState.IsValid)
            {
                osoba.ID=Guid.NewGuid().ToString();
                await service.AddOsobaAsync(osoba);
                return Redirect("Index");
            }
            return View(osoba);
           
        }

        // GET: Osoba/Edit/5
        public async Task<ActionResult> Edit(string id) => await ShowItem(id);
       

        // POST: Osoba/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                
                await service.EditOsobaAsync(osoba);
                return Redirect("Index");
            }
            return View(osoba);
        }

        // GET: Osoba/Delete/5
        public async Task<ActionResult>  Delete(string id) => await ShowItem(id);
        

        // POST: Osoba/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Osoba osoba)
        {
      
                
                await service.DeleteOsobaAsync(osoba);
                return Redirect("Index");
            
            
        }
    }
}
