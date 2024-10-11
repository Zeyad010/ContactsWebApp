﻿using ContactsWebApp.Data;
using ContactsWebApp.Models;
using ContactsWebApp.Models.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CDbContext _dbContext;

        public ContactsController(CDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
           var contacts = _dbContext.TbContacts.ToList();

            return Ok(contacts);
        }


        [HttpPost]

        public IActionResult AddContact(AddContactRequestDTO  request)
        {
            var domainModelContact = new ContactM
            {

                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Favorite = request.Favorite



            };

            _dbContext.TbContacts.Add(domainModelContact);  
            _dbContext.SaveChanges();

            return Created();

        }

    }
}