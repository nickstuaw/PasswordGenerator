import java.util.*;

public class Main {
    private static final char[]
            alphabet = "abcdefghijklmnopqrstuvwxyz".toCharArray(),
            digits = "0123456789".toCharArray(),
            symbols = "`¬¦!\"£$%^&*()_+{}:@~<>?,./;'#[]-=\\|".toCharArray();

    private static String GeneratePassword(int length) {
        Random r = new Random();
        StringBuilder password = new StringBuilder();
        for(int i = 0; i < length; i++) {
            switch (r.nextInt(3)) {
                case 0 -> password.append(alphabet[r.nextInt(26)]);
                case 1 -> password.append(digits[r.nextInt(10)]);
                case 2 -> password.append(symbols[r.nextInt(symbols.length)]);
            }
        }
        return password.toString();
    }

    public static void main(String[] args) {
        System.out.println(GeneratePassword(10));
    }
}
