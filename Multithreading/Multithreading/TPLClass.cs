using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public class TPLClass
    {
        public static void TestUri()
        {
            Console.WriteLine("Employee Payroll using Threads");
            string[] words = CreateWordArray (@"http://www.gutenberg.org/files/54700/54700-0.txt");
            Parallel.Invoke(() =>
            {
                //Console.WriteLine("Begin first task..");
                GetLongestWords(words);
            },
            () =>
            {
                //Console.WriteLine("Begin first task..");
                GetMostCommonWords(words);
            },
            () =>
            {
                //Console.WriteLine("Begin second task..");
                GetCountWords(words,"sleep");
            }
            );//close parallel invoke
        }
        private static void GetCountWords(string[] words,string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine("\nTask 3--- the word" + term + "occurs" + (findWord.Count()) + "times");
        }
        private static void GetLongestWords(string[] words)
        {
            var longestWord = (from word in words
                               orderby word.Length descending
                               select word);
            var commonWords = longestWord.Take(10);
            //stringBuilder sb= new StringBuilder();
            //sb.AppendLine("Task 2 --the most common words are:");
            //Console.WriteLine("\n Task 1---the 10 Longest words is (longestWord),");
            foreach (var v in commonWords)
            {
                Console.WriteLine("Task 1-longest words" + v);
            }
            //return longestWord;
        }
        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder=from word in words
                               where word.Length > 6
                               group word by word into g
                               orderby g.Count() descending
                               select g.Key;
            var commonWords=frequencyOrder.Take(10);
            //Console.WriteLine("\n Task 2 is executing");
            //stringBuilder sb= new StringBuilder();
            //sb.AppendLine("Task 2 --the most common words are:");
            foreach(var v in commonWords)
            {
                Console.WriteLine("Task 2 ---Frequency of words" + v);
            }
            //console.WriteLine(sb.ToString());
        }
        public static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Retrieving from {uri}");
            string blog = new WebClient().DownloadString(uri);
            return blog.Split(new char[] {' ','\u000A',',','-',':','/'},StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
