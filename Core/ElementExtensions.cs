using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ElementExtensions
    {
        public static bool Beats(this Element element1, Element element2)
        {
            if (element1 == Element.Rock && element2 == Element.Scissors)
            {
                return true;
            }
            if (element1 == Element.Scissors && element2 == Element.Paper)
            {
                return true;
            }
            if (element1 == Element.Paper && element2 == Element.Rock)
            {
                return true;
            }
            return false;
        }
    }
}
