using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace WizKids
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            //Task 1
            Console.WriteLine(IsPalindrome("rejer"));

            //Task 2
            PrintNumbers();

            //Task 3
            Console.WriteLine(ReplaceEmail(
                "Christian has the email address christian+123@gmail.com. Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com. John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk. Her Twitter handle is @kira.cavebrown.",
                "[email]"));

            //Task 4a
            foreach (string word in GetAlternativeWords("test"))
            {
                Console.WriteLine(word);
            }

            //Task 4b
            Console.WriteLine(MaxCombinations("test"));

            Console.Read();
        }

        //Task 1
        public Boolean IsPalindrome(string palindrome)
        {
            for (int i = 0; i < palindrome.Length; i++)
            {
                if (palindrome.ElementAt(i) != palindrome.ElementAt(palindrome.Length - i - 1))
                {
                    return false;
                }
            }

            return true;
        }

        //Task 2
        public void PrintNumbers()
        {
            for (int i = 1; i < 100; i++)
            {
                string printText = i + "";

                if (i % 3 == 0)
                {
                    printText = "Foo";
                }

                if (i % 5 == 0)
                {
                    printText = "Bar";
                }

                if (i % 3 == 0 && i % 5 == 0)
                {
                    printText = "FooBar";
                }

                Console.WriteLine(printText);
            }
        }

        //Task 3
        public string ReplaceEmail(string text, string replaceText)
        {
            string[] words = text.Split(' ');
            string returnText = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (IsEmail(words[i]))
                {
                    words[i] = replaceText;
                }

                returnText += words[i];
                if (i != words.Length - 1)
                {
                    returnText += " ";
                }
            }

            return returnText;
        }

        public Boolean IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //Task 4a
        public HashSet<String> GetAlternativeWords(string text)
        {
            HashSet<String> alternateWords = new HashSet<String>();
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            for (int i = 0; i < text.Length; i++)
            {
                //REMOVING A LETTER
                alternateWords.Add(text.Remove(i, 1));

                foreach (String c in alphabet)
                {
                    //INSERTING A LETTER
                    alternateWords.Add(text.Insert(i, c));

                    //INSERTING LETTER AS THE LAST
                    if (i == text.Length - 1)
                    {
                        alternateWords.Add(text.Insert(i + 1, c));
                    }

                    //REPLACING A LETTER
                    alternateWords.Add(text.Remove(i, 1).Insert(i, c));
                }

                //SWAPPING TWO LETTERS
                if (i != text.Length - 1)
                {
                    char[] swappedWord = text.ToArray();
                    var buffer = swappedWord[i];
                    swappedWord[i] = swappedWord[i + 1];
                    swappedWord[i + 1] = buffer;
                    alternateWords.Add(new String(swappedWord));
                }
            }
            
            return alternateWords;
        }

        //Task 4b (does not account for swapping identical letters)
        public int MaxCombinations(string word)
        {
            int uniqueCombinations = 0;

            //word length
            int wl = word.Length;

            //alphabet length
            int al = 26;

            //removing a letter
            uniqueCombinations += wl;

            //inserting letters
            uniqueCombinations += (wl + 1) * al;

            //replacing a letter (- wl for replacing with the same letter)
            uniqueCombinations += wl * al - wl;

            //swapping two adjacent letters
            uniqueCombinations += (wl - 1);

            return uniqueCombinations;
        }
    }
}
