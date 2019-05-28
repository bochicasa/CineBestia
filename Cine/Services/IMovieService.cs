using Cine.Services.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetPeliculas();
        Task<string> GetPeliculaImage(string posterPath);
    }
}
