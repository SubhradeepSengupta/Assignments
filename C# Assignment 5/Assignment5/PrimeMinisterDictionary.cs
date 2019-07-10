using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class PrimeMinisterDictionary
    {

        Dictionary<int, string> PrimeMinisters;

        public void DetailedDictionary()
        {
            PrimeMinisters = new Dictionary<int, string>()
            {
                {1998, "Atal Bihari Vajpayee"},
                {2014, "Narendra Modi"},
                {2004, "Manmohan Singh"},
            };
        }

        public void FindPM()
        {
            foreach (var pm in PrimeMinisters)
            {
                if (pm.Key == 2004)
                {
                    Console.WriteLine("Prime Minister of 2004 : " + pm.Value);
                    Console.WriteLine();
                }
            }
        }

        public void AddPM()
        {
            if (PrimeMinisters.Values.Contains("Narendra Modi"))
            {
                Console.WriteLine("Already exist");
                Console.WriteLine();
            }
            else
            {
                PrimeMinisters.Add(2014, "Narendra Modi");
            }

            Console.WriteLine("After Updation : ");
            foreach (var pm in PrimeMinisters)
            {
                Console.WriteLine(pm.Value);
            }
        }

        public void sort()
        {
            var keys = PrimeMinisters.Keys.ToList();
            keys.Sort();
            Console.WriteLine();
            Console.WriteLine("After sorting : ");
            foreach (var item in keys)
            {
                Console.WriteLine(item + " " +PrimeMinisters[item]);
            }
        }

    }
}
