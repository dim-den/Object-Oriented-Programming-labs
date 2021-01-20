using System;
using System.Text;
using System.Collections.Generic;

namespace OOPLab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            User user1 = new User(1.1);
            user1.OnUpgrade += version => Console.WriteLine($"Software was updated to version {version}");

            user1.Upgrade(2.28);
            user1.OnWork += progress =>
            {
                if (progress <= 0) Console.WriteLine($"Something gone wrong. Progress {progress}%");
                else if (progress > 0) Console.WriteLine($"Well done. Progres +{progress}%");
            };
            user1.Work(rnd.Next(0, 50));
            user1.Work(rnd.Next(-20, 30));
            user1.Upgrade(3.11);

            string some_text = "A delegate is a type that represents references to methods with a particular parameter list and return type. When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. " +
                "You can invoke (or call) the method through the delegate instance. Delegates are used to pass methods as arguments to other methods.Event handlers are nothing more than methods that are invoked through delegates. " +
                "You create a custom method, and a class such as a windows control can call your method when a certain event occurs.The following example shows a delegate declaration:";
            Func<string, string> func = DeletePunctuation; 
            Action<Dictionary<string, int>> action = PrintResult;
           // Console.WriteLine(DeletePunctuation(some_text));
            GetWords(some_text, action, func);            
        }

        public static void GetWords(string text, Action<Dictionary<string, int>> action, Func<string,string> func)
        {
            Dictionary<string, int> word_count = new Dictionary<string, int>();
            text = ToLower(text);
            func?.Invoke(text);
            var words = SplitToWords(text);
            foreach(string element in words)
            {
                if (!word_count.ContainsKey(element)) word_count.Add(element, 1);
                else word_count[element]++;
            }
            action?.Invoke(word_count);
        }

        public static void PrintResult(Dictionary<string, int> dict)
        {
            Console.WriteLine(" ------------- Word count in text -----------------");
            foreach (var element in dict)
                Console.WriteLine(element);
        }
        public static string ToUpper(string text)
        {
            return text.ToUpper();
        }

        public static string ToLower(string text)
        {
            return text.ToLower();
        }

        public static string[] SplitToWords(string text)
        {
            return text.Split();
        }

        public static string DeletePunctuation(string text)
        {
            StringBuilder tempString = new StringBuilder(text);

            for (int i = (tempString.Length - 1); i >= 0; i--)
            {
                if (tempString[i] == ',' || tempString[i] == '.' || tempString[i] == '!' || tempString[i] == '?' || tempString[i] == '-' || tempString[i] == '.' || tempString[i] == ':' || tempString[i] == '(' || tempString[i] == ')')
                {
                    tempString.Remove(i,1);
                }
            }
            text = tempString.ToString();
            return text;
        }

    }
}

