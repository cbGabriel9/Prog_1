using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }

        public bool Validate()
        {
            return true;
        }

        public Order Retrieve()
        {
            return new Order();
        }

        public void Save(Order order)
        {

        }

    }
}
