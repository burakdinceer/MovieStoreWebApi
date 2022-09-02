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

        public CustomerController(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
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
            var create = _customerRepository.AddT(newCustomer);
            if (create == null)
                return BadRequest();
            else
            {
                return Ok(create);
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
