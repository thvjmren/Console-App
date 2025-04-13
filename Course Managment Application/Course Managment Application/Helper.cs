namespace Course_Managment_Application
{
    public static class Helper
    {
        public static string Capitalize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("cannot be empty");
                return null;
            }
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static string GetValidatedInput(string sentence, int len = 0)
        {
            string input;
            do
            {
                Console.Write(sentence);
                input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("cannot be empty, enter again...");
                }
                else if (len > 0 && input.Length != len)
                {
                    Console.WriteLine($"name must be {len} characters long, enter again...");
                }
            } while (string.IsNullOrWhiteSpace(input) || (len > 0 && input.Length != len));

            return Capitalize(input);
        }

        public static bool NameValidation(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("cannot be empty, enter again...");
                return false;
            }
            else if (str.Length < 3 || str.Length > 15)
            {
                Console.WriteLine("wrong format, enter again...");
                return false;
            }
            else
            {
                foreach (char c in str)
                {
                    if (!char.IsLetter(c))
                    {
                        Console.WriteLine("name must contain only letters, enter again...");
                        return false;
                    }
                }
                return true;
            }
        }

        public static string GetValidatedName(string input)
        {
            string name;
            do
            {
                Console.WriteLine(input);
                name = Console.ReadLine().Trim();
            } while (!NameValidation(name));

            return Capitalize(name);
        }

        public static bool IsValidGroupSyntax(string str)
        {
            if (char.IsLetter(str[0]))
            {

                byte count = 0;
                foreach (char c in str)
                {
                    if (char.IsDigit(c))
                    {
                        count++;
                        if (count == 3)
                        {
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("group name must be a 4 - digit name with a letter as the first character and numbers as the rest (for example: B209)");
            return false;
        }

    }
}