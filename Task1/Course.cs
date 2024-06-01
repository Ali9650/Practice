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
        
        public string Name {  get; set; }   

        public List<Group> Groups { get;}

        public Course(string name)
        {
            Id = id++;
            Name = name;
            Groups = new List<Group>();
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
        public List<Student> GetAllStudents()
        {
            return Groups.SelectMany(g => g.Students).ToList();
        }
    }
}
