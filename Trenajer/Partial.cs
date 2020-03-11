using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trenajer
{
    partial class Word
    {
        public string GetWord
        {
            get
            {
                TrenajerEntities db = new TrenajerEntities();
                string word = string.Empty;
                foreach (var item in db.Words)
                {
                    if (ENWord==item.ENWord)
                    {
                        word = item.RUWord;
                    }
                }
                return word;
            }
        }
    }
}
