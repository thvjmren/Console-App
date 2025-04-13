namespace Course_Managment_Application
{
    public class Group
    {
        public string No { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }

        List<Student> students = new List<Student>();


        public Group(string no, string category, bool isOnline)
        {
            No = no;
            Category = category;
            IsOnline = isOnline;
            if (isOnline)
            {
                Limit = 15;
            }
            else
            {
                Limit = 20;
            }
        }

        public bool AddStudent(Student student)
        {
            if (students.Count >= Limit)
            {
                return false;
            }
            students.Add(student);
            return true;
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
