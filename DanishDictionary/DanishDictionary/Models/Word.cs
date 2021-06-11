using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanishDictionary.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public WordTypes WordType { get; set; } = WordTypes.Noun;
        [NotNull]
        public string Danish { get; set; }
        [NotNull]
        public string Slovak { get; set; }
        [NotNull]
        public string Plural { get; set; }
        [NotNull]
        public Articles Article { get; set; }
    }

    public enum Articles
    {
        En,
        Et
    }

    public enum WordTypes
    {
        Noun,
        Adjective,
        Pronoun,
        Numeral,
        Verb,
        Adverb,
        Preposition,
        Conjunction,
        Interjection
    }
}
