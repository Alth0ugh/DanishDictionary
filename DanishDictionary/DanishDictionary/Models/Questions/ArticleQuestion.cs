using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class ArticleQuestion : IQuestion
    {
        public Word BaseWord { get; set; }
        public string QuestionHeader => "Doplňte predložku";

        public string QuestionText => "? " + BaseWord.Danish;
    }
}
