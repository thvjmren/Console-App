using Course_Managment_Application.Enums;

namespace Course_Managment_Application
{
    public class Methods
    {
        List<Group> groups = new List<Group>();
        List<Student> students = new List<Student>();

        public void CreateStudent()
        {
            string name = Helper.GetValidatedName("enter the name of the student: ");
            string surname = Helper.GetValidatedName("enter the surname of the student: ");

            Console.WriteLine("choose the education type:");
            Console.WriteLine("1. Guaranteed");
            Console.WriteLine("2. Non-Guaranteed");

            EducationType selectedType;
            while (true)
            {
                Console.Write("enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        selectedType = EducationType.Guaranteed;
                        break;
                    case "2":
                        selectedType = EducationType.Nonguaranteed;
                        break;
                    default:
                        Console.WriteLine("invalid choice! you only have two option");
                        continue;
                }
                break;
            }


            string groupName;
            bool isValidGroupName = false;
            while (!isValidGroupName)
            {
                groupName = Helper.GetValidatedInput("enter the group name: ", 4);

                foreach (var existingGroup in groups)
                {
                    if (existingGroup.No.ToLower() == groupName.ToLower())
                    {
                        Group selectedGroup = existingGroup;
                        Student newStudent = new Student(name, surname, selectedGroup, selectedType);
                        bool added = existingGroup.AddStudent(newStudent);
                        students.Add(newStudent);
                        Console.WriteLine($"\nstudent {name} was successfully added to the {groupName}");
                        isValidGroupName = true;
                        break;
                    }
                }
                if (!isValidGroupName)
                {
                    Console.WriteLine("this group does not exist, please enter a valid group name");
                }

            }
        }


        public void CreateGroup()
        {
            Console.WriteLine("\ngroup name must be a 4 - digit name with a letter as the first character and numbers as the rest (for example: B209)");
            string groupNumber;
            do
            {
                groupNumber = Helper.GetValidatedInput("enter the group name: ", 4);

            } while (!Helper.IsValidGroupSyntax(groupNumber));

            foreach (var existingGroup in groups)
            {
                if (existingGroup.No.ToLower() == groupNumber.ToLower())
                {
                    Console.WriteLine("this group already exists");
                    return;
                }
            }
            Console.WriteLine($"\ngroup name: '{groupNumber}' saved successfully\n");

            Console.WriteLine("choose the group category:");
            Console.WriteLine("1. Frontend");
            Console.WriteLine("2. Backend");

            Category category;
            while (true)
            {
                Console.Write("enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        category = Category.Frontend;
                        break;
                    case "2":
                        category = Category.Backend;
                        break;
                    default:
                        Console.WriteLine("invalid choice! you only have two option");
                        continue;
                }
                break;
            }

            Console.WriteLine("Choose education type: 1. Online / 2. Offline");
            bool isOnline;
            while (true)
            {
                Console.Write("enter your choice: ");
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "1":
                        isOnline = true;
                        break;
                    case "2":
                        isOnline = false;
                        break;
                    default:
                        Console.WriteLine("invalid option! you only have two option");
                        continue;
                }
                break;
            }

            Console.WriteLine("\nall options are set, the group is now registered");
            Group newGroup = new Group(groupNumber, category, isOnline);
            groups.Add(newGroup);

            Console.WriteLine($"\n\"group: '{newGroup.No}' was created successfully!\"");
        }


        public void ShowGroupsList()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("group list is empty");
                return;
            }
            Console.WriteLine("\nGROUPS LIST:\n");
            foreach (var group in groups)
            {
                Console.WriteLine($"group name: {group.No}, category: {group.Category}, type: {(group.IsOnline ? "Online" : "Offline")}");
            }
        }

        public void ShowAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("no students found");
                return;
            }
            Console.WriteLine("\nSTUDENTS LIST:\n");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void ShowStudentsInGroup()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("group list is empty");
                return;
            }

            Console.WriteLine("enter the group name: ");
            string groupName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(groupName))
            {
                Console.WriteLine("group name cannot be empty");
                return;
            }

            bool groupFound = false;

            foreach (var selectedGroup in groups)
            {
                if (selectedGroup.No.ToLower().Trim() == groupName.ToLower().Trim())
                {
                    groupFound = true;
                    bool hasStudents = false;

                    foreach (var student in students)
                    {
                        if (student.Group.No.ToLower().Trim() == groupName.ToLower().Trim())
                        {
                            Console.WriteLine($"name: {student.Name}, surname: {student.Surname}, group: {student.Group.No}, type: {student.Type}");
                            hasStudents = true;
                        }
                    }

                    if (!hasStudents)
                    {
                        Console.WriteLine("there are no students in this group");
                    }

                    break;
                }
            }

            if (!groupFound)
            {
                Console.WriteLine("\nthis group does not exist");
            }
        }
        public void ChangeGroup()
        {
            Console.WriteLine("which group do you want to change?");
            bool isValidGroupName = false;

            while (!isValidGroupName)
            {
                string oldGroupName = Helper.GetValidatedInput("enter the group name: ", 4);

                Group selectedGroup = null;
                foreach (var group in groups)
                {
                    if (group.No.ToLower() == oldGroupName.ToLower())
                    {
                        selectedGroup = group;
                        break;
                    }
                }
                if (selectedGroup == null)
                {
                    Console.WriteLine("this group does not exist, please enter a valid group name");
                    continue;
                }

                string newGroupName = Helper.GetValidatedInput("enter the new group name: ", 4);

                bool groupExists = false;
                foreach (var group in groups)
                {
                    if (group.No.ToLower() == newGroupName.ToLower())
                    {
                        groupExists = true;
                        break;
                    }
                }

                if (groupExists)
                {
                    Console.WriteLine("there exist already a group with this name, please enter a different one");
                }
                else
                {
                    selectedGroup.No = newGroupName;
                    Console.WriteLine($"\ngroup name successfully changed to {newGroupName}");
                    isValidGroupName = true;
                }
            }
        }

    }
}



