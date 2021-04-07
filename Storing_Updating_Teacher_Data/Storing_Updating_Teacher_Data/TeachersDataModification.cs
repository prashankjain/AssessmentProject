using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Storing_Updating_Teacher_Data
{
    /// <summary>
    ///  Containing four variables to store 
    ///  Teacher’s ID (int)
    ///  Name (string)
    ///  Class (string) 
    ///  and Section (char)   
    /// </summary>
    
    public class TeacherDetail
    {
        public int tId { get; set; }
        public string tName { get; set; }
        public string className { get; set; }
        public char section { get; set; }

        public TeacherDetail()
        {
        }
    }

    /// <summary>
    /// Containing methods which will be using to 
    ///    a.File Creation
    ///    b.Storing
    ///    c.Retrieving
    ///    d.Updating
    ///    e.Retrieving all records
    /// </summary>
    class TeachersDataModification
    {
        string filePath = "c:\\Teachers_Data\\teachersData.txt";

        /// <summary>
        /// Created this method to create the file if program executes very first time in any machine.
        /// </summary>
        public void FileCreation()
        {
            try
            {
                StreamWriter OurStream;
                OurStream = File.AppendText(filePath);
                OurStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Created this method to store the teacher’s details in text file.
        /// </summary>
        /// <param name="teacherDetail"></param>
        /// <returns></returns>

        public bool Store(TeacherDetail teacherDetail)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    if (File.ReadAllText(filePath).Length > 0)
                    {
                        if (File.ReadAllText(filePath).Contains(teacherDetail.tId.ToString()))
                        {
                            Console.WriteLine("This ID is already exist, please enter a new ID.");
                        }
                        return false;
                    }
                    else
                    {
                        StreamWriter OurStream;
                        OurStream = File.AppendText(filePath);
                        OurStream.WriteLine(teacherDetail.tId
                            + ","
                            + teacherDetail.tName
                            + ","
                            + teacherDetail.className
                            + ","
                            + teacherDetail.section);
                        OurStream.Close();
                        Console.WriteLine("Record is stored successfully........");
                        return true;
                    }
                }
                else
                {
                    FileCreation();
                    Store(teacherDetail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        /// <summary>
        /// Created this method to update the teacher’s details based on provided teacher’s ID in text file
        /// </summary>
        /// <param name="teacherDetail"></param>
        /// <returns></returns>

        public bool Update(TeacherDetail teacherDetail)
        {
            bool returnVal = false;
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File is not Exist");
                    return false;
                }
                else
                {
                    if (!File.ReadAllText(filePath).Contains(teacherDetail.tId.ToString()))
                    {
                        Console.WriteLine("This ID is NOT exist, please enter a valid ID.");
                        return false;
                    }
                    else
                    {
                        DataTable table = new DataTable();
                        var fileContents = File.ReadAllLines(filePath);
                        var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
                        StreamWriter OurStream;
                        File.Delete(filePath);
                        foreach (var line in splitFileContents)
                        {
                            if (!string.IsNullOrWhiteSpace(line[0]))
                            {
                                if (line[0] == teacherDetail.tId.ToString())
                                {
                                    line[1] = teacherDetail.tName;
                                    line[2] = teacherDetail.className;
                                    line[3] = teacherDetail.section.ToString();
                                }
                                OurStream = File.AppendText(filePath);
                                OurStream.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + line[3]);
                                OurStream.Close();
                            }
                        }
                        Console.WriteLine("Records is updated successfully.......");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

        /// <summary>
        /// Created this method to retrieve the teacher’s details based on provided  teacher’s ID from text file
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TeacherDetail Retrieve(int ID)
        {
            TeacherDetail teacherDetail = new TeacherDetail();
            try
            {

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File is not Exist");
                    return teacherDetail;
                }
                else
                {
                    if (!File.ReadAllText(filePath).Contains(ID.ToString()))
                    {
                        Console.WriteLine("This ID is NOT exist, please enter a valid ID to retrieve the data.");
                    }
                    else
                    {
                        DataTable table = new DataTable();
                        var fileContents = File.ReadAllLines(filePath);
                        var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
                        foreach (var line in splitFileContents)
                        {
                            if (!string.IsNullOrWhiteSpace(line[0]))
                            {
                                if (line[0] == ID.ToString())
                                {
                                    teacherDetail.tName = line[1];
                                    teacherDetail.className = line[2];
                                    teacherDetail.section = Convert.ToChar(line[3]);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return teacherDetail;

        }

        /// <summary>
        /// Created this method to retrieve all the teacher’s details from text file
        /// </summary>
        public void RetrieveAll()
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);

                if (!File.Exists(filePath))
                    Console.WriteLine("File is not Exist");
                else
                {
                    string allRecords = sr.ReadLine(); ;
                    Console.WriteLine("The content of file {0}:", filePath);

                    while (allRecords != null)
                    {
                        Console.WriteLine(allRecords);
                        allRecords = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
