using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1_dobre
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /*            int? tmp = null;
                        double tmp2 = 2.0;
                        string tmp3 = "abc";
                        bool tmp4 = true;*/
                        
            //var tmp5 = "ala";//ale fajne 

            //var newPerson = new Person { FirstName = "Jakub" };
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();


            var response = await httpClient.GetAsync(url);
            
            //status 2xx
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach(var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }


        }
    }
}
