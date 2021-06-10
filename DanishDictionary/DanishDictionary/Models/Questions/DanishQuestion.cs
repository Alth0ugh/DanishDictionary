using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class DanishQuestion : IQuestion
    {
        private string _questionAnswer;
        public bool IsAnswerCorrect { get; private set; }
        public string QuestionAnswer 
        {
            get => _questionAnswer;
            set
            {
                _questionAnswer = value;
                CheckAnswer();
            }
        }
        public Word BaseWord { get; set; }

        public string QuestionHeader => "Napíšte slovo po dánsky";

        public string QuestionText => BaseWord.Slovak;

        private void CheckAnswer()
        {
            if (BaseWord == null || string.IsNullOrWhiteSpace(QuestionAnswer))
            {
                return;
            }

            if (BaseWord.Danish.ToLower() == QuestionAnswer)
            {
                IsAnswerCorrect = true;
            }
        }
    }
}
