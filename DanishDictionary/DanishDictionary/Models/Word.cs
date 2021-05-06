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
}
