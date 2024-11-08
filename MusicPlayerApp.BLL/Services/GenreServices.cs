using MusicPlayerApp.DAL.Entities;
using MusicPlayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.BLL.Services
{
    public class GenreServices
    {
        private GenreRepositories _repo = new();

        public List<Genre> GetList()
        {
            return _repo.GetAll();
        }
    }
}
