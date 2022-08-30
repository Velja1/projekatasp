using BussinessLogic.Helpers;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface IManufactersBLL
    {
        ApiResponse<List<Manufacters>> GetManufacter();
        void AddManufacters(Manufacters Model);
        void UpdateManufacters(Manufacters Model);
        void DeleteManufacters(int ModelID);
        Manufacters GetManufacterByID(int ID);
        Pagination<List<Manufacters>> GetPagination(PaginationModel model);
    }
    public class ManufactersBLL : IManufactersBLL
    {
        private readonly ProjectContext db;
        public ManufactersBLL(ProjectContext _db)
        {
            db = _db;
        }        
        public ApiResponse<List<Manufacters>> GetManufacter()
        {
            ApiResponse<List<Manufacters>> response = new ApiResponse<List<Manufacters>>();
            try
            {
                response.data = db.Manufacters.ToList();
            }
            catch (Exception ex)
            {
                response.statuscode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public void AddManufacters(Manufacters Model)
        {
            db.Manufacters.Add(Model);
            db.SaveChanges();
        }
        public void UpdateManufacters(Manufacters Model)
        {
            var getModel = db.Manufacters.Where(s => s.ID == Model.ID).FirstOrDefault();
            getModel = Model;
            db.Entry(getModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteManufacters(int ModelID)
        {
            var getModel = db.Manufacters.Where(s => s.ID == ModelID).FirstOrDefault();
            db.Remove(getModel);
            db.SaveChanges();
        }
        public Manufacters GetManufacterByID(int ID)
        {
            return db.Manufacters.Where(s => s.ID == ID).FirstOrDefault();
        }
        public Pagination<List<Manufacters>> GetPagination(PaginationModel model)
        {
            Pagination<List<Manufacters>> response = new Pagination<List<Manufacters>>();
            response.data = db.Manufacters.Where(s => s.Name.StartsWith(model.Search)).Take(model.PageSize).ToList();
            return response;
        }
    }
}
