using Statistics.DB;
using Statistics.DB.Logic;
using Statistics.DB.Models;

namespace WebStatistics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initilaize DB");
            Console.WriteLine("..............");

            DBInitilaize.Init();
            Console.WriteLine("Init Done");


            Logic<Website> logic = new Logic<Website>();
            var top = logic.GetPopolurSites();
            foreach (var item in top)
            {
                Console.WriteLine($"Website Title : {item.Title} Number of Entrence : {item.NumberOfEnters}");
            }

        }

    }
}
