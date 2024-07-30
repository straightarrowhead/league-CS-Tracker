using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace league_CS_Tracker
{
    class Program
    {

        static int CS_Average_Counter(List<int> blah)
        {
            double CS_Avg = blah.Average();

            int CS_Avg_as_Int = Convert.ToInt32(CS_Avg);

            return CS_Avg_as_Int;
        }

        static void CS_Ask_For_Number(List<int> CS_Stored)
        {
            Console.Write("How much farm did you have in your last game? ");
            string CS_Input = "";
            CS_Input = Console.ReadLine();


            int CS_Amnt = Convert.ToInt32(CS_Input);


            CS_Stored.Add(CS_Amnt);


            string json = JsonSerializer.Serialize(CS_Stored);
            File.WriteAllText(@"CS_Amnt.json", json);
        }
        static void Main(string[] args)
        {
            string CS_Json_File = File.ReadAllText(@"CS_Amnt.json");
            List<int> CS_Stored = JsonSerializer.Deserialize<List<int>>(CS_Json_File);


            Console.WriteLine("Press 1 to give average farm in games");
            Console.WriteLine("Press 2 to give new farm from games");
            Console.Write("Enter number to select: ");
            string CS_option;
            CS_option = Console.ReadLine();

            if (CS_option == "1")
            {
                int CS_Calculated_Avg = CS_Average_Counter(CS_Stored);
                Console.WriteLine(CS_Calculated_Avg);
                Console.ReadLine();
                return;
            }
            else if (CS_option == "2")
            {
                CS_Ask_For_Number(CS_Stored);
            }

        }
    }
}
