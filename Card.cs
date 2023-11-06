using System;

namespace Cards
{
    internal class Card
    {
        //значение карты
        private Deck сards;
        //масть карты
        private Suits suit;
        public Deck Cards
        { 
            get { return сards; }
            set
            {
                сards = value;
                switch (сards)
                {
                    case Deck.JAK:
                        TypeCard = "В";
                        break;
                    case Deck.QUEEN:
                        TypeCard = "Д";
                        break;
                    case Deck.KING:
                        TypeCard = "К";
                        break;
                    case Deck.ACE:
                        TypeCard = "Т";
                        break;
                    default:
                        TypeCard = ((int)сards).ToString(); break;
                }
            }
        }
        public Suits Suit
        { 
            get { return suit; }
            set
            {
                suit= value;
                switch (value)
                {
                    case Suits.HEARTS:
                        CharSuit = '\u2665';
                        break;
                    case Suits.SPADES:
                        CharSuit = '\u2660';
                        break;
                    case Suits.DIAMONDS:
                        CharSuit = '\u2666';
                        break;
                    case Suits.CLUBS:
                        CharSuit = '\u2663';
                        break;
                }
            }
        }
        //значение для отображения номера карты
        private char CharSuit { get; set; }
        //значение для отображения масти карты
        private string TypeCard { get; set; }
        public Card(Deck idCard, Suits suit)
        {
            Cards= idCard;
            Suit= suit;
        }
        public override string ToString()
        {
            if (Cards!=Deck.TEN)
            {
                return
                     "-----\n" +
                    $"|{TypeCard}{CharSuit} |\n" +
                     "|   |\n" +
                    $"| {TypeCard}{CharSuit}|\n" +
                     "-----";
            }
                return
                     "-----\n" +
                    $"|{TypeCard}{CharSuit}|\n" +
                     "|   |\n" +
                    $"|{TypeCard}{CharSuit}|\n" +
                     "-----";
        }

    }
}
