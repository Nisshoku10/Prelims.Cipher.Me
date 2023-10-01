using System;
using System.Collections.Generic;

namespace Prelims_Cipher_Me
{
    internal class Program
    {
        static string _aPhabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            isUserChoice();
        }
        static void isUserChoice()
        {
            Console.Write("Do you want to encrypt or decrypt [E / D]: ");
            string choice = Console.ReadLine().ToUpper();
            isValidInput(choice);

            if (choice == "E")
            {
                Console.WriteLine("Machine Mode Set.");
                Console.ReadKey();
                EncryptMe();
            }
            else
            {
                Console.WriteLine("Machine Mode Set.");
                Console.ReadKey();
                DecryptMe();
            }
        }
        static void DecryptMe()
        {
            Console.Clear();
            Console.Write("Enter your desired key: ");
            string key = Console.ReadLine();
            Console.WriteLine("Cypher has been set.");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Enter your message: ");
            string message = Console.ReadLine();
            Console.ReadKey();

            NowIDecipher(key, message);
        }
        static void EncryptMe()
        {
            Console.Clear();
            Console.Write("Enter your desired key: ");
            string key = Console.ReadLine();
            Console.WriteLine("Cypher has been set.");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Enter your message: ");
            string message = Console.ReadLine();
            Console.ReadKey();

            NowICipher(key, message);
        }
        static void isValidInput(string uInput)
        {
            if (uInput != "E" && uInput != "D")
            {
                Console.WriteLine("Your input must only be E for encrypting and D for decrypting.");
                Console.Write("E / D: ");
                uInput = Console.ReadLine().ToUpper();
                isValidInput(uInput);
            }
        }
        static string NowICipher(string key, string message)
        {
            List<char> finalMes = new List<char>();
            key = key.ToUpper();

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    message.ToUpper();
                    int index = _aPhabet.IndexOf(message);

                    if (index >= 0)
                    {
                        char keyChar = key[c % key.Length];
                        int keyIndex = _aPhabet.IndexOf(keyChar);

                        char encryptedChar = _aPhabet[(index + keyIndex) % 26];

                        finalMes.Add(encryptedChar);
                    }
                }
                else
                {
                    finalMes.Add(c);
                }
            }

            string CipheredMes = new string(finalMes.ToArray());

            return CipheredMes;
        }
        static string NowIDecipher(string key, string message)
        {
            return NowICipher(message, key).ToUpper();
        }
    }
}





