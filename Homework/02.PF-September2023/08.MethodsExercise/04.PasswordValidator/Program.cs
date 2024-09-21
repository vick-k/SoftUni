namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (CorrectLength(input) && HasOnlyLettersAndDigits(input) && HasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password is valid");
            }

            if (!CorrectLength(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!HasOnlyLettersAndDigits(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!HasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool CorrectLength(string input)
        {
            if (input.Length >= 6 && input.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool HasOnlyLettersAndDigits(string input)
        {
            bool isValid = false;

            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 48 && input[i] <= 57) || (input[i] >= 65 && input[i] <= 90) || (input[i] >= 97 && input[i] <= 122))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        static bool HasAtLeastTwoDigits(string input)
        {
            int digitsCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 48 && input[i] <= 57)
                {
                    digitsCount++;
                }
            }

            if (digitsCount >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}