using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    internal class Game
    {
        //основная колода
        private Card[] desk;
        //список игроков
        public List<Player> players = new List<Player>();
        /// <summary>
        /// Количество игроков по умолчанию = 2
        /// </summary>
        public Game()
        {
            CreateDesk();
            SetCountPlayer(2);
        }
        /// <summary>
        /// Количество игроков должно быть больше 2, но не больше 36
        /// </summary>
        /// <param name="countPlayer">Количество игроков</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Game(int countPlayer)
        {
            CreateDesk();
            SetCountPlayer(countPlayer);
        }
        /// <summary>
        /// Количество игроков должно быть больше 2, но не больше кол-ва кар в колоде
        /// </summary>
        /// <param name="countPlayer">Количество игроков</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCountPlayer(int countPlayer)
        {
            if (countPlayer >= 2 && countPlayer <= Enum.GetNames(typeof(Suits)).Length * Enum.GetNames(typeof(Deck)).Length)
            {
                for (int i = 0; i < countPlayer; i++)
                {
                    players.Add(new Player($"Player_{1 + i}"));
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        //Заполнение основной колоды
        private void CreateDesk()
        {
            desk = new Card[Enum.GetNames(typeof(Suits)).Length * Enum.GetNames(typeof(Deck)).Length];
            int index = 0;
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Deck deck in Enum.GetValues(typeof(Deck)))
                {
                    desk[index++] = new Card(deck, suit);
                }
            }
        }
        //Перемешать основную колоду
        private void MixCard()
        {
            Random random = new Random();
            for (int i = desk.Length - 1; i >= 0; i--)
            {
                int j = random.Next(0, desk.Length - 1);
                var temp = desk[j];
                desk[j] = desk[i];
                desk[i] = temp;
            }
        }
        //Раздать карты
        private void HandeOutCards()
        {
            foreach (var p in players)
            {
                if (p.cards.Count > 0) p.cards.Clear();
            }
            int player = 0;
            int cardPlayer = desk.Length;
            while (cardPlayer % players.Count != 0) cardPlayer--;
            for (int i = 0; i < cardPlayer; i++)
            {
                players[player].cards.Enqueue(desk[i]);
                if (player == players.Count() - 1) player = 0;
                else player++;
            }
        }
        public string StartGame()
        {
            List<Card> gameDeck = new List<Card>();
            MixCard();
            HandeOutCards();
            Deck maxValue;
            int item=0;
            List<Player> playersInGame = players;
            while (playersInGame.Count>1)
            {
                for (int i = 0; i < playersInGame.Count; i++)
                {
                    Console.WriteLine(playersInGame[i].Name + $" [{playersInGame[i].cards.Count-1}]:");
                    Console.WriteLine(playersInGame[i].cards.Peek());
                    gameDeck.Add(playersInGame[i].cards.Dequeue());
                }
                maxValue = gameDeck.Max(value => value.Cards);
                for (int i = 0; i < gameDeck.Count; i++)
                {
                    if (gameDeck[i].Cards==maxValue)
                    {
                        item = i;
                        break;
                    }
                }
                foreach (var c in gameDeck)
                {
                    playersInGame[item].cards.Enqueue(c);
                }
                Console.WriteLine("\n" + playersInGame[item] + " won the round!\n");
                gameDeck.Clear();
                for (int i = playersInGame.Count-1; i >= 0; i--)
                {
                    if (playersInGame[i].cards.Count == 0)
                    {
                        playersInGame.RemoveAt(i);
                    }
                }
            }
            return playersInGame[0].ToString();
        }
    }
}
