using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataO.EF
{
    public sealed class Word
    {


        private int _index;
        private string _mot;

        
        public Word(int index, string word)
        {
            Index = index;
            Mot = word;
        }

        public int Index { get => _index; set => _index = value; }
        public string Mot { get => _mot; set => _mot = value; }

    }
}
