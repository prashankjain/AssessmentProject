using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storing_Updating_Teacher_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            TeachersDataModification teachersData = new TeachersDataModification();
            int option = 0;
            TeacherDetail teacherDetail = new TeacherDetail();
//            int ID; string Name; string className; char section;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("THis is a Rainbow School Teacher's Data Management Application.");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Select an option to perform:");
            Console.WriteLine("1. storing the teacher's data");
            Console.WriteLine("2. updating the teacher's data");
            Console.WriteLine("3. retriving the teacher's data");
            Console.WriteLine("Please type a number (1 or 2 or 3) to perform the action??");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Please Enter the Teacher's data to store");
                Console.WriteLine("Teacher ID:");
                teacherDetail.tId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Teacher Name:");
                teacherDetail.tName = Console.ReadLine();
                Console.WriteLine("Teacher Classname:");
                teacherDetail.className = Console.ReadLine();
                Console.WriteLine("Teacher section:");
                teacherDetail.section = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Need to call Store function");

                string result = teachersData.Store(teacherDetail);
            }
            else if (option == 2)
            {
                Console.WriteLine("Please Enter the Teacher's data to update");
                Console.WriteLine("Teacher ID:");
                teacherDetail.tId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Teacher Name:");
                teacherDetail.tName = Console.ReadLine();
                Console.WriteLine("Teacher Classname:");
                teacherDetail.className = Console.ReadLine();
                Console.WriteLine("Teacher section:");
                string result = teachersData.update(teacherDetail);
            }
            else if (option == 3)
            {
                Console.WriteLine("Need to call Read function");
            }
            else
            {
                Console.WriteLine("invalid option");
            }

            Console.ReadKey();

            //            StreamWriter OurStream;
            ////          OurStream = File.CreateText("c:\\examples\\test.txt");
            //            OurStream = File.AppendText("c:\\examples\\test.txt");
            //            OurStream.WriteLine("This is a line of text");
            //            OurStream.Close();
            //            Console.WriteLine("Created File!");
        }
    }
}
