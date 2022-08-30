using BussinessLogic.Helpers;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLogic
{
    public interface IReservationBLL
    {
        ApiResponse<List<Reservations>> GetReservations();
        void AddReservations(Reservations Model);
        void UpdateReservations(Reservations Model);
        Reservations GetReservationsByID(int ID);
        void DeleteReservations(int ModelID);
        Pagination<List<Reservations>> GetPagination(PaginationModel model);
    }
    public class ReservationBLL: IReservationBLL
    {
        private readonly ProjectContext db;
        public ReservationBLL(ProjectContext _db)
        {
            db = _db;
        }
        public ApiResponse<List<Reservations>> GetReservations()
        {
            ApiResponse<List<Reservations>> response = new ApiResponse<List<Reservations>>();
            try
            {
                response.data = db.Reservations.ToList();
                response.statuscode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.statuscode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }        
        public void AddReservations(Reservations Model)
        {
            db.Reservations.Add(Model);
            db.SaveChanges();
        }
        public void UpdateReservations(Reservations Model)
        {
            var getModel = db.Reservations.Where(s => s.ID == Model.ID).FirstOrDefault();
            getModel = Model;
            db.Entry(getModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteReservations(int ModelID)
        {
            var getModel = db.Reservations.Where(s => s.ID == ModelID).FirstOrDefault();
            db.Remove(getModel);
            db.SaveChanges();
        }
        public Reservations GetReservationsByID(int ID)
        {
            return db.Reservations.Where(s => s.ID == ID).FirstOrDefault();
        }
        public Pagination<List<Reservations>> GetPagination(PaginationModel model)
        {
            Pagination<List<Reservations>> response = new Pagination<List<Reservations>>();
            response.data = db.Reservations.Take(model.PageSize).ToList();
            return response;
        }
    }
}
