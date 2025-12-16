using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice
{
    internal class ListTasks
    {
        public void ListMerge()
        {
            List<int> l1 = new List<int>() { 1, 2, 3 };
            List<int> l2 = new List<int>() { 2, 3, 4, 5 };

            List<int> merges = new List<int>();

            merges.AddRange(l1);
            merges.AddRange(l2);

            foreach (int item in merges)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            List <int> final = merges.Distinct().ToList(); ;

            foreach (int item in final)
            {
                Console.Write($"{item} ");
            }
        }

        
    }
}
