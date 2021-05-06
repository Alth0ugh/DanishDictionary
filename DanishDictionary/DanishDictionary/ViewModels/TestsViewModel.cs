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
        private CarouselPage basePage;
        public ObservableCollection<TestWordViewModel> WordPages { get; set; }
        public TestsViewModel(CarouselPage page)
        {
            basePage = page;
            WordPages = new ObservableCollection<TestWordViewModel>();
            InitTest();
        }

        public async void InitTest()
        {
            var conversion = int.TryParse(await basePage.DisplayPromptAsync("", "Zadajte počet slov v teste", keyboard: Keyboard.Numeric), out int result);
            if (!conversion)
            {
                return;
            }
            var words = new List<Word>(await DataStore.GetItemsAsync());
            Random rnd = new Random();
            var shuffledWords = words.OrderBy(i => rnd.Next()).ToList();

            for (int i = 0; i < result; i++)
            {
                var type = rnd.Next(0, 3);
                IQuestion question;
                switch(type)
                {
                    case 0:
                        question = new ArticleQuestion() { BaseWord = words[i] };
                        break;
                    case 1:
                        question = new DanishQuestion() { BaseWord = words[i] };
                        break;
                    case 2:
                        question = new SlovakQuestion() { BaseWord = words[i] };
                        break;
                    case 3:
                        question = new PluralQuestion() { BaseWord = words[i] };
                        break;
                    default:
                        await basePage.DisplayAlert("Chyba", "Nastala neočakávaná chyba", "OK");
                        return;
                }
                var newPage = new TestWordViewModel() { TestQuestion = new ArticleQuestion() { BaseWord = shuffledWords[i] } };
                WordPages.Add(newPage);
            }
        }
    }
}
