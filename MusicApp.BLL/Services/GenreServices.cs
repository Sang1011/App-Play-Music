using MusicApp.DAL.Entities;
using MusicApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.BLL.Services
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
