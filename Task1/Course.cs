using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Course
    {

        private static int id = 1;
        public int Id { get; set; }

        public string Name { get; set; }

        public CustomList<Group> Groups { get; }

        public Course(string name)
        {
            Id = id++;
            Name = name;
            Groups = new CustomList<Group>();
        }
        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void GetAllGroups()
        {
            foreach (var group in Groups)
                group.GetDetails();
        }
        public CustomList<Student> GetAllStudents()
        {
            CustomList<Student> students = new CustomList<Student>();   
            foreach (var group in Groups)
            {
                foreach (var student in group.Students)
                {
                    students.Add(student);

                }
            }

            return students;
        }
    }
}
