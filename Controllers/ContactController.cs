using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.SiteSide.Contact;
using Resume.Domain.Entities.Contact;
using Resume.Domain.RepositoryInterface;
using Resume.Infrastructure.Dbcontext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository; 
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactDTOs contactDTOs)
        {
            Contact contact = new Contact()
            {
                FullName = contactDTOs.FullName,
                Email = contactDTOs.Email,
                Message = contactDTOs.Message
            };
            ContactLocation contactLocation = new ContactLocation()
            {

                Address = contactDTOs.Address
            };
            await _contactRepository.AddContactToDataBase(contact);
            await _contactRepository.AddLocationToDataBase(contactLocation);
            return View();
        } 
    }
}

