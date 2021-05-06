using DanishDictionary.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DanishDictionary.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _danishText = "";
        private string _slovakText = "";
        private Articles _article;
        private string _plural = "";
        private int _id;
        public int Id 
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
                LoadItemId(value);
            }
        }

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

        public Word DetailWord { get; set; }

        public async void LoadItemId(int wordId)
        {
            var word = await DataStore.GetItemAsync(wordId);
            DanishText = word.Danish;
            SlovakText = word.Slovak;
            Article = word.Article;
            Plural = word.Plural;
        }
    }
}
