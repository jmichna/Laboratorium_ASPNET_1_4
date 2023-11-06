using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorium_3_App.Models
{
    public class MemoryContactService : BackgroundService, IContactService
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public MemoryContactService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var currentTime = _dateTimeProvider.GetDateTime();
                Console.WriteLine($"Current Time: {currentTime}");

                await Task.Delay(1000, stoppingToken);
            }
        }

        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();
        public void Add(Contact contact)
        {
            if (contact != null)
            {
                contact.Id = _items.Count + 1;
                contact.Created = _dateTimeProvider.GetDateTime();
                _items[contact.Id] = contact;
            }
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }
    }
}
