using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using System.Text;
using Web.Areas.Admin.Attributes;
using Web.Areas.Admin.Extensions;
using wed.Areas.Admin.Models;
using wed.Models.EF;

namespace wed.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly FoodContext _dbContext;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public MemberController(FoodContext dbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorized(Code = "view-members")]
        [HttpPost]
        public async Task<IActionResult> getList(jDatatable model)
        {
            var items = (from i in _dbContext.Members select i);
            int recordsTotal = 0;
            if (!string.IsNullOrEmpty(model.columns[model.order[0].column].name) && !string.IsNullOrEmpty(model.order[0].dir))
            {
                items = items.OrderBy(model.columns[model.order[0].column].name + " " + model.order[0].dir);
            } // xắp sếp

            if (!string.IsNullOrEmpty(model.search.value))
            {
                items = items.Where(i => i.Name.Contains(model.search.value));

            }
            recordsTotal = items.Count();
            var data = await items.Select(i => new
            {
                i.Id,
                i.Name,
                groupName = i.Group.Name,
                i.LastLogin,
                i.Picture
            }).Skip(model.start).Take(model.length).ToListAsync();
            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
        
        [Authorized(Code = "edit-members")]
        [HttpGet]
        public async Task<IActionResult> getItem(Guid id)
        {
            if (_dbContext.Members == null)
                return NotFound();
            var item = await _dbContext.Members.FindAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [Authorized(Code = "save-members")]
        [HttpPost]
        public async Task<IActionResult> Save(NemberViewModel model, IFormFile Picture)
        {
            Core.Database.Models.Member item;
            if (model.Id == null)
            {
                item = new Core.Database.Models.Member();
                item.Id = Guid.NewGuid();
                item.CreatedOn = DateTime.Now;
                await _dbContext.Members.AddAsync(item);
            }
            else
            {
                item = await _dbContext.Members.FindAsync(model.Id);
                item.ModifiedOn = DateTime.Now;
            }
            item.Name = model.Name;
            item.LoginName = model.LoginName;
            if (!string.IsNullOrEmpty(model.Password))
            {
                item.Password = model.Password;
            }
            item.Email = model.Email;
            if(Picture != null)
            {
                var path = Path.Combine(this._environment.WebRootPath, "img/users/", Picture.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await Picture.CopyToAsync(stream);
                    stream.Close();
                }
                item.Picture = "/img/users/" + Picture.FileName;
            }
            item.GroupId = model.GroupId;
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }

        [Authorized(Code = "delete-members")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var memberInArticle = await _dbContext.Articles.Where(m => m.CreatedBy == id).FirstOrDefaultAsync();
            if (memberInArticle == null)
            {
                var item = await _dbContext.Members.FindAsync(id);
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel item)
        {
            if (string.IsNullOrWhiteSpace(item.LoginName) || string.IsNullOrWhiteSpace(item.Password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ tài khoản và mật khẩu.");
                return View(item);
            }

            string md5Password = MD5Hash(item.Password);
            var member = _dbContext.Members
                .FirstOrDefault(i => i.LoginName == item.LoginName && i.Password == md5Password);

            if (member != null)
            {
                HttpContext.Session.SetObject("member", member);
                var codes = _dbContext.Authorizeds.Where(i => i.GroupId == member.GroupId).Select(i => i.Role.Code).ToList();
                HttpContext.Session.SetObject("codes", codes);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
            return View(item);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetObject("member", null);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public string MD5Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), "Password không được null hoặc rỗng");

            using (MD5 md5H = MD5.Create())
            {
                byte[] data = md5H.ComputeHash(Encoding.UTF8.GetBytes(text.Trim()));
                StringBuilder sB = new StringBuilder();
                foreach (byte b in data)
                    sB.Append(b.ToString("x2"));
                return sB.ToString();
            }
        }
    }
}
