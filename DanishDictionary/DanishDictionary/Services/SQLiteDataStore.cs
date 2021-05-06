using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace DanishDictionary.Services
{
    public class SQLiteDataStore : IDataStore<Word>
    {
        private static SQLiteAsyncConnection _dbConnection;

        public SQLiteDataStore()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteAsyncConnection(FileSystem.AppDataDirectory + "data.db");
                _dbConnection.CreateTableAsync<Word>().Wait();
            }
        }
        public async Task<bool> AddItemAsync(Word word)
        {
            var rows = await _dbConnection.InsertAsync(word);
            if (rows == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateItemAsync(Word item)
        {
            var rows = await _dbConnection.UpdateAsync(item);

            if (rows == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteItemAsync(Word item)
        {
            var rows = await _dbConnection.DeleteAsync(item);
            if (rows == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Word> GetItemAsync(int itemID)
        {
            return await _dbConnection.GetAsync<Word>(itemID);
        }

        public async Task<IEnumerable<Word>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _dbConnection.Table<Word>().ToArrayAsync();
        }
    }
}