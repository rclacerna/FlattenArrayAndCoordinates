using System;
using System.Collections.Generic;

namespace Flatten
{
    public class FlattenArray
    {
        public static void Main(string[] args)
        {
            var nestedList = new List<object>
                {1, new List<object> {2}, new List<object> {new List<object> {3, 4}, 5}};

            var values = string.Join(", ", Flatten(nestedList));
            Console.WriteLine("[{0}]", values);
        }

        public static List<object> Flatten(List<object> inputList)
        {
            var flatList = new List<object>();
            try
            {
                foreach (var value in inputList)

                    if (value is List<object>)
                        flatList.AddRange(Flatten((List<object>) value));

                    else flatList.Add(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return flatList;
        }
    }
}