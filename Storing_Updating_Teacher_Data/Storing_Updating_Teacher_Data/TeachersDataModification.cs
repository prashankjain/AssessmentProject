using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Storing_Updating_Teacher_Data
{
    public class TeacherDetail 
    {
        public int tId;
        public string tName;
        public string className;
        public char section;

        public TeacherDetail()
        {

        }

    }

    
    class TeachersDataModification
    {
        string filePath = "c:\\examples\\test.txt";
        public string Store(TeacherDetail teacherDetail)
        {
            StreamWriter OurStream;
            OurStream = File.AppendText(filePath);
            OurStream.WriteLine(teacherDetail.tId + ":" + teacherDetail.tName + ":" + teacherDetail.className + ":" + teacherDetail.section);
            //OurStream.WriteLine("\n");
            OurStream.Close();
            Console.WriteLine("Records is stored successfully..");
            return "Data is stored";
        }

        public string update(TeacherDetail teacherDetail)
        {

            DataTable dt = ConvertToDataTable(filePath, 100);

            foreach (var row in dt.Rows)
            {
                DataRow dataRow = 
            }

            return "ok";
        }

        public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable table = new DataTable();
            var fileContents = File.ReadAllLines(filePath);

            var splitFileContents = (from f in fileContents select f.Split(':')).ToArray();

            int maxLength = (from s in splitFileContents select s.Count()).Max();

            for (int i = 0; i < maxLength; i++)
            {
                table.Columns.Add();
            }

            foreach (var line in splitFileContents)
            {
                DataRow row = table.NewRow();
                row.ItemArray = (object[])line;
                table.Rows.Add(row);
            }
            //DataTable tbl = new DataTable();

            //for (int col = 0; col < numberOfColumns; col++)
            //    tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            //string[] lines = System.IO.File.ReadAllLines(filePath);

            //foreach (string line in lines)
            //{
            //    var cols = line.Split(':');

            //    DataRow dr = tbl.NewRow();
            //    for (int cIndex = 0; cIndex < 3; cIndex++)
            //    {
            //        dr[cIndex] = cols[cIndex];
            //    }

            //    tbl.Rows.Add(dr);
            //}

            return table;
        }
    }
}
