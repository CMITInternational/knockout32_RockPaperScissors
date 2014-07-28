using System;

namespace Core
{
    public class GamePlayer
    {
        public GamePlayer(string name, Element chosenElement, bool isComputer)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
            ChosenElement = chosenElement;
            IsComputer = isComputer;
        }

        public string Name { get; private set; }

        public Element ChosenElement { get; private set; }

        public bool IsComputer { get; private set; }
    }
}
