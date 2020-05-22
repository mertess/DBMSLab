using ORMEnitityFramework;
using ORMEnitityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ORMLab5.Logic
{
    public class ClientService : ICrud<Client>
    {
        private readonly DatabaseContext context;

        public ClientService(DatabaseContext databaseContext)
        {
            this.context = databaseContext;
        }

        public void Create(Client model)
        {
            var client = context.Clients.FirstOrDefault(c => c.FullName == model.FullName);
            if (client != null)
                throw new Exception("Такой клиент уже есть!");
            context.Clients.Add(model);
            context.SaveChanges();
        }

        public void Delete(Client model)
        {
            var client = context.Clients.FirstOrDefault(c => c.FullName == model.FullName);
            if (client == null)
                throw new Exception("Такого клиента нет!");
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public List<Client> FindAll()
        {
            return context.Clients.ToList();
        }

        public List<Client> FindAll(int offset, int count)
        {
            return context.Clients.Skip(offset).Take(count).ToList();
        }

        public Client Get(int id)
        {
            return context.Clients.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Client model)
        {
            var client = context.Clients.FirstOrDefault(a => a.Id == model.Id);
            if (client == null)
                throw new Exception("Такого клиента нет!");
            client.FullName = model.FullName;
            client.PhoneNumber = model.PhoneNumber;
            context.SaveChanges();
        }

        public List<Client> GetByPhoneNumber(string PhoneNumber)
        {
            return context.Clients.Where(c => c.PhoneNumber.Equals(PhoneNumber)).ToList();
        }
    }
}
