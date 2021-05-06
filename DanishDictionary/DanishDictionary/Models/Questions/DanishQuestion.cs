using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models.Questions
{
    class DanishQuestion : IQuestion
    {
        public Word BaseWord { get; set; }

        public string QuestionHeader => "Napíšte slovo po dánsky";

        public string QuestionText => BaseWord.Slovak;
    }
}
