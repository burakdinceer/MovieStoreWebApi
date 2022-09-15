using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.ModelsRole.Request;
using MovieStoreWebApi.ModelsRole.Response;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IValidator<RoleRequestVM> _roleRequestVMValidation;
        public RoleController(IGenericRepository<Role> roleRepository, IValidator<RoleRequestVM> roleRequestVMValidation)
        {
            _roleRepository = roleRepository;
            _roleRequestVMValidation = roleRequestVMValidation;
        }
        [HttpGet]
        [Route("RoleList")]
        public List<RoleResponseVM> RoleList()
        {
            var list = _roleRepository.GetList().Select(x => new RoleResponseVM
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Active = x.Active,
            }).Where(x => x.Active).ToList();
            return list;
        }

        [HttpGet]
        [Route("RoleGet")]
        public RoleResponseVM RoleGet(int id)
        {
            var get = _roleRepository.GetList().Where(x => x.Id == id).Select(x => new RoleResponseVM
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Active = x.Active,
            }).Where(x => x.Active).SingleOrDefault();
            return get;
        }

        [HttpPost]
        [Route("RoleAdd")]
        public IActionResult RoleAdd(RoleRequestVM model)
        {
            Role newRole = new Role
            {
                Name = model.Name,
                Surname = model.Surname
            };
            var resultValidation = _roleRequestVMValidation.Validate(model);
            var messages = new List<string>();
            if (resultValidation.IsValid)
            {
                _roleRepository.AddT(newRole);
                messages.Add("Başaralı");
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

        [HttpPut]
        [Route("RoleUpdate")]
        public IActionResult RoleUpdate(RoleRequestVM model, int id)
        {
            var get = _roleRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Name = model.Name;
                get.Surname = model.Surname;
            };
            var resultValidation = _roleRequestVMValidation.Validate(model);
            var messages = new List<string>();
            if (resultValidation.IsValid)
            {
                _roleRepository.UpdateById(get);
                var result = _roleRepository.GetById(id);
                RoleResponseVM vm = new RoleResponseVM
                {
                    Id = result.Id,
                    Name = result.Name,
                    Surname = result.Surname,
                    Active = result.Active
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
        [Route("RoleDelete")]
        public IActionResult RoleDelete(int id)
        {
            var get = _roleRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Active = false;
                var result = _roleRepository.UpdateById(get);
                return Ok(result);
            }
        }

    }
}
