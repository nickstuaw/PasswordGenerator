import java.util.*;

public class Main {
    // Declare & initiate character arrays that hold the alphabet, digits, and symbols available.
    private static final char[]
            alphabet = "abcdefghijklmnopqrstuvwxyz".toCharArray(),
            digits = "0123456789".toCharArray(),
            symbols = "`¬¦!\"£$%^&*()_+{}:@~<>?,./;'#[]-=\\|".toCharArray();

    /**
     * Generate a password that contains letters, digits, and symbols
     * (but not uppercase letters).
     * @param length The length of the password returned.
     * @return A random generated password of length with a mix of characters.
     */
    private static String GeneratePassword(int length) {
        // Use java.util.Random to generate random integers.
        Random r = new Random();
        // USe StringBuilder to build the password because a for loop is used.
        StringBuilder password = new StringBuilder();
        // Iterate through i from 0 to length.
        for(int i = 0; i < length; i++) {
            // Switch-case for a random integer between 0 and 2 inclusively.
            switch (r.nextInt(3)) {
                // Append a random letter from alphabet, assuming its length is 26.
                case 0 -> password.append(alphabet[r.nextInt(26)]);
                // Append a random digit, assuming there are 10 digits being chosen from.
                case 1 -> password.append(digits[r.nextInt(10)]);
                // Append a random symbol from symbols regardless of its length.
                case 2 -> password.append(symbols[r.nextInt(symbols.length)]);
            }
            // Loop until i >= length.
        }
        // Return the final password.
        return password.toString();
    }

    public static void main(String[] args) {
        // The program executes from here.
        // Use java.util.Scanner to take user input.
        Scanner s = new Scanner(System.in);
        // Ask the user for the length and tell them the minimum functional length..
        System.out.print("Length (>0): ");
        // Take the user input without validation.
        int length = s.nextInt();
        // Display the generated password.
        System.out.println(GeneratePassword(length));
    }
}
