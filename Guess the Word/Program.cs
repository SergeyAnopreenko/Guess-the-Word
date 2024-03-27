﻿
using System.Diagnostics.Metrics;

namespace GuessWord
{
    class GuessWord
    {
        static int Scores(int score)
        {
           

            return score;
        }

        static int ReadWordsFromFile(string[] words)
        {
            string filename = "words_input.txt";

            if (System.IO.File.Exists(filename) == false)

                return -1;

            System.IO.StreamReader s = new System.IO.StreamReader(filename);

            int count = 0;

            for (int i = 0; i < 100; i++)
            {
                if (s.EndOfStream == true)

                    break;

                words[count++] = s.ReadLine();
            }

            s.Close();

            return count;
        }

        static void ContinueGame(string comand)
        {
            Console.WriteLine("Would you like to continue? Press 'C', for exit press 'ENTER'");

            comand = Console.ReadLine();

            comand.ToLower();

            if (comand is "c")
            {
                Main([comand]);
            }
             else

            Console.WriteLine("Try again");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guess a Word\n");

            string[] words = new string[100];

            int count = ReadWordsFromFile(words);

            if (count < 0)
            {
                Console.WriteLine("No words found in the file");

                return;
            }

            if (words == null)

                return; // Exception message was already shown

            Random r = new Random();

            int guessX = (int)(r.Next(count));

            String secretWord = words[guessX];

            int numChars = secretWord.Length;

            Console.Write("Your secret word is: \n");

            for (int i = 0; i < numChars; i++)

                Console.Write("*");

            Console.WriteLine();

            bool bGuessedCorrectly = false;

            Console.WriteLine("Guess now  (To stop the program, enter #) : \n");

            Console.WriteLine("Try to guess first letter");
            while (true)
            {
                string choice = Console.ReadLine();

                if (choice.StartsWith("#"))

                    break;

                if (choice.CompareTo(secretWord) == 0)
                {
                    bGuessedCorrectly = true;

                    break;
                }

                for (int j = 0; j < numChars; j++)
                {
                    int k = -1;
                    
                    if (choice.Length > 0) ;
                    
                    k = k + choice.Length;
                    
                    j = k;           

                    {
                        if (secretWord[j] == choice[k])
                           
                            Console.WriteLine("You are guess the letter, you earn + 10 point");
                        
                        if (secretWord[j] > choice[k])
                            
                            Console.WriteLine("You are shoud find it lower ");

                        if (secretWord[j] < choice[k])
                            
                            Console.WriteLine("You are shoud find it high ");
                    }
                    if (choice[k] < numChars)
                    {
                        k++;
                    }
                   break;
                }

                    for (int i = 0; i < numChars; i++)
                    {
                        if (i < secretWord.Length &&  i < choice.Length)
                        {
                            if (secretWord[i] == choice[i])

                                Console.Write(choice[i]);

                            else
                                
                                Console.Write("*");
                        }

                        else

                            Console.Write("*");
                    }

                    Console.WriteLine();                
            }

            int scr = Scores(secretWord.Length * 10);

            if (bGuessedCorrectly == false)
            
                Console.WriteLine("Unfortunately you did not guess it correctly. The secret word is: " + secretWord);
            
            else

                Console.WriteLine("Congrats! You have guessed it correctly! Your score is: " + (scr ));

            ContinueGame(secretWord);            
        }
    }  
}