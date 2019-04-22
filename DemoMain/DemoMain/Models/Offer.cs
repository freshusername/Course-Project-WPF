using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMain.Models
{
    class Offer
    {
        private float price;

        public string Owner { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public float Price { get => price - price * Discount / 100; private set => price = value; }

        public int Discount { get; set; }

        // Constructor
        public Offer(string owner, string email, string phoneNumber, float price)
        {
            Owner = owner;
            Email = email;
            PhoneNumber = phoneNumber;
            this.price = price;
        }
    }
}
