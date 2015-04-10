using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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
        /// <summary>
        /// Creates a method for adding random names to lists within a list
        /// </summary>
        /// <param name="names"></param>
        public static void GroupListMaker(List<string> students, int numberOfStudents)
        {
            //User selects size of groups
            Console.WriteLine("Please enter a groups size: ");
            int groupSize = int.Parse(Console.ReadLine());

            //Creates rng
            Random rng = new Random();
            //First String for storing strings
            List<List<string>> studentGroupList = new List<List<string>>();
            //temporarily stores names in list for later storage in studentGroupList
            List<string> currentGroupList = new List<string>();

            int selector = numberOfStudents - 1;
            int groupNumber = 1;

            //while there are students left to sort
            while (students.Count > 0)
            {
                //Assign random student to variable
                string thisStudent = students[rng.Next(selector)];
                //Add variable to current list
                currentGroupList.Add(thisStudent);
                //Remove selected student from list
                students.Remove(thisStudent);
                //Reduce randomization selector
                selector--;

                //If the size of the group and list size are equal, or there are no students left to sort
                if (groupSize == currentGroupList.Count || students.Count == 0)
                {
                    //Extra students not already assigned to groups
                    if (groupSize > currentGroupList.Count)
                    {
                        Console.WriteLine("Pick a group");

                        goto Ending;
                        //separate elements from list and distribute them amongs all current lists in student list
                    }

                    //this all executes before storage occurs
                    Console.WriteLine("Group {0}: ", groupNumber);

                Ending:
                    for (int i = 0; i < currentGroupList.Count; i++)
                    {
                        Console.WriteLine("{0}", currentGroupList[i]);
                    }

                    groupNumber++;

                    //TODO fix this here, not storing multiple lists within list properly :C :C :C :C :C :C
                    studentGroupList.Add(currentGroupList);
                    currentGroupList = new List<string>();
                    //foreach (var group in studentGroupList)
                    //{
                    //    foreach (var student in group)
                    //    {
                    //        while (groupNumber < groupSize)
                    //        {
                    //            Console.WriteLine("Group {0}: ", groupNumber);

                    //            Console.WriteLine("{0}", student);
                    //            groupNumber++;
                    //        }
                    //    }
                    //}

                }
            }
        }
    }
}
