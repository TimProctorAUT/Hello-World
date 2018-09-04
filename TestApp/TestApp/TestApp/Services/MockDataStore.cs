using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe One", Description="This is an recipe description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe Two", Description="This is an recipe description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe Three", Description="This is an recipe description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe Four", Description="This is an recipe description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe Five", Description="This is an recipe description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Recipe Six", Description="This is an recipe description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}