using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using DanishDictionary.Views;
using DanishDictionary.Models.Questions;
using System.Windows.Input;

namespace DanishDictionary.ViewModels
{
    class TestsViewModel : BaseViewModel
    {
        private CarouselPage _basePage;
        public ObservableCollection<TestWordViewModel> WordPages { get; set; }
        public ICommand CheckAnswersCommand { get; set; }

        public TestsViewModel(CarouselPage page)
        {
            _basePage = page;
            WordPages = new ObservableCollection<TestWordViewModel>();
            CheckAnswersCommand = new Command(CheckAnswers);
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

        public void CheckAnswers()
        {
            var correctAnswers = 0;
            var wrongAnswers = 0;

            foreach (var item in WordPages)
            {
                if (item.TestQuestion == null)
                {
                    return;
                }
                if (item.TestQuestion.IsAnswerCorrect == true)
                {
                    correctAnswers++;
                }
                else
                {
                    wrongAnswers++;
                }    
            }
            _basePage.DisplayAlert("Výsledky:", $"Počet správnych odpovedí: {correctAnswers}\nPočet nesprávnych odpovedí: {wrongAnswers}", "OK");
            Shell.Current.GoToAsync("..");
        }
    }
}
