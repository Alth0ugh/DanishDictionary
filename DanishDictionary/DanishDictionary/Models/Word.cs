using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models
{
    public class Word
    {
        public string ID { get; }
        public string Danish { get; set; }
        public string Slovak { get; set; }
        public string Plural { get; set; }
        public Articles Article { get; set; }

        public Word(string id)
        {
            ID = id;
        }

    }

    public enum Articles
    {
        En,
        Et
    }
}
