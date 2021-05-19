using GameStore.Contexts;
using GameStore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    //api/customers

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        //constructor
        public CustomersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //get funtion
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return context.Customers.ToList();
        }

        [HttpGet("{id}", Name="getCustomer")]
        public ActionResult<Customer> Get(int id)
        {
            var customers = context.Customers.FirstOrDefault(x => x.Id == id);
            if(customers == null)
            {
                return NotFound();
            }
            return customers;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return new CreatedAtRouteResult("getCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            return customer;
        }




        //post function


        //put funtion


        //delete function



    }
}
