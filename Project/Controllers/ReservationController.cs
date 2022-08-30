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
    public class ReservationController : Controller
    {
        private IReservationBLL bLL { get; set; }
        public ReservationController(IReservationBLL _bLL)
        {
            bLL = _bLL;
        }
        [HttpPost, Route("Add")]
        public void Add(Reservations Model)
        {
            bLL.AddReservations(Model);
        }
        [HttpPost, Route("Update")]
        public void Update(Reservations Model)
        {
            bLL.UpdateReservations(Model);
        }
        [HttpPost, Route("Delete")]
        public void Delete(int ID)
        {
            bLL.DeleteReservations(ID);
        }
        [HttpPost, Route("Get")]
        public ApiResponse<List<Reservations>> Get()
        {
            return bLL.GetReservations();
        }
        [HttpPost, Route("GetByID")]
        public Reservations GetByID(int ID)
        {
            return bLL.GetReservationsByID(ID);
        }
    }
}
