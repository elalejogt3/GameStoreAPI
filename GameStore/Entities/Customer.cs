using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }     
        public string Email { get; set; }
        public string Addresss { get; set; }
        public string Phone { get; set; }

        public string Lastname { get; set; }

    }
}
