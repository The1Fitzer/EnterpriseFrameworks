using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class User
    {
        DataLayer.onlineshopEntities _db = new DataLayer.onlineshopEntities();

        public string Name { get; set; }
        public int Role_id { get; set; }
        public string Password { get; set; }

        public void Save()
        {
            DataLayer.User user = new DataLayer.User
            {
                name = this.Name,
                role = this.Role_id,
                password = HashPwd(this.Password)
            };

            try
            {
                _db.Users.AddObject(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
        public static string HashPwd(string value)
        {
            return Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(value)));
        }
    }
    public class UserLogin
    {
        DataLayer.onlineshopEntities _db = new DataLayer.onlineshopEntities();

        public string Name { get; set; }
        public string Password { get; set; }

        public void LogIn()
        {
            var is_user = _db.Users.Where(u => u.name.StartsWith(this.Name));
            int count = is_user.Count();

            if (count > 0)
            {
                FormsAuthentication.SetAuthCookie(this.Name, true);   
            }
        }
    }
    public class UpdateUser
    {
        DataLayer.onlineshopEntities _db = new DataLayer.onlineshopEntities();

        public string Name { get; set; }
        public string Old { get; set; }
        public int Phone { get; set; }

        public void Update()
        {
            DataLayer.User update = _db.Users.Single(p=>p.name == this.Old);

            
            update.name = this.Name;
            update.phone = this.Phone;

            _db.SaveChanges();
        }
    }
}
