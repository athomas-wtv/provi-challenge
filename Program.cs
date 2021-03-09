using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProviChallenge
{

    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }
        private static ResultPage ReadToObject(string json)
        {
            var deserializedResultPage = new ResultPage();
            using(var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(deserializedResultPage.GetType());
                deserializedResultPage = ser.ReadObject(ms) as ResultPage;
                return deserializedResultPage;
            }
        }

        private static List<string> GetListOfUsernames(List<User> mostActiveUsers)
        {
            var usernames = new List<string>();
            foreach(var u in mostActiveUsers)
            {
                usernames.Add(u.username);
            }
            return usernames;
        }
        
        private static List<User> GetUsersFromPageResults(List<ResultPage> allResultPages)
        {
            var users = new List<User>();
            foreach(var pr in allResultPages)
            {
               users.AddRange(pr.data);
            }
            return users;
        }
        
        private async static Task<ResultPage> GetPageResults(int pageNum)
        {
            using(var httpClient = new HttpClient())
            {
                var res = await httpClient.GetStringAsync($"https://jsonmock.hackerrank.com/api/article_users?page={pageNum}");
                var pageList = ReadToObject(res);
                return pageList;
            }
        }

        private static void RunProgram()
        {
            Console.WriteLine("What's the submission count threshold that you want to see?");
            var threshold = Console.ReadLine();
            int input;
            if(Int32.TryParse(threshold, out input))
            {
                var usernames = GetUsernames(input);
                Console.WriteLine("*******Results*******");
                foreach(var user in usernames.Result)
                {
                    Console.WriteLine(user);
                }
            }
            else
            {
                Console.WriteLine("Not an integer. Please try again.");
                RunProgram();
            }
        }

        private async static Task<List<string>> GetUsernames(int threshold)
        {
            using(var httpClient = new HttpClient())
            {
                var res = await httpClient.GetStringAsync("https://jsonmock.hackerrank.com/api/article_users?page=1");
                var pageResult = ReadToObject(res);
                
                var totalPages = pageResult.total_pages;
                var allResultPages = new List<ResultPage>();
                allResultPages.Add(pageResult);
                for(var i = 2; i <= totalPages; i++)
                {
                    allResultPages.Add(GetPageResults(i).Result);
                }
                
                var users = GetUsersFromPageResults(allResultPages);
                var mostActiveUsers = users.Where(u => u.submission_count > threshold).ToList<User>();
                var usernames = GetListOfUsernames(mostActiveUsers);
                return usernames;
            }
        }
    }
}
