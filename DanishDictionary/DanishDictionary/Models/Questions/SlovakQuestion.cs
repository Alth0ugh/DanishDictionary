using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class SlovakQuestion : IQuestion
    {
        public Word BaseWord { get; set; }

        public string QuestionHeader => "Napíšte slovo po slovensky";

        public string QuestionText => BaseWord.Danish;
    }
}
