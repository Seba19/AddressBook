using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rekrutacja_contact.Controllers;
using rekrutacja_contact.Models;
using System.Web.Http.Results;
using System.Net;


namespace ContactTest
{
    /// <summary>
    /// Summary description for TestContactController
    /// </summary>
    [TestClass]
    public class TestContactController
    {[TestMethod]
        public void PostContact_ShouldReturnSameContact()
        {   var dbcontext = new TestStoreAppContext(); 
            var controller = new ContactsController(dbcontext);

            var item = GetDemoContact();

            var result =
                controller.PostContact(item) as CreatedAtRouteNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }

        [TestMethod]
        public void PutContact_ShouldReturnStatusCode()
        {
            var controller = new ContactsController(new TestStoreAppContext());

            var item = GetDemoContact();

            var result = controller.PutContact(item.Id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutContact_ShouldFail_WhenDifferentID()
        {
            var controller = new ContactsController(new TestStoreAppContext());

            var badresult = controller.PutContact(999, GetDemoContact());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetContact_ShouldReturnContactWithSameID()
        {
            var context = new TestStoreAppContext();
            context.Contacts.Add(GetDemoContact());

            var controller = new ContactsController(context);
            var result = controller.GetContact(4) as OkNegotiatedContentResult<Contact>;
                
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Content.Id);
        }

        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts()
        {
            TestStoreAppContext context = new TestStoreAppContext();
        
           context.Contacts.Add(new Contact
            {
                Id = 1,
                Name = "Jan",
                Surname = "Nowak", 
                City = "Warszawa", 
                HouseNumber = 12 , 
                Mail="wp@wp.pl", 
                PhoneNumber="764342313", 
                Street ="Warszawska"  });
           context.Contacts.Add(new Contact
            {
                Id = 2,
                Name = "Sebastian",
                Surname = "Langa", 
                City = "Kraków", 
                HouseNumber = 12 , 
                Mail="wp@wp.pl", 
                PhoneNumber="764342313", 
                Street ="Warszawska"});

           context.Contacts.Add(new Contact
            {
                Id = 3,
                Name = "Piotr",
                Surname = "Kowalski", 
                City = "Kraków", HouseNumber = 12 , 
                Mail="piotr@wp.pl", 
                PhoneNumber="764342313", 
                Street ="Warszawska"});
           context.Contacts.Add(new Contact
            {
                Id = 4,
                Name = "Adam",
                Surname = "Kowal",  
                City = "Warszawa", 
                HouseNumber = 12 , 
                Mail="wp@wp.pl", 
                PhoneNumber="764342313", 
                Street ="Warszawska"});
            var controller = new ContactsController(context);
            var result = controller.GetContacts() as TestContactDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Local.Count);
        }

        [TestMethod]
        public void DeleteContact_ShouldReturnOK()
        {
            var context = new TestStoreAppContext();
            var item = GetDemoContact();
            context.Contacts.Add(item);

            var controller = new ContactsController(context);
            var result = controller.DeleteContact(4) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Contact GetDemoContact()
        {
            return new Contact
            {
                Id = 4,
                Name = "Adam",
                Surname = "Kowal",
                City = "Warszawa",
                HouseNumber = 12,
                Mail = "wp@wp.pl",
                PhoneNumber = "764342313",
                Street = "Warszawska"
            };
        }
    }
    }

