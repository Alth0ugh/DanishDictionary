using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class PluralQuestion : IQuestion
    {
        public Word BaseWord { get; set; }

        public string QuestionHeader => "Napíšte slovo v pluráli";

        public string QuestionText => BaseWord.Danish;
    }
}
