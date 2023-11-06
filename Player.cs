using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    internal class Player
    {
        public string Name { get; set; }
        public Queue<Card> cards = new Queue<Card>();
        public Player(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name} [{cards.Count}]:";
        }
    }
}
