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
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext2 _context;
        public ValuesController(DataContext2 context)
        {
            this._context = context;
        }
        // [AllowAnonymous]
        // [HttpGet]
        // public IActionResult GetCustomer()
        // {
        //     // var customer = _context.Customer;
        //     // return Ok(customer);
        // }
    }
}
