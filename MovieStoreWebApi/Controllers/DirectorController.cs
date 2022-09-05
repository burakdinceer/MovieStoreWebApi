using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.ModelsDirector.Request;
using MovieStoreWebApi.Models.ModelsDirector.Response;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IGenericRepository<Director> _directorRepository;
        public DirectorController(IGenericRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }

        [HttpGet]
        [Route("DirectorList")]
        public List<DirectorResponseVM> DirectorList()
        {
            var list = _directorRepository.GetList().
                Select(x => new DirectorResponseVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Active = x.Active,
                }).Where(x => x.Active).ToList();
            return list;
        }

        [HttpGet]
        [Route("DirectorGet")]
        public DirectorResponseVM DirectorGet(int id)
        {
            var get = _directorRepository.GetList().
                Where(x => x.Id == id).
                Select(x => new DirectorResponseVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Active = x.Active,
                }).Where(x => x.Active).SingleOrDefault();
            return get;
        }

        [HttpPost]
        [Route("DirectorAdd")]
        public IActionResult DirectorAdd(DirectorRequestVM model)
        {
            Director directorVm = new Director
            {
                Name = model.Name,
                Surname = model.Surname,
            };

            var result = _directorRepository.AddT(directorVm);
            if (result == null)
                return BadRequest();
            else
            {
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("DirectorUpdate")]
        public IActionResult DirectorUpdate(DirectorRequestVM model, int id)
        {
            var get = _directorRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Name = model.Name;
                get.Surname = model.Surname;
            }
            _directorRepository.UpdateById(get);
            var result = _directorRepository.GetById(id);
            DirectorResponseVM vm = new DirectorResponseVM
            {
                Id = result.Id,
                Name = result.Name,
                Surname = result.Surname,
                Active = result.Active,
            };
            return Ok(vm);
        }
        [HttpDelete]
        [Route("DirectorDelete")]
        public IActionResult DirectorDelete(int id)
        {
            var get = _directorRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Active = false;
                _directorRepository.UpdateById(get);
                return Ok(get);
            }
        }
    }
}
