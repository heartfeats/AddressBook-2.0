using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Contact> allContacts = Contact.GetAll();
            return View(allContacts);
        }

        [HttpGet("/contact/create")]
        public ActionResult ContactCreate()
        {
            return View();
        }

        [HttpPost("/")]
        public ActionResult ContactNew()
        {
            Contact newContact = new Contact(Request.Form["contact-name"], Request.Form["contact-number"], Request.Form["contact-address"]);
            List<Contact> allContacts = Contact.GetAll();
            return View("ContactNew",newContact);
        }


        [HttpGet("/contact/{id}")]
        public ActionResult ContactDetails(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
        }

      //  [HttpGet("/allContacts")]
      //   public ActionResult AllContacts()
      //   {
      //       List<Contact> allContacts = Contact.GetAll();
      //       return View("Index", allContacts);
      //   }

        [HttpPost("/contact/clear")]
        public ActionResult ContactClear()
        {
            Contact.ClearAll();
            return View();
        }





























  }
}
