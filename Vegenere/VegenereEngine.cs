using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

namespace Vegenere
{
    public class VegenereEngine
    {
        public static List<char> alphabets;

        public required string CipherKey { get; init; }

        public VegenereEngine() 
        {
            Initializer();
        }

        public void Initializer()
        {
            alphabets = new List<char>
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z'
            };
        }

        public string Encrypt(string message)
        {
            string encrypted = "";
            string spaceDelim = "*";
            int cipherIndex = 0;
            int index;
            int keyIndex;


            for (int i = 0; i < message.Length; i++)
            {

                if (Char.IsUpper(message[i]))
                {
                    char c = message[i];
                    string msg = c.ToString().ToLower();
                    int msgIndex = alphabets.IndexOf(Char.Parse(msg));
                    
                    if (cipherIndex >= CipherKey.Length)
                    {
                        cipherIndex = 0;
                    }

                    char k = CipherKey[cipherIndex];
                    string p = k.ToString().ToLower();
                    keyIndex = alphabets.IndexOf(Char.Parse(p));

                    index = msgIndex + keyIndex;

                    if (index > 25)
                    {
                        index = index - 25;
                    }

                    char en = alphabets[index];
                    string enc = en.ToString().ToUpper();

                    encrypted += enc;
                }
                else if (Char.IsLower(message[i]))
                {
                    int msgIndex = alphabets.IndexOf(message[i]);

                    if (cipherIndex >= CipherKey.Length)
                    {
                        cipherIndex = 0;
                    }

                    if (Char.IsUpper(CipherKey[cipherIndex]))
                    {
                        char k = CipherKey[cipherIndex];
                        string p = k.ToString().ToLower();
                        keyIndex = alphabets.IndexOf(Char.Parse(p));
                    }
                    else
                    {
                        keyIndex = alphabets.IndexOf(CipherKey[cipherIndex]);
                    }

                    index = msgIndex + keyIndex;

                    if (index > 25)
                    {
                        index = index - 25;
                    }

                    encrypted += alphabets[index];

                }
                else if (Char.IsDigit(message[i]))
                {
                    encrypted += message[i];
                }
                else if (Char.IsSymbol(message[i]))
                {
                    encrypted += message[i];
                }
                else if (Char.IsWhiteSpace(message[i]))
                {
                    encrypted += spaceDelim;
                }

                cipherIndex++;
            }

            return encrypted;
        }

        public string Decrypt(string message)
        {
            string decryted = "";
            string spaceDelim = " ";
            int cipherIndex = 0;
            int index;
            int keyIndex;


            for (int i = 0; i < message.Length; i++)
            {
                if (Char.IsUpper(message[i]))
                {
                    char c = message[i];
                    string msg = c.ToString().ToLower();
                    int msgIndex = alphabets.IndexOf(Char.Parse(msg));

                    if (cipherIndex >= CipherKey.Length)
                    {
                        cipherIndex = 0;
                    }

                    char k = CipherKey[cipherIndex];
                    string p = k.ToString().ToLower();
                    keyIndex = alphabets.IndexOf(Char.Parse(p));

                    index = msgIndex - keyIndex;

                    if (index < 0)
                    {
                        index = index + 25;
                    }

                    char en = alphabets[index];
                    string enc = en.ToString().ToUpper();

                    decryted += enc;

                }
                else if (Char.IsLower(message[i]))
                {
                    int msgIndex = alphabets.IndexOf(message[i]);

                    if (cipherIndex >= CipherKey.Length)
                    {
                        cipherIndex = 0;
                    }

                    if (Char.IsUpper(CipherKey[cipherIndex]))
                    {
                        char k = CipherKey[cipherIndex];
                        string p = k.ToString().ToLower();
                        keyIndex = alphabets.IndexOf(Char.Parse(p));
                    }
                    else
                    {
                        keyIndex = alphabets.IndexOf(CipherKey[cipherIndex]);
                    }

                    index = msgIndex - keyIndex;

                    if (index < 0)
                    {
                        index = index + 25;
                    }

                    decryted += alphabets[index];
                }
                else if (Char.IsDigit(message[i]))
                {
                    decryted += message[i];
                }
                else if (Char.IsSymbol(message[i]))
                {
                    decryted += message[i];
                }
                else if (Char.Equals(message[i], '*'))
                {
                    decryted += spaceDelim;
                }

                cipherIndex++;
            }

            return decryted;
        }

        public void WriteToFile(string filename, string text)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, filename)))
            {
                outputFile.WriteLineAsync(text);
            }
        }

    }
}
