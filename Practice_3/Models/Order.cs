using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Id_customer { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    }
}