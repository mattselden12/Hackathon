using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Deck
    {
        ////Give the Deck class a property called "cards" which is a list of Card objects.
        public List<Card> cards = new List<Card>();
        ////This list of card objects if for when we need to reset to our original deck
        public List<Card> cardsBackup = new List<Card>();

        public Deck()
        {
            ////Declaring arrays of card suits, string/integer values. (All values needed for our card objects)
            string[] suits = {"Hearts", "Spades", "Clubs", "Diamonds"};
            string[] stringValues = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            int[] integerValues = {1,2,3,4,5,6,7,8,9,10,11,12,13};
            ////Creates a card object for every possible value of each suite
            for(int i=0; i<suits.Length; i++)
            {
                for(int j=0; j<stringValues.Length; j++)
                {
                    Card card = new Card();
                    card.stringVal = stringValues[j];
                    card.val = integerValues[j];
                    card.suit = suits[i];
                    cards.Add(card);

                    cardsBackup.Add(card);
                }
                ////Prints the values of each object for debug help
                // foreach(var card in cards)
                // {
                    // Console.WriteLine("Str Value={0} - Value={1} - Suit={2}", card.stringVal, card.val, card.suit);
                // }
            }
            Console.WriteLine("Fresh deck of 52 cards created.");
        }

        ////Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card.
        public Card Deal()
        {
            ////Grabs a card, removes it from the list, then returns the card
            Card returnCard = cards[0];
            cards.RemoveAt(0);
            ////Console.WriteLine("DRAWNCARD: {0} {1} {2}", returnCard.stringVal, returnCard.val, returnCard.suit);
            return returnCard;
        }

        ////Give the Deck a reset method that resets the cards property to contain the original 52 cards.
        public void Reset()
        {
            ////iterates through the cards list and makes it equal to our backed up starting deck
            for(var i=0; i<cardsBackup.Count; i++)
            {
                if(i >= cards.Count)
                {
                    cards.Add(cardsBackup[i]);
                }
                else
                {
                cards.RemoveAt(i);
                cards.Insert(i, cardsBackup[i]);
                }
            }
            Console.WriteLine("Deck has been reset to it's original configuration.");
        }

        ////Give the Deck a shuffle method that randomly reorders the deck's cards.
        public void Shuffle()
        {
            ////Walks through the list and moves each index to a new random index
            Random rand = new Random();
            for(int i=0; i<cards.Count; i++)
            {
                Card temp = cards[i];
                cards.RemoveAt(i);
                cards.Insert(rand.Next(cards.Count), temp);
            }
            Console.WriteLine("Shuffling Deck...");
        }
    }
}
