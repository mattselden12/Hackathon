using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
            while(true)
            {
                Console.WriteLine("Would You Like To Play Again? Y/N");
                string playagain = Console.ReadLine();
                if(playagain == "Y")
                {
                    Game();
                }
                else if(playagain == "N")
                {
                    System.Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Type Y or N!");
                }
            }
        }

        public static void Game()
        {
            Console.WriteLine("");
            Console.WriteLine("  GGGGGGGGGGGGGGGG      OOOOOOOOOOOOOOOO                        ,.");
            Console.WriteLine(" GGGGGGGGGGGGGGGGGG    OOOOOOOOOOOOOOOOOO                     ,-'.:\\");
            Console.WriteLine("GGGG            GGGG  OOOO            OOOO                 _/'.:'_:'`._    .-._");
            Console.WriteLine("GGG              GGG  OOO              OOO            _.-''        ```-`.,'.::.`-._");
            Console.WriteLine("GGG              GGG  OOO              OOO         _.'                    ``-..:.:.`-.");
            Console.WriteLine("GGG              GGG  OOO              OOO       ,'          ____               `-:.:,'      _..-'|");
            Console.WriteLine("GGG                   OOO              OOO     ,',.      >,''    ```--...___        `-.__..'':..  |");
            Console.WriteLine("GGG                   OOO              OOO    / <O >   \\  `.  ___....-----..``-...___      \\::.   |");
            Console.WriteLine("GGG                   OOO              OOO   /_' `'  /  >  /,'::::::._:.-'           ````-.-'- .-'|");
            Console.WriteLine("GGG         GGGGGGGG  OOO              OOO   ,-`'. ,' ,'  /  <:::._,'             __...--../::.   |");
            Console.WriteLine("GGG         GGGGGGGG  OOO              OOO   `.        _,'   `--''            _.''           `-.._|");
            Console.WriteLine("GGG              GGG  OOO              OOO     `''-..''_                   _.'.:`. ");
            Console.WriteLine("GGG              GGG  OOO              OOO              ``.  ..--....___.-' `:_.::/");
            Console.WriteLine("GGGG            GGGG  OOOO            OOOO                 \\ .:`.              `-.\\");
            Console.WriteLine(" GGGGGGGGGGGGGGGGGG    OOOOOOOOOOOOOOOOOO                   \\:::|");
            Console.WriteLine("  GGGGGGGGGGGGGGGG      OOOOOOOOOOOOOOOO                     \\_,'");
            //Make Players
            Console.WriteLine("");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Please enter your name: ");
            string PlayerName = Console.ReadLine();
            // string PlayerName = "Matt";
            Player HumanPlayer = new Player(PlayerName);
            System.Threading.Thread.Sleep(1000);
            Player AIPlayer = new Player("Bender");
            System.Threading.Thread.Sleep(1000);
            //Make and shuffle deck
            Deck ourDeck = new Deck();
            System.Threading.Thread.Sleep(1000);
            ourDeck.Shuffle();
            System.Threading.Thread.Sleep(1000);
            //Deal Cards
            for(var i=0; i<7; i++)
            {
                HumanPlayer.Draw(ref ourDeck);
                AIPlayer.Draw(ref ourDeck);
            }

            //start playing
            while(HumanPlayer.hand.Count>0 && AIPlayer.hand.Count>0 && ourDeck.cards.Count>0){
                // Print the contents of our Human hand list
                // Console.WriteLine("\nPlayer's Hand:");
                // foreach(var attr in HumanPlayer.hand)
                // {
                //     Console.WriteLine("{0} of {1}", attr.stringVal, attr.suit);
                // }
                Console.WriteLine(HumanPlayer.name + " has "+ HumanPlayer.stack + " stacks.");
                Console.WriteLine(AIPlayer.name + " has "+ AIPlayer.stack + " stacks.");
                Console.WriteLine("");
                string topcard = "";
                for(int i=0; i<HumanPlayer.hand.Count; i++)
                {
                    topcard+=" _";
                }
                topcard+= "_________";
                Console.WriteLine(topcard);
                string sidenum = "";
                for(int i=0; i<HumanPlayer.hand.Count; i++)
                {
                    if(HumanPlayer.hand[i].stringVal == "10")
                    {
                       sidenum+="|T"; 
                    }
                    else
                    {
                        sidenum+="|"+HumanPlayer.hand[i].stringVal[0];
                    }
                }
                sidenum+= "         |";
                Console.WriteLine(sidenum);
                string sidesuit = "";
                for(int i=0; i<HumanPlayer.hand.Count; i++)
                {
                    if(HumanPlayer.hand[i].suit == "Hearts")
                    {
                        sidesuit+="|+";
                    }
                    else if(HumanPlayer.hand[i].suit == "Clubs")
                    {
                        sidesuit+="|#";
                    }
                    else if(HumanPlayer.hand[i].suit == "Diamonds")
                    {
                        sidesuit+="|@";
                    }
                    else if(HumanPlayer.hand[i].suit == "Spades")
                    {
                        sidesuit+="|O";
                    }
                }
                sidesuit+= "         |";
                Console.WriteLine(sidesuit);
                string sidecard = "";
                for(int i=0; i<HumanPlayer.hand.Count; i++)
                {
                    sidecard = sidecard+"| ";
                }
                string sidecard2= sidecard+"         |";
                for(int i=0; i<3; i++)
                {
                    Console.WriteLine(sidecard2);
                }
                if(HumanPlayer.hand[HumanPlayer.hand.Count-1].suit == "Hearts")
                {
                    Console.WriteLine(sidecard+"        +|");
                }
                else if(HumanPlayer.hand[HumanPlayer.hand.Count-1].suit == "Clubs")
                {
                    Console.WriteLine(sidecard+"        #|");
                }
                else if(HumanPlayer.hand[HumanPlayer.hand.Count-1].suit == "Diamonds")
                {
                    Console.WriteLine(sidecard+"        @|");
                }
                else if(HumanPlayer.hand[HumanPlayer.hand.Count-1].suit == "Spades")
                {
                    Console.WriteLine(sidecard+"        O|");
                }
                Console.WriteLine(sidecard+"        "+HumanPlayer.hand[HumanPlayer.hand.Count-1].stringVal[0]+"|");
                Console.WriteLine("");


                // Print the contents of our AI hand list
                // Console.WriteLine("\nAI's Hand:");
                // foreach(var attr in AIPlayer.hand)
                // {
                //     Console.WriteLine("{0} of {1}", attr.stringVal, attr.suit);
                // }
                // Console.WriteLine(AIPlayer.name + " has "+ AIPlayer.stack + " stacks.");

                //Human portion of our game logic
                //ask AI for card
                Console.WriteLine("Which card would you like to check?");
                string Ask = Console.ReadLine();
                bool ValidAsk = false;
                //make sure the card is in HumanPlayer's hand.
                for(int i=0; i<HumanPlayer.hand.Count; i++)
                {
                    if(HumanPlayer.hand[i].stringVal==Ask)
                    {
                        ValidAsk = true;
                    }
                }
                if(ValidAsk == false)
                {
                    Console.WriteLine("You fuckin' cheater. Pick a valid card!");
                    continue;
                }
                else
                {
                    //check AI's hand for ask card.
                    Console.WriteLine($"{AIPlayer.name}, do you have any {Ask}'s?");
                    bool MatchFound = false;
                    for(int i=AIPlayer.hand.Count-1; i>=0; i--)
                    {
                        if(AIPlayer.hand[i].stringVal==Ask)
                        {
                            MatchFound = true;
                            HumanPlayer.hand.Add(AIPlayer.hand[i]);
                            AIPlayer.hand.RemoveAt(i);
                        }
                    }
                    //If no matches, go fish
                    System.Threading.Thread.Sleep(1000);
                    if(MatchFound == false)
                    {
                        Console.WriteLine("Go Fish!");
                        HumanPlayer.Draw(ref ourDeck);
                    }
                    else
                    {
                        Console.WriteLine($"Great guess {HumanPlayer.name}, here are my {Ask}'s");
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                ////Check player's hand and see if it contains any sets
                for(int k=0; k<HumanPlayer.hand.Count; k++)
                {
                    List<int> matches = new List<int>();
                    matches.Add(k);
                    for(int l=k+1; l<HumanPlayer.hand.Count; l++)
                    {
                        if(HumanPlayer.hand[k].stringVal == HumanPlayer.hand[l].stringVal)
                        {
                            matches.Add(l);
                            if(matches.Count == 4)
                            {
                                HumanPlayer.stack++;
                                for(int m=matches.Count-1; m>=0; m--)
                                {
                                    HumanPlayer.hand.RemoveAt(matches[m]);
                                }
                            }
                        }
                    }
                }
                //Human win condition
                if(HumanPlayer.stack == 2)
                {
                    Console.WriteLine("YOU WIN!");
                    return;
                }


                //AI portion of our game logic.
                //Choose which card would be best for AI to choose
                Dictionary<string, int> AICounts = new Dictionary<string, int>();
                for(var i=0; i<AIPlayer.hand.Count; i++)
                {
                    if(AICounts.ContainsKey(AIPlayer.hand[i].stringVal))
                    {
                        AICounts[AIPlayer.hand[i].stringVal]++;
                    }
                    else
                    {
                        AICounts[AIPlayer.hand[i].stringVal]=1;
                    }
                }
                string Max = "";
                int MaxCount = 0;
                string RunnerUp = "";
                int RunnerUpCount = 0;
                foreach(var entry in AICounts)
                {
                    if(AICounts[entry.Key]>MaxCount)
                    {
                        RunnerUp = Max;
                        RunnerUpCount = MaxCount;
                        Max = entry.Key;
                        MaxCount = entry.Value;
                    }
                    else if(AICounts[entry.Key]>RunnerUpCount)
                    {
                        RunnerUp = entry.Key;
                        RunnerUpCount = entry.Value;
                    }
                }
                Random rand = new Random();
                int randval = rand.Next(1,11);
                string RandstringVal = AIPlayer.hand[rand.Next(AIPlayer.hand.Count)].stringVal;
                String SelectedstringVal = "";
                if(randval<6){
                    SelectedstringVal = Max;
                }
                else if(randval>=6 && randval<9){
                    SelectedstringVal = RunnerUp;
                }
                else{
                    SelectedstringVal = RandstringVal;
                }
                //Check the humans hand to see if it has our randomly selected card
                bool AIMatchFound = false;
                Console.WriteLine($"{HumanPlayer.name}, do you have any {SelectedstringVal}'s?");
                for(int j=0; j<HumanPlayer.hand.Count; j++)
                {
                    if(HumanPlayer.hand[j].stringVal == SelectedstringVal)
                    {
                        AIMatchFound = true;
                        AIPlayer.hand.Add(HumanPlayer.hand[j]);
                        HumanPlayer.hand.RemoveAt(j);
                    }
                }
                //If no matches, go fish
                System.Threading.Thread.Sleep(1000);
                if(AIMatchFound == false)
                {
                    Console.WriteLine("Go Fish!");
                    AIPlayer.Draw(ref ourDeck);
                }
                else
                {
                    Console.WriteLine($"Great guess {AIPlayer.name}, here are my {SelectedstringVal}'s");
                }
                System.Threading.Thread.Sleep(1000);
                //check for AI sets
                for(int k=0; k<AIPlayer.hand.Count; k++)
                {
                    List<int> matches = new List<int>();
                    matches.Add(k);
                    for(int l=k+1; l<AIPlayer.hand.Count; l++)
                    {
                        if(AIPlayer.hand[k].stringVal == AIPlayer.hand[l].stringVal)
                        {
                            matches.Add(l);
                            if(matches.Count == 4)
                            {
                                AIPlayer.stack++;
                                for(int m=matches.Count-1; m>=0; m--)
                                {
                                    AIPlayer.hand.RemoveAt(matches[m]);
                                }
                            }
                        }
                    }
                }

                //AI Win Condition
                if(AIPlayer.stack == 2)
                {
                    Console.WriteLine("Wow you lost... You suck!");
                    return;
                }
            }
        }
    }
}