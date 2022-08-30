using BussinessLogic;
using BussinessLogic.Helpers;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ManufactersController : Controller
    {
        private IManufactersBLL bLL { get; set; }
        public ManufactersController(IManufactersBLL _bLL)
        {
            bLL = _bLL;
        }
        [HttpPost,Route("Add")]        
        public void Add(Manufacters Model)
        {
            bLL.AddManufacters(Model);
        }
        [HttpPost, Route("Update")]
        public void Update(Manufacters Model)
        {
            bLL.UpdateManufacters(Model);
        }
        [HttpPost, Route("Delete")]
        public void Delete(int ID)
        {
            bLL.DeleteManufacters(ID);
        }
        [HttpPost, Route("Get")]
        public ApiResponse<List<Manufacters>> Get()
        {
            return bLL.GetManufacter();
        }
        [HttpPost, Route("GetByID")]
        public Manufacters GetByID(int ID)
        {
            return bLL.GetManufacterByID(ID);
        }

    }
}
