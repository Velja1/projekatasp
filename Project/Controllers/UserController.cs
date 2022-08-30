using BussinessLogic;
using BussinessLogic.Helpers;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ProjectContext db;// = new ProjectContext();
        private readonly IUsersBLL _UserBLL;
        public UserController(ProjectContext _db, IUsersBLL UserBLL)
        {
            db = _db;
            _UserBLL = UserBLL;
        }
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            users = db.Users.ToList();
            return users;
        }
        [HttpPost]
        [Route("SendEmail")]
        public async Task<ApiResponse<bool>> SendEmail(string Email, string Content)
        {
            return await _UserBLL.sendingEmail(Email, Content);
        }
        [HttpPost, Route("Upload")]
        public IActionResult Upload([FromForm] UploadPhotoRequest file)
        {
            try
            {
              //  var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.File.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.File.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.File.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost, Route("Add")]
        public void Add(Users Model)
        {
            _UserBLL.AddUser(Model);
        }
        [HttpPost, Route("Update")]
        public void Update(Users Model)
        {
            _UserBLL.UpdateUsers(Model);
        }
        [HttpPost, Route("Delete")]
        public void Delete(int ID)
        {
            _UserBLL.DeleteUsers(ID);
        }
        [HttpPost, Route("Get")]
        public ApiResponse<List<Users>> Get()
        {
            return _UserBLL.GetUsers();
        }
        [HttpPost, Route("GetByID")]
        public Users GetByID(int ID)
        {
            return _UserBLL.GetTypesByID(ID);
        }
        

    }
    public class UploadPhotoRequest
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }

        public string FileName { get; set; }
    }
}
