using System;

namespace PasswordGenerator
{
    class Program
    {
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
        private static string GeneratePassword(int length)
        {
            // Use Random to generate random integers.
            Random r = new Random();
            // Create an empty string to store the future password in.
            string password = "";
            // Iterate through i from 0 to length.
            for (int i = 0; i < length; i++)
            {
                // Switch-case for a random integer betwen 0 and 2 inclusively.
                switch (r.Next(0, 3))
                {
                    case 0:
                        // Append a random letter from alphabet, assuming its length is 26.
                        // Add a 50% chance for the letter to be uppercase.
                        password +=
                            r.Next(0,2) == 1 ? alphabet[r.Next(0, 26)]  : alphabet[r.Next(0, 26)].ToString().ToUpper().ToCharArray()[0];
                        break;
                    case 1:
                        // Append a random digit, assuming there are 10 digits being chosen from
                        password += digits[r.Next(0, 10)];
                        break;
                    case 2:
                        // Append a random symbol from symbols regardless of its length.
                        password += symbols[r.Next(0, symbols.Length)];
                        break;
                }
                // Loop until i >= length.
            }
            // Return the final password.
            return password;
        }

        static void Main(string[] args)
        {
            // The program executes from here.
            // Ask the user for the length and tell them the minimum functional length.
            Console.Write("Length (>0): ");
            // Take the user input without validation.
            int length;
            do
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out length))
                {
                    if (length > 0)
                        break;
                }
                Console.WriteLine("Please enter a valid password length above 0.");
            } while (true);
            // Display the generated password.
            Console.WriteLine(GeneratePassword(length));
            // Wait for the user to read the output and close the window.
            Console.ReadKey();
        }
    }
}
