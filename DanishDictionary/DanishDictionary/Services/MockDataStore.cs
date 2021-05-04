using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanishDictionary.Services
{
    public class MockDataStore : IDataStore<Word>
    {
        readonly List<Word> Words = new List<Word>();

        public MockDataStore()
        {
            Words.Add(new Word(Guid.NewGuid().ToString()) { Article = Articles.En, Danish = "a", Plural = "aer", Slovak = "a" });
        }
        public async Task<bool> AddItemAsync(Word word)
        {
            Words.Add(word);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Word item)
        {
            var oldItem = Words.Where((Word arg) => arg.ID == item.ID).FirstOrDefault();
            Words.Remove(oldItem);
            Words.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Words.Where((Word arg) => arg.ID == id).FirstOrDefault();
            Words.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Word> GetItemAsync(string id)
        {
            return await Task.FromResult(Words.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Word>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Words);
        }
    }
}