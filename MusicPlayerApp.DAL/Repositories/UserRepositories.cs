﻿using MusicPlayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.DAL.Repositories
{
    public class UserRepositories
    {
        private MusicAppContext _context;

        public List<User> GetAll()
        {
            _context = new MusicAppContext();
            return _context.Users.ToList();
        }

        public User? GetOne(string email, string password)
        {
            _context = new MusicAppContext();
            return _context.Users.FirstOrDefault(s => s.Email.ToLower() == email && s.Password == password);
        }
    }
}
