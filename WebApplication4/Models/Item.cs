using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication4.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public String Borrower { get; set; }
        public String Lender { get; set; }

        [DisplayName("Item Name")]  
        public String ItemName { get; set; }
        

    }
}
