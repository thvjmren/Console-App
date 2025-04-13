namespace Course_Managment_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Methods methods = new Methods();
            string choice;

            do
            {
                Console.WriteLine("\n1. create new group");
                Console.WriteLine("2. show groups list");
                Console.WriteLine("3. change group");
                Console.WriteLine("4. show students in the group");
                Console.WriteLine("5. show all students");
                Console.WriteLine("6. create new student");
                Console.WriteLine("0. EXIT");

                Console.WriteLine("\nenter your choice:");
                choice = Convert.ToString(Console.ReadLine().Trim());

                switch (choice)
                {
                    case "1":
                        methods.CreateGroup();
                        break;
                    case "2":
                        methods.ShowGroupsList();
                        break;
                    case "3":
                        methods.ChangeGroup();
                        break;
                    case "4":
                        methods.ShowStudentsInGroup();
                        break;
                    case "5":
                        methods.ShowAllStudents();
                        break;
                    case "6":
                        methods.CreateStudent();
                        break;
                    case "0":
                        Console.WriteLine("\nexiting the program...");
                        break;
                    default:
                        Console.WriteLine("\ninvalid choice, try again.");
                        break;
                }

            } while (choice != "0");
        }
    }
}