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
            string folderName = @"c:\Teachers_Data";
            string pathString = System.IO.Path.Combine(folderName);
            System.IO.Directory.CreateDirectory(pathString);

            char continueOrNot = 'Y';
            int option = 0;
            TeachersDataModification teachersData = new TeachersDataModification();
            TeacherDetail teacherDetail = new TeacherDetail();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This is a Rainbow School Teacher's Data Management Application.");
            Console.WriteLine("----------------------------------------------------------------");
            try
            {
                while (char.ToUpper(continueOrNot) == 'Y')
                {
                    Console.WriteLine("Select an option to perform:");
                    Console.WriteLine("1. Store the teacher's data");
                    Console.WriteLine("2. Update the teacher's data");
                    Console.WriteLine("3. Retrieve a teacher's data");
                    Console.WriteLine("4. Retrieve complete data");
                    Console.WriteLine(">>>>> Please type a number (1 or 2 or 3 or 4) to perform the action??");
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option == 1)
                        {
                            Console.WriteLine(">>>>> Please Enter the Teacher's data to store");
                            Console.WriteLine(">> Teacher ID:");
                            teacherDetail.tId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(">> Teacher Name:");
                            teacherDetail.tName = Console.ReadLine();
                            Console.WriteLine(">> Teacher Classname:");
                            teacherDetail.className = Console.ReadLine();
                            Console.WriteLine(">> Teacher section:");
                            teacherDetail.section = Convert.ToChar(Console.ReadLine());
                            bool result = teachersData.Store(teacherDetail);
                        }
                        else if (option == 2)
                        {
                            Console.WriteLine(">>>>> Please Enter the Teacher's data to update (record will update based on the ID)");
                            Console.WriteLine(">> Teacher ID:");
                            teacherDetail.tId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(">> Teacher Name:");
                            teacherDetail.tName = Console.ReadLine();
                            Console.WriteLine(">> Teacher Classname:");
                            teacherDetail.className = Console.ReadLine();
                            Console.WriteLine(">> Teacher section:");
                            teacherDetail.section = Convert.ToChar(Console.ReadLine());
                            bool result = teachersData.Update(teacherDetail);
                        }
                        else if (option == 3)
                        {
                            Console.WriteLine(">>>>> Please Enter the Teacher's ID to Retrive the details");
                            Console.WriteLine(">> Teacher ID:");
                            int Id = Convert.ToInt32(Console.ReadLine());
                            teacherDetail = teachersData.Retrieve(Id);
                            if (!string.IsNullOrEmpty(teacherDetail.tName))
                            {
                                Console.WriteLine(">> >> Retrived Teacher Name is :" + teacherDetail.tName);
                                Console.WriteLine(">> >> Retrived Teacher Class(section) is :" + teacherDetail.className + "(" + teacherDetail.section + ")");
                            }
                            else
                            {
                                //Console.WriteLine("No record found");
                            }
                        }
                        else if (option == 4)
                        {
                            teachersData.RetrieveAll();
                            
                        }
                        else
                        {
                            Console.WriteLine(">> invalid option, Please select a valid option from 1 , 2, 3 or 4 .....");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine(">> >> >> Do you want to continue ? Y/N");
                    continueOrNot = Convert.ToChar(Console.ReadLine());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(">> >> Thank you !!! << <<");
                Console.WriteLine("Please press Enter to close this window ...................");
                Console.ReadKey();
            }
        }
    }
}
