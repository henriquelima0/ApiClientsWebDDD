using System;
using System.Collections.Generic;
using ApiClientsDDD.Domain.ValueObjects;

namespace ApiClientsDDD.Domain.Models
{
    public class Client : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        private readonly List<Address> _addresses = new List<Address>();

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public List<Address> Addresses { get; set; } = new List<Address>();

        public Client() { }

        public Client(string name, string email, int age, List<Address> addresses)
        {
            Name = name;
            Email = email;
            Age = age;
            _addresses = addresses ?? new List<Address>();
            RegistrationDate = DateTime.Now;
        }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void RemoveAddress(Address address)
        {
            _addresses.Remove(address);
        }
    }
}
