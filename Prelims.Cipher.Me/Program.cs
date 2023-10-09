using System;
using System.Collections.Generic;
using System.IO;

namespace Prelims_Cipher_Me
{
    internal class Program
    {
        static string _mesFromTXT = "";

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
                ReadOutputFile();
                if (File.Exists("eMessage.txt"))
                {
                    Console.WriteLine("Machine Mode Set.");
                    Console.ReadKey();
                    DecryptMe();
                }
            }
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
            Console.Clear();
            BuildCphabet(key, message);
            Console.WriteLine("The encrypted message has been successfully written in the eMessage.txt file.");
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
        static void DecryptMe()
        {
            Console.Clear();
            Console.Write("Enter the key for your message: ");
            string key = Console.ReadLine();
            Console.WriteLine("Cypher has been set.");
            Console.ReadKey();
            DecryptMyMessage(key);
            Console.Clear();
            Console.ReadKey();
        }
        static void isValidInput(string uInput)
        {
            Console.Clear();
            if (uInput != "E" && uInput != "D")
            {
                Console.WriteLine("Your input must only be E for encrypting and D for decrypting.");
                Console.Write("Enter your choice [E / D]: ");
                uInput = Console.ReadLine().ToUpper();
                isValidInput(uInput);
            }
        }
        static void BuildCphabet(string key, string message)
        {
            List<char> aPhabet = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            List<char> cPhabet = new List<char>() { };

            key = key.ToUpper();

            for (int i = 0; i < key.Length; i++)
            {
                if (aPhabet.Contains(key[i]))
                {
                    cPhabet.Add(key[i]);
                    aPhabet.Remove(key[i]);
                }
            }

            for (int i = 0; i < aPhabet.Count; i++)
            {
                cPhabet.Add(aPhabet[i]);
            }

            EncryptMyMessage(message, cPhabet);
        }
        static void EncryptMyMessage(string message, List<char> cPhabet)
        {
            message = message.ToUpper();
            string eMessage = "";

            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsLetter(message[i]))
                {
                    int index = message[i] - 65;
                    eMessage += cPhabet[index];
                }
                else
                {
                    eMessage += message[i];
                }
            }
            WriteOutputFile(eMessage);
        }
        static void DecryptMyMessage(string key)
        {
            List<char> aPhabet = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            List<char> cPhabet = new List<char>() { };

            key = key.ToUpper();

            for (int i = 0; i < key.Length; i++)
            {
                if (aPhabet.Contains(key[i]))
                {
                    cPhabet.Add(key[i]);
                    aPhabet.Remove(key[i]);
                }
            }

            for (int i = 0; i < aPhabet.Count; i++)
            {
                cPhabet.Add(aPhabet[i]);
            }

            ReadOutputFile();
            string DecryptedMessage = "";
            for (int i = 0; i < _mesFromTXT.Length; i++) 
            { 
                if (cPhabet.Contains(_mesFromTXT[i]))
                {
                    int index = cPhabet.IndexOf(_mesFromTXT[i]) + 65;
                    DecryptedMessage += (char)index;
                }
            }
            Console.WriteLine("The decrypted message is: ");
            Console.WriteLine(DecryptedMessage);
            Console.ReadKey();
        }
        static void WriteOutputFile(string eMessage)
        {
            string _fileName = "eMessage.txt";
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                writer.WriteLine(eMessage);
            }
        }
        static void ReadOutputFile()
        {
            string _fileName = "eMessage.txt";
            using (StreamReader reader = new StreamReader(_fileName))
            {
                _mesFromTXT = reader.ReadToEnd();
            }
        }
    }
}
