using System;
using System.Collections.Generic;
using System.IO;

namespace Prelims_Cipher_Me
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //isUserChoice();

            NowICipher("John Joshua Delfin".ToUpper());
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
            WriteOutputFile();
            Console.WriteLine("The encrypted message has been successfully written in the eMessage.txt file.");
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
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
        static void NowICipher(string key)
        {
            List<char> aPhabet = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            List<char> cPhabet = new List<char>() { };


            //gets total num of index list
            for (int i = 0; i < key.Length; i++)
            {
                //if key not in cPhabet
                if (aPhabet.Contains(key[i]))
                {
                    cPhabet.Add(key[i]);
                    aPhabet.Remove(key[i]);
                }
            }

            //add the remaining letters to the
            for (int i = 0; i < aPhabet.Count; i++)
            {
                cPhabet.Add(aPhabet[i]);
            }

            for (int i = 0; i < cPhabet.Count; i++)
            {
                Console.Write(cPhabet[i] + " ");
            }


        }
        static void WriteOutputFile()
        {
            string fileName = "eMessage.txt";

            using (StreamWriter sr = new StreamWriter(fileName))
            {
                sr.WriteLine();
            }
        }
    }
}
