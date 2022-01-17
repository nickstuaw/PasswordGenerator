using System;

namespace PasswordGenerator
{
    class Program
    {
        // Declare & initiate the debug mode variable.
        // debug is currently redundant.
        private static bool debug = false;
        // Declare & initiate character arrays that hold the alphabet, digits, and symbols available.
        private static char[]
            alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray(),
            digits = "0123456789".ToCharArray(),
            symbols = "`¬¦!\"£$%^&*()_+{}:@~<>?,./;'#[]-=\\|".ToCharArray();
        /// <summary>
        /// Generate a password that contains letters, digits, and symbols
        /// (but not uppercase letters)
        /// </summary>
        /// <param name="length">The length of the password returned.</param>
        /// <returns>A random generated password of length with a mix of characters.</returns>
        private static string GeneratePassword(
            int length,
            int maxLetters,
            int maxDigits,
            int maxSymbols)
        {
            // Use Random to generate random integers.
            Random r = new Random();
            // Create an empty string to store the future password in.
            string password = "";
            bool limitReached = false;
            int letterCount = 0, digitCount = 0, symbolCount = 0;
            int next;
            int startI = 0;
            // Ensure it starts with a letter if letters are being used.
            // This is useful for websites that require the password to start with a letter.
            if(maxLetters > 0)
            {
                // Append a random letter from alphabet, assuming its length is 26.
                // Add a 50% chance for the letter to be uppercase.
                password +=
                    r.Next(0, 2) == 1 ? alphabet[r.Next(0, 26)] : alphabet[r.Next(0, 26)]
                    .ToString().ToUpper().ToCharArray()[0];
                // Increment letterCount because a letter has been concatenated.
                letterCount++;
                startI = 1;
            }
            // Iterate through i from startI to length.
            for (int i = startI; i < length; i++)
            {
                next = r.Next(0, 3);
                // Add a letter if randomly chosen.
                // If maxDigits is 0 and maxSymbols is 0, check if maxLetters is 0 or done.
                // If the letter maximum has not been reached and is not 0, add a letter.
                if (
                    (next == 0
                    // Check whether other character types are being used.
                    || (digitCount >= maxDigits && symbolCount >= maxSymbols))
                    && letterCount < maxLetters)
                {
                    // Append a random letter from alphabet, assuming its length is 26.
                    // Add a 50% chance for the letter to be uppercase.
                    password +=
                        r.Next(0, 2) == 1 ? alphabet[r.Next(0, 26)] : alphabet[r.Next(0, 26)]
                        .ToString().ToUpper().ToCharArray()[0];
                    // Increment letterCount because a letter has been concatenated.
                    letterCount++;
                }
                // Add a digit if randomly chosen.
                // If maxSymbols has been reached or is 0, check if maxDigits is 0 or done.
                // If the digit maximum has not been reached and is not 0, add a digit.
                else if ((next == 1 || symbolCount >= maxSymbols)
                    && digitCount < maxDigits)
                {
                    // Append a random digit, assuming there are 10 digits being chosen from
                    password += digits[r.Next(0, 10)];
                    // Increment digitCount because a digit has been concatenated.
                    digitCount++;
                }
                // If the symbol maximum has not been reached and is not 0, add a symbol.
                else if (symbolCount < maxSymbols)
                {
                    // Append a random symbol from symbols regardless of its length.
                    password += symbols[r.Next(0, symbols.Length)];
                    // Increment symbolCount because a symbol has been concatenated.
                    symbolCount++;
                }
                else
                {
                    Console.WriteLine("Character limit reached. Here is your password:");
                    return password;
                }
            }
            // Loop until i >= length.
            // Return the final password.
            return password;
        }
        /// <summary>
        /// Ask for an integer and validate the input. This includes a range check using the lower bound.
        /// </summary>
        /// <param name="prompt">The prompt to ask the user with.</param>
        /// <param name="lBound">The lower bound to inclusively check against the input.</param>
        /// <returns>A final valid value.</returns>
        static int askWithLimit(string prompt, int lBound)
        {
            int result;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (Int32.TryParse(input, out result) && lBound <= result)
                    break;
                Console.WriteLine("Please enter a number of at least {0}.", lBound);
            } while (true);
            return result;
        }
        /// <summary>
        /// Ask a yes/no question.
        /// </summary>
        /// <param name="question">The question to ask the user.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The boolean value returned.</returns>
        static bool askYesNo(string question, bool defaultValue)
        {
            Console.Write(question + " (" + (defaultValue ? "[Y]/N" : "Y/[N]") +"): ");
            string input = Console.ReadLine().ToLower();
            if (input.StartsWith(defaultValue ? "n" : "y"))
                return false;
            // Toggle debug mode with 'd'.
            else if (input.StartsWith("d"))
            {
                debug = !debug;
                Console.WriteLine("Debug mode is now " + (debug ? "on." : "off."));
            }
            return true;
        }

        static void Main(string[] args)
        {
            // The program executes from here.
            do
            {
                // Take & validate the user input then generate and display the password.
                int length = askWithLimit("Length (>0): ", 1);
                Console.WriteLine(
                    new string('-', 16 + length) + "\nPassword:\t" +
                    GeneratePassword(
                    length,
                    askWithLimit("Letters (>=0): ", 0),
                    askWithLimit("Digits (>=0): ", 0),
                    askWithLimit("Symbols (>=0): ", 0))
                    + "\n" + new string('-', 16 + length));
                // Ask to run again. The default answer is true (yes).
                if (!askYesNo("Would you like to run again?", true))
                    break;
            } while (true);
        }
    }
}
