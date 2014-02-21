using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConvertExample
{
    class Program
    {
        static void Main()
        {
            string unicodeString = "中国 This string contains the unicode character Pi(\u03a0)";

            // Create two different encodings.
            Encoding ascii = UTF8Encoding.ASCII;
            Encoding unicode = UTF8Encoding.Unicode;

            // Convert the string into a byte[].
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, Encoding.UTF8, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            // This is a slightly different approach to converting to illustrate
            // the use of GetCharCount/GetChars.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);
            byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };
            FileStream sFile = new FileStream(@"C:\1.csv", FileMode.OpenOrCreate);
            sFile.Write(bomBuffer, 0, bomBuffer.Length);
            sFile.Write(asciiBytes, 0, asciiBytes.Length);
            sFile.Close();

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);
            Console.ReadLine();
        }
    }
}
