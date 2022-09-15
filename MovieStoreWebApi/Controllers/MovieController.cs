using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.MovieModels.Request;
using MovieStoreWebApi.MovieModels.Response;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IValidator<AddRequestVM> _addRequestVMValidator;
        public MovieController(IGenericRepository<Movie> movieRepository, IValidator<AddRequestVM> addRequestVMValidator)
        {
            _movieRepository = movieRepository;
            _addRequestVMValidator = addRequestVMValidator;
        }

        [HttpGet]
        [Route("MovieList")]
        public List<ListVM> MovieList()
        {
            var list = _movieRepository.GetList().Select(x => new ListVM
            {
                Genre = x.Genre,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ReleaseDate = x.ReleaseDate,
                DirectorNames = string.Join(',', x.movieDirectors.Select(x => x.Director.Name).ToList()),
                DirectorSurnames = string.Join(',', x.movieDirectors.Select(x => x.Director.Surname).ToList()),
                RoleNames = string.Join(',', x.movieRoles.Select(x => x.Role.Name).ToList()),
                RoleSurnames = string.Join(',', x.movieRoles.Select(x => x.Role.Surname).ToList()),
                Active = x.Active
            }).Where(x => x.Active == true).ToList();

            return list;
        }

        [HttpGet]
        [Route("MovieGet")]
        public ListVM MovieGet(int id)
        {
            var get = _movieRepository.GetById(id);

            if (get == null)
                return null;
            else
            {
                var result = _movieRepository.GetList().Where(x => x.Id == id).Select(x => new ListVM
                {
                    Genre = x.Genre,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate,
                    DirectorNames = string.Join(',', x.movieDirectors.Select(x => x.Director.Surname).ToList()),
                    DirectorSurnames = string.Join(',', x.movieDirectors.Select(x=>x.Director.Surname).ToList()),
                    RoleNames = string.Join(',',x.movieRoles.Select(x => x.Role.Name).ToList()),
                    RoleSurnames = string.Join(',',x.movieRoles.Select(x => x.Role.Surname).ToList()),
                    Active = x.Active = true

                }).SingleOrDefault();

                return result;
            }
        }

        [HttpPost]
        [Route("MovieAdd")]
        public IActionResult MovieAdd(AddRequestVM model)
        {
            Movie newMovie = new Movie
            {
                Genre = model.Genre,
                ReleaseDate = model.ReleaseDate,
                Name = model.Name,
                Price = model.Price,

            };
            var validateResult = _addRequestVMValidator.Validate(model);
            var messages = new List<string>();
            if(validateResult.IsValid)
            {
                var create = _movieRepository.AddT(newMovie);
                messages.Add("Başarılı");
                return Ok(messages);
            }
                
            else
            {
                foreach (var item in validateResult.Errors)
                {
                    messages.Add(item.ErrorMessage);
                }
                return BadRequest(messages);
            }

        }
        [HttpPut]
        [Route("MovieUpdate")]
        public IActionResult MovieUpdate(AddRequestVM model, int id)
        {
            var get = _movieRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Genre = model.Genre;
                get.ReleaseDate = model.ReleaseDate;
                get.Name = model.Name;
                get.Price = model.Price;

            }
            var validateResult = _addRequestVMValidator.Validate(model);
            var messages = new List<string>();
            if (validateResult.IsValid)
            {
                _movieRepository.UpdateById(get);
                var result = _movieRepository.GetById(id);

                ListVM vm = new ListVM
                {
                    Genre = result.Genre,
                    Name = result.Name,
                    Price = result.Price,
                    ReleaseDate = result.ReleaseDate,
                };
                messages.Add("Başarılı");
                return Ok(messages);
            }
            else
            {
                foreach (var item in validateResult.Errors)
                {
                    messages.Add(item.ErrorMessage);

                }
                return BadRequest(messages);
            }
           
        }

        [HttpDelete]
        [Route("MovieDelete")]
        public IActionResult MovieDelete(int id)
        {
            var get = _movieRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Active = false;
                var result = _movieRepository.UpdateById(get);
                return Ok(result);

            }

        }

    }
}
