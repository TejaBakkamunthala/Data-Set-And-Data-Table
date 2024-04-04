using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace DataTable1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* DataTable dt = new DataTable();

             dt.TableName = "Student";
             DataColumn id = new DataColumn("ID", typeof(int));
             id.AutoIncrement = true;
             id.AutoIncrementSeed = 2;
             id.AutoIncrementStep = 2;
             id.Unique = true;
             id.Caption = "studentID";

             dt.Columns.Add(id);

             DataColumn name = new DataColumn("Name", typeof(string));
             name.MaxLength = 50;
             name.AllowDBNull = false;
             dt.Columns.Add(name);

             DataColumn dep = new DataColumn("Department", typeof(string));
             dep.MaxLength = 40;
             dep.AllowDBNull = false;
             dt.Columns.Add(dep);





             dt.PrimaryKey = new DataColumn[] { id };


             DataRow row1=dt.NewRow();
           //  row1["id"] = 101;
             row1["name"] = "TEJA";
             row1["Department"] = "MECHNAICAL";
             dt.Rows.Add(row1);

             dt.Rows.Add(null, "Sunil","MECHANICAL");
             dt.Rows.Add(null, "BHANU","AERONAUTICAL");

             dt.Rows.Add(null, "LOKESH","EEE");
             dt.Rows.Add(null, "SOMESH","ECE");

             dt.Rows.Add(null, "RAKESH","CSE");
             dt.Rows.Add( null,"SURESH","IT");

             foreach (DataRow row in dt.Rows)
             {
                 Console.WriteLine(row[0] +" "+ row[1]+"  " + row[2]);
             }
               */


            string connection = @"Data Source=LAPTOP-9LF56231\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            //Console.WriteLine("Connection established");
            //Console.WriteLine("Enter EMPID");
            //int EMPID =int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter ENAME");
            //String ENAME=Console.ReadLine();
            //Console.WriteLine("ENTER SALARY");
            //int SALARY =int.Parse(Console.ReadLine());
            //Console.WriteLine("ENTER DEPTNO");
            //int DEPTNO=int.Parse(Console.ReadLine());

            //string insertQuery = "INSERT INTO EMP VALUES(" + EMPID + ",'" + ENAME + "'," + SALARY + "," + DEPTNO + " )";

            //SqlCommand cmd=new SqlCommand(insertQuery,conn);
            //cmd.ExecuteNonQuery();

            //Console.WriteLine("DATA INSERED SUCCESSFULLY ");



            string selectquery = "SELECT * FROM EMP";

            SqlCommand cmd2=new SqlCommand(selectquery, conn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
  
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Console.WriteLine("Original Data");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row[0]+" " + row[1] +" "+ row[2] +" "+ row[3]);
            }

            DataTable dt2 = dt.Copy();

            
            Console.WriteLine();
            Console.WriteLine("Copy Data");
            foreach (DataRow row in dt2.Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + row[2] + row[3]);
            }

            Console.WriteLine();
            Console.WriteLine("Clone Data");
            DataTable dt3=dt.Clone();
            foreach(DataRow dr in dt3.Rows)
            {
                Console.WriteLine(dr[0]+"  " + dr[1]+" " + dr[2]+" " + dr[3]);
            }

            Console.WriteLine();
            Console.WriteLine("Delete ");

           
            foreach(DataRow dr in dt2.Rows)
            {
                if (Convert.ToInt32(dr[0]) == 1)
                {
                    dr.Delete();

                }
            }

            dt2.AcceptChanges();
           //dt2.RejectChanges();

            Console.WriteLine("after deleting print the data");
            foreach (DataRow dr in dt2.Rows)
            {
                Console.WriteLine(dr[0] +" "+ dr[1]+" " + dr[2]+" " + dr[3]);
            }



            Console.WriteLine();
            Console.WriteLine("Remove Data");

            foreach(DataRow dr in dt.Select())
            {
                if (Convert.ToInt32(dr[0]) == 1)
                { 
                    dt.Rows.Remove(dr);
                }
            }

            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr[0]+" " + dr[1]+" " + dr[2]+" " + dr[3]);

            }

            Console.WriteLine("If u apply remove no need to run accept changess");



        }
    }
}
