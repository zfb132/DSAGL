using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp5app
{
    class SearchInDictionary
    {
        public static void Main()
        {
            Dictionary<string, string> tpbook = new Dictionary<string, string>();
            tpbook.Add("王红", "785386");
            tpbook.Add("张小虎", "684721");
            tpbook.Add("刘胜利", "1367899");
            tpbook.Add("李明", "678956");
            tpbook["王浩"] = "678912";
            foreach (KeyValuePair<string, string> kvp in tpbook)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\nRemove(\"王浩\")"); tpbook.Remove("王浩");
            if (!tpbook.ContainsKey("王浩"))
            {
                Console.WriteLine("Key \"王浩\" is not found.");
            }
        }
    }
}
