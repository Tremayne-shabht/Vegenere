using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegenere
{
    public class Program
    {
        static void Main(string[] args)
        {
            VegenereEngine engine = new VegenereEngine
            { 
                CipherKey = "Tremayne"
            };

            string encrypted = engine.Encrypt("I Am Vengeance");
            Console.WriteLine($"Encrypted Message: {encrypted}");
            Console.WriteLine();
            string decrypted = engine.Decrypt(encrypted);
            Console.WriteLine($"Decrypted Message: {decrypted}");
            Console.WriteLine();
            engine.WriteToFile("EncryptedMessage.txt", encrypted);
            Console.WriteLine("Wrote to file");
        }
    }
}