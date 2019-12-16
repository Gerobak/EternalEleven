using EternalEleven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EternalEleven.Controllers.api
{
    public class UsersController : ApiController
    {

        private ActionDBContext _context;

        public UsersController()
        {
            _context = new ActionDBContext();
        }

        // GET api/users
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        // GET api/users/1
        public User GetUsers(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.ID == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return user;

        }

        // POST api/users
        [HttpPost]
        public User CreateUser(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;

        }

        // PUT api/users/1
        [HttpPut]
        public void UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userInDb = _context.Users.SingleOrDefault(u => u.ID == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            userInDb.Username = user.Username;
            userInDb.Email = user.Email;
            userInDb.Password = user.Password;

            _context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.ID == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }
    }
}