using Cine.Services.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Services
{
    public class MovieService : IMovieService
    {

        public async Task<List<MovieDto>> GetPeliculas()
        {
            try
            {
                var url = UrlMovieDbApi + key + PeliculasGetAll;
                var httpClient = new HttpClient();
                //var json = await httpClient.GetStringAsync(url);
                //List<PeliculaDto> result = JsonConvert.DeserializeObject<List<PeliculaDto>>(json.Content.ReadAsStringAsync().Result);
                //return result;

                var json = httpClient.GetStringAsync(url).Result;
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(json);

                List<MovieDto> movies = result.results.ToList();
                //SortMovies sortMovies = new SortMovies();
                //List<MovieDto> moviess = movies.Sort(sortMovies);
                return movies;
            }
            catch (Exception ex)
            {
                return new List<MovieDto>();
            }
        }

        public async Task<string> GetPeliculaImage(string posterPath)
        {
            try
            {
                var url = UrlMovieDbApi + posterPath;
                var httpClient = new HttpClient();
                var json = httpClient.GetStringAsync(url).Result;
                string result = JsonConvert.DeserializeObject<string>(json);


                return result;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
