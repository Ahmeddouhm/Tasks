using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Password_Manager
{
    internal class Encryption
    {
        private const string plainText = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyz0123456789";
        private const string cipheredText = "pR6bT1xG0vL9S2oHqCzM5aF7r8eUu4WkZsN3dIYtKXlJOVfEPBcmAyDhgwnQj";
        public static string Encrypt(string text) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in text)
            {
                int plainIdx = plainText.IndexOf(ch);
                sb.Append(cipheredText[plainIdx]);
            }
            return sb.ToString();
        }
        public static string Decrypt(string chipheredText) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in chipheredText)
            {
                int chipheredIdx = cipheredText.IndexOf(ch);
                sb.Append(plainText[chipheredIdx]);
            }
            return sb.ToString();
        }

        public static string CesarCipherEncryption(string text) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in text)
            {
                int idx = ((plainText.IndexOf(ch) + 8) % 26);
                sb.Append(plainText[idx]);
            }
            return sb.ToString();
        }
        public static string CesarCipherDecryption(string cesartext) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in cesartext)
            {
                int idx = ((plainText.IndexOf(ch) - 8 + 26) % 26);
                sb.Append(plainText[idx]);
            }
            return sb.ToString();
        }
    }
}
