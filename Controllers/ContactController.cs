﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs.SiteSide.Contact;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities.Contact;
using Resume.Domain.RepositoryInterface;
using Resume.Infrastructure.Dbcontext;
using Resume.Infrastructure.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController (IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactDTOs contactDTOs)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddNewContact(contactDTOs);
                return RedirectToAction("Index", "Home");
            }
            return View();
        } 
    }
}

