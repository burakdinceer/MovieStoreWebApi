using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.ModelsCustomer.Request;
using MovieStoreWebApi.ModelsCustomer.Response;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IValidator<CustomerRequestVm> _customerRequestVmValidator;
        public CustomerController(IGenericRepository<Customer> customerRepository, IValidator<CustomerRequestVm> customerRequestVmValidator)
        {
            _customerRepository = customerRepository;
            _customerRequestVmValidator = customerRequestVmValidator;
        }
        [HttpGet]
        [Route("CustomerList")]
        public List<CustomerResponseVM> CustomerList()
        {
            var list = _customerRepository.GetList().Select(x => new CustomerResponseVM
            {
                Name = x.Name,
                Surname = x.Surname,
                Id = x.Id,
                Active = x.Active
            }).Where(x => x.Active).ToList();
            return list;
        }
        [HttpPost]
        [Route("CustomerAdd")]
        public IActionResult CustomerAdd(CustomerRequestVm model)
        {
            Customer newCustomer = new Customer()
            {
                Name = model.Name,
                Surname = model.Surname,
            };
            var validateResult = _customerRequestVmValidator.Validate(model);
            var messages = new List<string>();
            if (validateResult.IsValid)
            {
                _customerRepository.AddT(newCustomer);
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
        [Route("CustomerDelete")]
        public IActionResult CustomerDelete(int id)
        {
            var get = _customerRepository.GetById(id);
            if (get == null)
                return BadRequest();
            else
            {
                get.Active = false;
                var result = _customerRepository.UpdateById(get);
                return Ok(result);
            }


        }
    }
}
