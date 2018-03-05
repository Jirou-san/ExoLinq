using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataO.EF
{
    public sealed class Word
    {


        private int _i;
        private string _mot; 
        
        public Word(int i, string word)
        {
            I = i;
            Mot = word;
        }

        public int I { get => _i; set => _i = value; }
        public string Mot { get => _mot; set => _mot = value; }
    }
}
