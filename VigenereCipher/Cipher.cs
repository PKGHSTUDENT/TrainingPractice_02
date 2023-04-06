using System;
using System.Windows.Forms;

namespace VigenereCipher
{
    class Cipher
    {
        public const string alphabet = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя!.,[]{}@#$%^&*()_+-=\\|/?><`~\"';: ";
        // public const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string VigenereEncrypt(string text, string key)
        {
            char[] alphabetChars = new char[alphabet.Length];
            for (int i = 0; i < alphabetChars.Length; i++)
                alphabetChars[i] = alphabet[i];

            string enctyptionText = "";

            if (key.Length < text.Length)
                SupplementArray(ref key, text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                enctyptionText += alphabetChars[(Array.IndexOf(alphabetChars, text[i]) + Array.IndexOf(alphabetChars, key[i])) % alphabetChars.Length];
            }

            return enctyptionText;  
        }

        public static string VigenereDecrypt(string text, string key)
        {
            char[] alphabetChars = new char[alphabet.Length];
            for (int i = 0; i < alphabetChars.Length; i++)
                alphabetChars[i] = alphabet[i];

            string denctyptionText = "";

            if (key.Length < text.Length)
                SupplementArray(ref key, text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                denctyptionText += alphabetChars[(Array.IndexOf(alphabetChars, text[i]) + alphabetChars.Length - Array.IndexOf(alphabetChars, key[i])) % alphabetChars.Length];
            }

            return denctyptionText;
        }

        public static void SupplementArray(ref string key, int length)
        {
            int keyLength = key.Length;
            while (key.Length < length)
            {
                for (int i = 0; i < keyLength; i++)
                {
                    key += key[i];
                    if (key.Length >= length) break;
                }
            }
        }
    }
}
