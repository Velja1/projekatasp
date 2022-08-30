using BussinessLogic;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TypesController : Controller
    {
        private ITypesBLL bLL { get; set; }
        public TypesController(ITypesBLL _bLL)
        {
            bLL = _bLL;
        }
        [HttpPost, Route("Add")]
        public void Add(Types Model)
        {
            bLL.AddTypes(Model);
        }
        [HttpPost, Route("Update")]
        public void Update(Types Model)
        {
            bLL.UpdateTypes(Model);
        }
        [HttpPost, Route("Delete")]
        public void Delete(int ID)
        {
            bLL.DeleteTypes(ID);
        }
        [HttpPost, Route("Get")]
        public List<Types> Get()
        {
            return bLL.GetList();
        }
        [HttpPost, Route("GetByID")]
        public Types GetByID(int ID)
        {
            return bLL.GetTypesByID(ID);
        }
    }
}
