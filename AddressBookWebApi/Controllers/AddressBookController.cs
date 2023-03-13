using AddressBook.Domain.Interfaces;
using AddressBook.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {

        private IContactServices _service;
        public AddressBookController(IContactServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Get()
        {
            return Ok(_service.GetContacts());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public void Post([FromBody] UserContact obj)
        {
            _service.AddContact(obj);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public void Update([FromBody] UserContact obj,int id)
        {
            _service.UpdateContact(obj,id);
        }

        [HttpDelete("{id}")]

        [Authorize(Roles = "Admin")]
        public void Delete(int id) {
            _service.DeleteContact(id);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetContact(id));
        }
    }

}
