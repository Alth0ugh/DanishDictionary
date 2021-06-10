using DanishDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models
{
    public interface IQuestion
    {
        Word BaseWord { get; set; }
        string QuestionHeader { get; }
        string QuestionText { get; }
        string QuestionAnswer { get; set; }
        bool IsAnswerCorrect { get; }
    }
}
