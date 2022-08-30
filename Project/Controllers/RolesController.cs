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
    public class RolesController : Controller
    {
        private IRolesBLL bLL { get; set; }
        public RolesController(IRolesBLL _bLL)
        {
            bLL = _bLL;
        }
        [HttpPost, Route("Add")]
        public void Add(Roles Model)
        {
            bLL.AddRoles(Model);
        }
        [HttpPost, Route("Update")]
        public void Update(Roles Model)
        {
            bLL.UpdateRole(Model);
        }
        [HttpPost, Route("Delete")]
        public void Delete(int ID)
        {
            bLL.DeleteRoles(ID);
        }
        [HttpPost, Route("Get")]
        public List<Roles> Get()
        {
            return bLL.GetRoles();
        }
        [HttpPost, Route("GetByID")]
        public Roles GetByID(int ID)
        {
            return bLL.GetRoleByID(ID);
        }
    }
}
