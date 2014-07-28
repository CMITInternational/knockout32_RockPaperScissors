using Core;

namespace Api.Models
{
    public class GamePlayerViewModel
    {
        public string Name { get; set; }
        public Element ChosenElement { get; set; }
        public bool IsComputer { get; set; }
    }
}