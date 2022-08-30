using BussinessLogic.Helpers;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLogic
{
    public interface IVesselsBLL
    {
        List<Vessels> GetVessels();
        void AddVessels(Vessels Model);
        void UpdateVessels(Vessels Model);
        void DeleteVessels(int ModelID);
        Vessels GetVesselsByID(int ID);
        Pagination<List<Vessels>> GetPagination(PaginationModel model);
    }
    public class VesselsBLL: IVesselsBLL
    {
        private readonly ProjectContext db;
        public VesselsBLL(ProjectContext _db)
        {
            db = _db;
        }
        public List<Vessels> GetVessels()
        {
            return db.Vessels.ToList();
        }
        public void AddVessels(Vessels Model)
        {
            db.Vessels.Add(Model);
            db.SaveChanges();
        }
        public void UpdateVessels(Vessels Model)
        {
            var getModel = db.Vessels.Where(s => s.ID == Model.ID).FirstOrDefault();
            getModel = Model;
            db.Entry(getModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteVessels(int ModelID)
        {
            var getModel = db.Vessels.Where(s => s.ID == ModelID).FirstOrDefault();
            db.Remove(getModel);
            db.SaveChanges();
        }
        public Vessels GetVesselsByID(int ID)
        {
            return db.Vessels.Where(s => s.ID == ID).FirstOrDefault();
        }

        public Pagination<List<Vessels>> GetPagination(PaginationModel model)
        {
            Pagination<List<Vessels>> response = new Pagination<List<Vessels>>();
            response.data = db.Vessels.Take(model.PageSize).ToList();
            return response;
        }
    }
}
