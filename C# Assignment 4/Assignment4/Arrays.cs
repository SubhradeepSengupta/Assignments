using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Arrays
    {
        ArrayList wordsInDictionary = new ArrayList();
        string word;

        public void AddWords()
        {
            wordsInDictionary.Add("Boat");
            wordsInDictionary.Add("House");
            wordsInDictionary.Add("Cat");
            wordsInDictionary.Add("River");
            wordsInDictionary.Add("Cupboard");

            //Console.WriteLine("The Words are : " + wordsInDictionary[0] + " " + wordsInDictionary[1] + " " + wordsInDictionary[2] + " " + wordsInDictionary[3] + " " + wordsInDictionary[4]);
        }

        public void WordPlurals()
        {
            for (int i = 0; i < wordsInDictionary.Count; i++)
            {
                wordsInDictionary[i] = wordsInDictionary[i] + "s";
            }
           Console.WriteLine("The Words are : " + wordsInDictionary[0] + " " + wordsInDictionary[1] + " " + wordsInDictionary[2] + " " + wordsInDictionary[3] + " " + wordsInDictionary[4]);
        }

        public void ReplaceWithSynonym()
        {
            string newname = (string)wordsInDictionary[1];
            newname = newname.Replace("Houses", "Residence");
            wordsInDictionary[1] = newname;
            Console.WriteLine();
            Console.WriteLine("The second word after replacement : " + wordsInDictionary[1]);
        }

        public void AddNewWord()
        {
            wordsInDictionary.Add("Puzzles");
            Console.WriteLine();
            Console.WriteLine("The length of the list after adding a new word : " + wordsInDictionary.Count);
            Console.WriteLine();
        }

        public void LengthEqualsSeven()
        {
            for (int i = 0; i < wordsInDictionary.Count; i++)
            {
                word = wordsInDictionary[i].ToString();
                if (word.Length == 7)
                    Console.WriteLine("Word with length equal to 7 : " + word);
            }
        }

        public void WordOnThirdPosition()
        {
            Console.WriteLine();
            Console.WriteLine("The word on 3rd position is : " + wordsInDictionary[2]);
        }

        public void Sort()
        {
            wordsInDictionary.Sort();
            Console.WriteLine();
            Console.WriteLine("Sorted Array : ");
            foreach (var word in wordsInDictionary)
            {
                Console.WriteLine(word);
            }
        }

        public void Reverse()
        {
            wordsInDictionary.Reverse();
            Console.WriteLine();
            Console.WriteLine("Reversed Array (Reverse of Ascending Array) : ");
            foreach (var word in wordsInDictionary)
            {
                Console.WriteLine(word);
            }
        }
    }
}
