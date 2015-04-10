using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calling functions
            StudentList();
            Console.ReadKey();
        }


        public static void StudentList()
        {
            //Set Student List
            List<string> studentList = new List<string> { "Nathan", "Mahmoud", "Lamond", "Mac", "Colton", "Ryan", "Umar", "Keif", "Aaron", "Matt", "Mitch", "David", "Kris" };
            int count = studentList.Count;
            GroupListMaker(studentList, count);
        }


        public static void GroupListMaker(List<string> students, int num)
        {

            Random rng = new Random();
            int groupNumber = 1;

            List<List<string>> studentGroupList = new List<List<string>>();
            List<string> currentGroupList = new List<string>();

            Console.WriteLine("Please enter the desired group size: ");
            int groupSize = int.Parse(Console.ReadLine());
            

            while (students.Count > 0)
            {
                string thisStudent = students[rng.Next(students.Count)];
                currentGroupList.Add(thisStudent);
                students.Remove(thisStudent);

                if (groupSize == currentGroupList.Count || students.Count == 0)
                {
                    if (groupSize > currentGroupList.Count)
                    {
                        for (int i = 0; i < currentGroupList.Count; i++)
                        {
                            //TODO Fix This
                            studentGroupList.Insert(i, currentGroupList);
                        }
                        //Any leftovers can be sorted into different groups
                    }
                    
                    studentGroupList.Add(currentGroupList);
                    currentGroupList = new List<string>();
                }
            }

            // this iterates over all lists in studentGroupList,
            // then over all students in the current list and prints them;
            // it separates the printed groups by empty lines
            foreach (List<string> group in studentGroupList)
            {
                Console.WriteLine("Group {0}: ", groupNumber);
                foreach (string student in group)
                {
                    Console.WriteLine("{0}", student);
                }
                Console.WriteLine();
                groupNumber++;
            }
        }
    }
}