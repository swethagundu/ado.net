using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace STTE
{
    internal class Operations
    {
        public void DBRetrive()
        {
            //SQl connection
            string connectionstring = "Data Source=.;Initial Catalog=STTE;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = " select tname,sname from STUDENT as s join S_COURSE as sc on s.S_ID=sc.S_ID join T_COURSE as tc on tc.C_ID=sc.C_ID\r\n join TEACHER as t on t.T_ID=tc.T_ID";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //retriving data using Getvalue
            //while (dr.Read())
            //{
            //    string row = dr.GetValue(0) + " -" + dr.GetValue(1);
            //    Console.WriteLine(row);
            //} 
            //-----------------------------
            //retriving data using list in while and foreach
            List<Student> data = new List<Student>();
            while (dr.Read())
            {
                Student student = new Student();
                string row = dr.GetValue(0) + " -" + dr.GetValue(1);
                 data.Add(student);
            }
            foreach (Student student1 in data) 
            {
                Console.WriteLine(student1);
            }
            //List<> emp = new List<EmployeeInfo>();
            //while (dr.Read())
            //{
            //    EmployeeInfo employeeInfo = new EmployeeInfo();
            //    employeeInfo.ename = dr[0].ToString();
            //    employeeInfo.deptno = dr[1].GetHashCode();
            //    emp.Add(employeeInfo);
            //    //Console.WriteLine(employeeInfo.ename + " - " + employeeInfo.deptno);
            //}
            //foreach (EmployeeInfo employeeInfo in emp)
            //{
            //    Console.WriteLine(employeeInfo.ename + " - " + employeeInfo.deptno);
            //}
            Console.ReadLine();
        }
    }
}
