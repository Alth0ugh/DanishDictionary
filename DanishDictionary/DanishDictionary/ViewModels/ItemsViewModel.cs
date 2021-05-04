using DanishDictionary.Models;
using DanishDictionary.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DanishDictionary.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Word _selectedWord;

        public ObservableCollection<Word> Words { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Word> ItemTapped { get; }
        public Command DeleteWordCommand { get; }
        public Word SelectedWord 
        {
            get => _selectedWord;
            set
            {
                SetProperty(ref _selectedWord, value);
                OnItemSelected(value);
            }
        }

        public ItemsViewModel()
        {
            Title = "Slovník";
            Words = new ObservableCollection<Word>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            ItemTapped = new Command<Word>(OnItemSelected);
            DeleteWordCommand = new Command(DeleteWord);
            AddItemCommand = new Command(OnAddItem);
        }

        async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Words.Clear();
                var words = await DataStore.GetItemsAsync();
                var wordList = new List<Word>(words);
                wordList.Sort((w1, w2) => w1.Danish[0].CompareTo(w2.Danish[0]));
                foreach (var item in wordList)
                {
                    Words.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void DeleteWord(object obj)
        {
            if (!(obj is Word))
            {
                return;
            }
            var word = (Word)obj;
            Words.Remove(word);
            await DataStore.DeleteItemAsync(word.ID);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedWord = null;
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Word word)
        {
            if (word == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.WordID)}={word.ID}");
        }
    }
}