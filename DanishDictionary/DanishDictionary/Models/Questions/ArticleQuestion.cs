using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class ArticleQuestion : IQuestion
    {
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
        public bool IsAnswerCorrect { get; private set; }
        public string QuestionHeader => "Fill article";

        public string QuestionText => "? " + BaseWord.Danish;

        private void CheckAnswer()
        {
            if (string.IsNullOrWhiteSpace(QuestionAnswer) || BaseWord == null)
            {
                return;
            }
            if (QuestionAnswer.ToLower() == BaseWord.Article.ToString().ToLower())
            {
                IsAnswerCorrect = true;
            }
        }

    }
}
