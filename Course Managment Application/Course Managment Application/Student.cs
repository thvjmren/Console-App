using Course_Managment_Application.Enums;

namespace Course_Managment_Application
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EducationType Type { get; set; }
        public Group Group { get; set; }

        public Student(string name, string surname, Group group, EducationType type)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Type = type;
        }

        public override string ToString()
        {
            return $"Name: {Name} {Surname}, Group: {Group.No}, Type: {Type}\n";
        }
    }
}