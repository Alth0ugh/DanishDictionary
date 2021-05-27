using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using DanishDictionary.Views;
using DanishDictionary.Models.Questions;

namespace DanishDictionary.ViewModels
{
    class TestsViewModel : BaseViewModel
    {
        private CarouselPage _basePage;
        public ObservableCollection<TestWordViewModel> WordPages { get; set; }
        public TestsViewModel(CarouselPage page)
        {
            _basePage = page;
            WordPages = new ObservableCollection<TestWordViewModel>();
            InitTest();
        }

        public async void InitTest()
        {
            var conversion = int.TryParse(await _basePage.DisplayPromptAsync("", "Zadajte počet slov v teste", keyboard: Keyboard.Numeric), out int result);
            if (!conversion)
            {
                return;
            }
            var words = new List<Word>(await DataStore.GetItemsAsync());

            Random rnd = new Random();
            var shuffledWords = words.OrderBy(i => rnd.Next()).ToList();

            for (int i = 1; i <= result; i++)
            {
                var type = rnd.Next(0, 3);
                IQuestion question;
                var wordForQuestion = words[i % words.Count];
                switch (type)
                {
                    case 0:
                        question = new ArticleQuestion() { BaseWord = wordForQuestion };
                        break;
                    case 1:
                        question = new DanishQuestion() { BaseWord = wordForQuestion };
                        break;
                    case 2:
                        question = new SlovakQuestion() { BaseWord = wordForQuestion };
                        break;
                    case 3:
                        question = new PluralQuestion() { BaseWord = wordForQuestion };
                        break;
                    default:
                        await _basePage.DisplayAlert("Chyba", "Nastala neočakávaná chyba", "OK");
                        return;
                }
                var newPage = new TestWordViewModel() { TestQuestion = question };
                WordPages.Add(newPage);
            }
        }
    }
}
