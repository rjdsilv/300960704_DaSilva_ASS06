using _300960704_DaSilva_ASS06.Exception;
using System;
using System.Collections.Generic;

namespace _300960704_DaSilva_ASS06
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveQuestion(ReadQuestion());
            Console.WriteLine("\nPress ENTER key to exit...");
            Console.Read();
        }
        private static void SolveQuestion(int question)
        {
            if (question == 1)
            {
                SolveQuestionOne();
            }
            else if (question == 2)
            {
                SolveQuestionTwo();
            }
            else
            {
                throw new InvalidQuestionException(string.Format("The question {0} is not a valid question!", question));
            }
        }

        private static void SolveQuestionOne()
        {
            Console.WriteLine("Enter the text you want to have the characters count: ");

            // Prints the text in reverse order using the stack.
            DisplayDictionary(ReadDictionary());
            Console.WriteLine("\n");
        }

        private static SortedDictionary<char, int> ReadDictionary()
        {
            var text = Console.ReadLine();
            var dict = new SortedDictionary<char, int>();
            foreach (char c in text)
            {
                var key = char.ToUpper(c);

                if (char.IsLetter(key))
                {
                    if (dict.ContainsKey(key))
                    {
                        ++dict[key];
                    }
                    else
                    {
                        dict.Add(key, 1);
                    }
                }
            }

            return dict;
        }

        private static void DisplayDictionary<K, V>(SortedDictionary<K, V> dictionary)
        {
            Console.WriteLine("\n######################################################################");
            Console.WriteLine($"Sorted dictionary contains:\n{"Key",-12}{"Value",-12}");

            // generate output for each key in the sorted dictionary
            // by iterating through the Keys property with a foreach statement
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"{key,-12}{dictionary[key],-12}");
            }
            Console.WriteLine($"\nsize: {dictionary.Count}");
        }

        private static void SolveQuestionTwo()
        {
            Console.WriteLine("\n######################################################################");
            Console.WriteLine($"Original LinkedList is:");

            var reverseListOfChars = new LinkedList<char>();
            foreach (char c in CreateLinkedList())
            {
                reverseListOfChars.AddFirst(c);
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n######################################################################");
            Console.WriteLine($"Reversed LinkedList is:");
            foreach (char c in reverseListOfChars)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }

        private static LinkedList<char> CreateLinkedList()
        {
            var listOfChars = new LinkedList<char>();
            listOfChars.AddLast('A');
            listOfChars.AddLast('B');
            listOfChars.AddLast('C');
            listOfChars.AddLast('D');
            listOfChars.AddLast('E');
            listOfChars.AddLast('F');
            listOfChars.AddLast('G');
            listOfChars.AddLast('H');
            listOfChars.AddLast('I');
            listOfChars.AddLast('J');
            return listOfChars;
        }

        private static int ReadQuestion()
        {
            Console.WriteLine("What question do you want to evaluate? Choose the number between () to select!");
            Console.WriteLine("\tQuestion (1) - Count letter occurrences or");
            Console.Write("\tQuestion (2) - Reverse characters list: ");

            int questionNumber = 0;
            do
            {
                string valueRead = Console.ReadLine();
                if (!int.TryParse(valueRead, out questionNumber))
                {
                    Console.Write(string.Format("The option '{0}' is not valid. Choose a valid question (1) or (2): ", valueRead));
                }
                else
                {
                    if (questionNumber != 1 && questionNumber != 2)
                    {
                        Console.Write(string.Format("The option '{0}' is not valid. Choose a valid question (1) or (2): ", questionNumber));
                    }
                }
            }
            while (questionNumber != 1 && questionNumber != 2);

            return questionNumber;
        }
    }
}
