using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Number_Wars
{
    public class Startup
    {
        public static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }
        public static int GetCharacter(string card)
        {
            return card[card.Length - 1];
        }
        public static void Main()
        {
            Queue<string> firstDeck = new Queue<string>(Console.ReadLine().Split(' ').ToArray());
            Queue<string> secondDeck = new Queue<string>(Console.ReadLine().Split(' ').ToArray());

            bool gameOver = false;
            int turns = 0;

            while (turns < 1000000 && firstDeck.Count > 0 && secondDeck.Count > 0 && !gameOver)
            {
                turns++;

                string firstHand = firstDeck.Dequeue();
                string secondHand = secondDeck.Dequeue();

                int firstNumber = GetNumber(firstHand);
                int secondNumber = GetNumber(secondHand);

                int comparison = firstNumber.CompareTo(secondNumber);

                if (comparison == 1)
                {
                    firstDeck.Enqueue(firstHand);
                    firstDeck.Enqueue(secondHand);
                }
                else if (comparison == -1)
                {
                    secondDeck.Enqueue(secondHand);
                    secondDeck.Enqueue(firstHand);
                }
                else
                {
                    List<string> tempCards = new List<string>();
                    bool winner = false;

                    while (firstDeck.Count >= 3 && secondDeck.Count >= 3 && !winner)
                    {
                        int firstSum = 0;
                        int secondSum = 0;

                        for (int counter = 0; counter < 3; counter++)
                        {
                            string firstTemp = firstDeck.Dequeue();
                            string secondTemp = secondDeck.Dequeue();

                            firstSum += GetCharacter(firstTemp);
                            secondSum += GetCharacter(secondTemp);

                            tempCards.Add(firstTemp);
                            tempCards.Add(secondTemp);
                        }

                        int compare = firstSum.CompareTo(secondSum);

                        if (compare == 1)
                        {
                            AddCards(firstDeck, tempCards);
                            winner = true;
                        }
                        else if (compare == -1)
                        {
                            AddCards(secondDeck, tempCards);
                            winner = true;
                        }
                       
                    }

                    if (firstDeck.Count == 0 || secondDeck.Count == 0)
                    {
                        gameOver = true;
                    }
                }
            }
            int comparer = firstDeck.Count.CompareTo(secondDeck.Count);

            if (comparer == 1)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (comparer == -1)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }

        public static void AddCards(Queue<string> firstDeck, List<string> tempCards)
        {
            foreach (var card in tempCards.OrderByDescending(w => GetNumber(w)).ThenByDescending(w => GetCharacter(w)))
            {
                firstDeck.Enqueue(card);
            }
        }
       
    }
}
