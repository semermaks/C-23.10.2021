using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hag_23._10._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var paysumm1 = new PayCheck(100,12,50,3);
            using (var fs = new FileStream("payCheck.bin", FileMode.Create))
            {               
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, paysumm1);
            }
            using (var fs = new FileStream("payCheck.bin", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                PayCheck bikeFromFile = (PayCheck)formatter.Deserialize(fs);
                Console.WriteLine(bikeFromFile);
            }
        }
    }
}
