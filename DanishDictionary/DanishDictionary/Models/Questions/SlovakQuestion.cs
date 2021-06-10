using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class SlovakQuestion : IQuestion
    {
        public bool IsAnswerCorrect { get; private set; }
        private string _questionAnswer;
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

        public string QuestionHeader => "Napíšte slovo po slovensky";

        public string QuestionText => BaseWord.Danish;

        private void CheckAnswer()
        {
            if (BaseWord == null || string.IsNullOrWhiteSpace(QuestionAnswer))
            {
                return;
            }
            
            if (BaseWord.Slovak == QuestionAnswer)
            {
                IsAnswerCorrect = true;
            }
        }

    }
}
