using BussinessLogic.Helpers;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLogic
{
    public interface ITypesBLL
    {
        List<Types> GetList();
        void AddTypes(Types Model);
        void UpdateTypes(Types Model);
        void DeleteTypes(int ModelID);
        Types GetTypesByID(int ID);
        Pagination<List<Types>> GetPagination(PaginationModel model);
    }
    public class TypesBLL: ITypesBLL
    {
        private readonly ProjectContext db;
        public TypesBLL(ProjectContext _db)
        {
            db = _db;
        }
        public List<Types> GetList()
        {
            return db.Types.ToList();
        }
        public void AddTypes(Types Model)
        {
            db.Types.Add(Model);
            db.SaveChanges();
        }
        public void UpdateTypes(Types Model)
        {
            var getModel = db.Types.Where(s => s.ID == Model.ID).FirstOrDefault();
            getModel = Model;
            db.Entry(getModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteTypes(int ModelID)
        {
            var getModel = db.Types.Where(s => s.ID == ModelID).FirstOrDefault();
            db.Remove(getModel);
            db.SaveChanges();
        }
        public Types GetTypesByID(int ID)
        {
            return db.Types.Where(s => s.ID == ID).FirstOrDefault();
        }
        public Pagination<List<Types>> GetPagination(PaginationModel model)
        {
            Pagination<List<Types>> response = new Pagination<List<Types>>();
            response.data = db.Types.Take(model.PageSize).ToList();
            return response;
        }
    }
}
