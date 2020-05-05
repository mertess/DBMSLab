using ORMEnitityFramework;
using ORMEnitityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLab5.Logic
{
    public class ClientService : ICrud<Client>
    {
        public void Create(Client model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.FullName == model.FullName);
                if (client != null)
                    throw new Exception("Такой клиент уже есть!");
                context.Clients.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Client model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.FullName == model.FullName);
                if (client == null)
                    throw new Exception("Такого клиента нет!");
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        public List<Client> FindAll()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Clients.ToList();
            }
        }

        public List<Client> FindAll(int offset, int count)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Clients.Skip(offset).Take(count).ToList();
            }
        }

        public Client Get(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Clients.FirstOrDefault(a => a.Id == id);
            }
        }

        public void Update(Client model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var client = context.Clients.FirstOrDefault(a => a.Id == model.Id);
                if (client == null)
                    throw new Exception("Такого клиента нет!");
                client.FullName = model.FullName;
                client.PhoneNumber = model.PhoneNumber;
                context.SaveChanges();
            }
        }

        public List<Client> GetByPhoneNumber(string PhoneNumber)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Clients.Where(c => c.PhoneNumber.Equals(PhoneNumber)).ToList();
            }
        }
    }
}
