using DanishDictionary.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DanishDictionary.ViewModels
{
    [QueryProperty(nameof(WordID), nameof(WordID))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _wordID;
        private string _danishText;
        private string _slovakText;
        private Articles _article;
        private string _plural;
        public string Id { get; set; }

        public string DanishText
        {
            get => _danishText;
            set => SetProperty(ref _danishText, value);
        }

        public string SlovakText
        {
            get => _slovakText;
            set => SetProperty(ref _slovakText, value);
        }

        public string Plural
        {
            get => _plural;
            set => SetProperty(ref _plural, value);
        }

        public Articles Article 
        {
            get => _article;
            set => SetProperty(ref _article, value);
        }

        public string WordID
        {
            get
            {
                return _wordID;
            }
            set
            {
                _wordID = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string wordID)
        {
            try
            {
                var item = await DataStore.GetItemAsync(wordID);
                Id = item.ID;
                DanishText = item.Danish;
                SlovakText = item.Slovak;
                Article = item.Article;
                Plural = item.Plural;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
