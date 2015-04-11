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
            GroupListMaker(studentList);
        }


        /// <summary>
        /// Takes an external list and generates random groups of desired size
        /// </summary>
        /// <param name="students"></param>
        public static void GroupListMaker(List<string> students)
        {

            Random rng = new Random();

            int groupNumber = 1;

            List<List<string>> studentGroupList = new List<List<string>>();
            List<string> currentGroupList = new List<string>();

            Console.WriteLine("Please enter the desired group size: ");
            int groupSize = int.Parse(Console.ReadLine());
            // this is an int
            // do you minimum number check here


            while (groupSize > (students.Count / 2) || groupSize == 0)
            {
                Console.WriteLine("This number does not allow for even groups. \nPlease select a smaller number: ");
                groupSize = int.Parse(Console.ReadLine());
            }

            while (students.Count > 0)
            {
                //gathers desired amount of students randomly
                //adds random student to variable
                string thisStudent = students[rng.Next(students.Count)];
                //adds name to list
                currentGroupList.Add(thisStudent);
                //removes name from original list
                students.Remove(thisStudent);

                //when the desired group size is met
                if (groupSize == currentGroupList.Count || students.Count == 0)
                {
                    if (groupSize > currentGroupList.Count)
                    {
                        int placeInGroupIndex = 0;
                        while (currentGroupList.Count > 0)
                        {
                            //for each remaining student...
                            //get a group to assign the overflow student to
                            List<string> overflowGroup = studentGroupList[placeInGroupIndex];

                            //place it in the group by the index
                            overflowGroup.Insert(0, currentGroupList[0]);
                            currentGroupList.Remove(currentGroupList[0]);


                            //increase the groupindex
                            placeInGroupIndex++;

                            //check if the group index exceeds the maxiumum indexes                            
                            if (placeInGroupIndex >= studentGroupList.Count)
                            {
                                //if it does, reset the index to 0
                                placeInGroupIndex = 0;
                            }
                        }
                        //Any leftovers can be sorted into different groups
                    }
                    //Store current group into list
                    studentGroupList.Add(currentGroupList);
                    currentGroupList = new List<string>();
                }
            }

            // this iterates over all lists in studentGroupList,
            // then over all students in the current list and prints them;
            // it separates the printed groups by empty lines
            foreach (List<string> group in studentGroupList)
            {
                if (group.Count > 0)
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
}
