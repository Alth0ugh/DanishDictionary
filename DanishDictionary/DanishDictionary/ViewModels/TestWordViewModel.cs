using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.ViewModels
{
    class TestWordViewModel : BaseViewModel
    {
        public IQuestion TestQuestion { get; set; }
        public int ID { get; set; }
    }
}
