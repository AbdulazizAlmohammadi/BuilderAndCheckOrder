using System;
using System.Collections;

namespace BuilderAndCheckOrder
{
    class Program
    {

        class FirebaseBuilder
        {
            public string colDoc;
            public string condition;

            public FirebaseBuilder collection(string value)
            {
                this.colDoc = value;
                return this;
            }
            public FirebaseBuilder where(string value)
            {
                this.condition = value;
                return this;
            }
            public string get()
            {
                string result = $"Select {this.colDoc} where {condition}";
                return result;
            }
        }
        static bool checkOrder(string source)
        {
            Stack openStack = new Stack();
            int i = 0;
            char temp;
            while (i < source.Length)
            {
                if (openStack.Count == 0)
                {
                    openStack.Push(source[i]);
                    i++;
                    continue;
                }

                temp = (char)openStack.Peek();

                if (source[i] == temp)
                {
                    openStack.Pop();
                }
                else if (source[i] != temp)
                {
                    openStack.Push(source[i]);
                }
                i++;
            }

            return openStack.Count == 0;
        }
        static void Main(string[] args)
        {
            FirebaseBuilder fb = new FirebaseBuilder();
            String query = fb.collection("students").where("grade = 100").get();

            Console.WriteLine(query);

            Console.WriteLine(checkOrder("311223"));
        }
    }
}
