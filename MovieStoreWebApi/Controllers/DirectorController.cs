using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.ModelsDirector.Request;
using MovieStoreWebApi.Models.ModelsDirector.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IGenericRepository<Director> _directorRepository;
        private readonly IValidator<DirectorRequestVM> _directorRequestVMValidator;
        public DirectorController(IGenericRepository<Director> directorRepository, IValidator<DirectorRequestVM> directorRequestVMValidator)
        {
            _directorRepository = directorRepository;
            _directorRequestVMValidator = directorRequestVMValidator;
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
            var validateResult = _directorRequestVMValidator.Validate(model);
            var messages = new List<string>();
            if (validateResult.IsValid)
            {
                _directorRepository.AddT(directorVm);
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
            var resultValidation = _directorRequestVMValidator.Validate(model);
            var messages = new List<string>();
            if (resultValidation.IsValid)
            {
                _directorRepository.UpdateById(get);
                var result = _directorRepository.GetById(id);
                DirectorResponseVM vm = new DirectorResponseVM
                {
                    Active = result.Active,
                    Id = result.Id,
                    Name = result.Name,
                    Surname = result.Surname,
                };
                messages.Add("Başarılı");
                return Ok(messages);
            }
            else
            {
                foreach (var item in resultValidation.Errors)
                {
                    messages.Add(item.ErrorMessage);
                }
                return BadRequest(messages);
            }
           
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
