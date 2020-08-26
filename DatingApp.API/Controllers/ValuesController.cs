using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly DataContext2 _context;

        //List<Val> person = new List<Val>();

        //public ValuesController(DataContext context)
        public ValuesController(
            DataContext2 context
            )
        {
            this._context = context;
            // person.Add(new Val());
            // person.Add(new Val {Name = "Di", ID = 3, DOB = "12122001"});
        }

        //test api
        //[Route("~/api/ahaha/[controller]")]
        [HttpGet]
        public IActionResult GetCustomer()
        {
            // using(var db in ){

            // }
            var customer = _context.Customer;
            return Ok(customer);
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomerByID(int id)
        {
            var customer = _context.Customer.Where(x => x.ID == id).FirstOrDefault();
            return Ok(customer);
        }

        //[Route("api/{action}/hi")]
        [HttpPost]
        public IActionResult PutCustomer([FromQuery] int id, [FromQuery] string name)
        {
            var customer = new Customer { Name = name };
            //test(customer);
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("PostClassifyCustomer")]
        public IActionResult PostClassifyCustomer([FromQuery] char group)
        {
            var groupp = new ClassifyCustomer
            {
                Customers = new List<Customer>
                {
                   new Customer {Name = "Duc1"},
                    new Customer { Name = "Duc2" },
                    new Customer { Name = "Duc3" },
                },
                Group = group
            }; 
            //test(customer);
            _context.ClassifyCustomer.Add(groupp);
            _context.SaveChanges();
            return Ok(groupp);
        }

        [HttpPost("RemoveRelation/{id}")]

        public IActionResult RemoveRelation(int id)
        {
            var group = _context.ClassifyCustomer.Where(q => q.ID == id).Include(b => b.Customers).FirstOrDefault();
            //foreach (var item in group.Customers)
            //{
            //    group.Customers.Remove(item);
            //}
            group.Customers.RemoveAll(q => q is Customer);
            _context.SaveChanges();                                                     
            return Ok(_context.Customer);
        }


        private void test(Customer a) {
            a.Name = a.Name + "abc";
        }
        //

        // GET api/values
        // [HttpGet]
        // public IActionResult GetValues()
        // {
        //     // throw new Exception("hey");
        //     var value = _context.Values.ToList();

        //     return Ok(value);
        // }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public IActionResult GetValues(int id)
        // {
        //     var value = _context.Values.FirstOrDefault(x => x.Id == id);

        //     return Ok(value);
        // }
        // GET api/values/

        // POST api/values
        [HttpPost("duc")]
        public IActionResult Posta([FromBody] str a)
        {
            return Ok(a.value);
        }

        [HttpPost("duc")]
        public IActionResult vu([FromBody] Customer a)
        {
            return Ok(a);
        }

        // PUT api/values/5
        [HttpPut("PutCustomer/{id}")]
        public IActionResult Put(int id, [FromQuery] string name, [FromQuery] int groupId)
        {
            var cus = _context.Customer.Where(x => x.ID == id);
            foreach (var customers in cus)
            {
                customers.Name = name;
                customers.GroupID = groupId;
            }
            //_context.Customer.RemoveRange(cus);
            //_context.Customer.AddRange(cus);
            _context.SaveChanges();
            return Ok(_context.Customer);
        }

        // DELETE api/values/5
        [HttpDelete("DeleteGroup/{id}")]
        public IActionResult Delete(int id)
        {
            var grDel = _context.ClassifyCustomer.Where(x => x.ID == id).ToList();
            _context.ClassifyCustomer.RemoveRange(grDel);
            _context.SaveChanges();
            return Ok(_context.Customer);
        }
    }
}
