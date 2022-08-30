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
    public interface IUsersBLL
    {
        ApiResponse<List<Users>> GetUsers();
        Task<ApiResponse<bool>> sendingEmail(string Email, string Content);
        Users GetTypesByID(int ID);
        void AddUser(Users Model);
        void DeleteUsers(int ModelID);
        void UpdateUsers(Users Model);
        Pagination<List<Users>> GetPagination(PaginationModel model);
    }
    public class UsersBLL: IUsersBLL
    {
        private readonly ProjectContext db;
        private readonly IEmailHelper _EmailHelper;
        public UsersBLL(ProjectContext _db, IEmailHelper EmailHelper)
        {
            db = _db;
            _EmailHelper = EmailHelper;
        }
        public ApiResponse<List<Users>> GetUsers()
        {
            ApiResponse<List<Users>> response = new ApiResponse<List<Users>>();
            try
            {
                response.data = db.Users.ToList();
                response.statuscode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.statuscode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ApiResponse<bool>> sendingEmail(string Email, string Content)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            var isEmailSend = await _EmailHelper.SendEmail(Email, Content);
            if (isEmailSend)
            {
                response.statuscode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.statuscode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public void AddUser(Users Model)
        {
            db.Users.Add(Model);
            db.SaveChanges();
        }
        public void UpdateUsers(Users Model)
        {
            var getModel = db.Users.Where(s => s.Id == Model.Id).FirstOrDefault();
            getModel = Model;
            db.Entry(getModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteUsers(int ModelID)
        {
            var getModel = db.Users.Where(s => s.Id == ModelID).FirstOrDefault();
            db.Remove(getModel);
            db.SaveChanges();
        }
        public Users GetTypesByID(int ID)
        {
            return db.Users.Where(s => s.Id == ID).FirstOrDefault();
        }
        public Pagination<List<Users>> GetPagination(PaginationModel model)
        {
            Pagination<List<Users>> response = new Pagination<List<Users>>();
            response.data = db.Users.Where(s=>s.Name.StartsWith(model.Search)).Take(model.PageSize).ToList();
            return response;
        }
    }
}
