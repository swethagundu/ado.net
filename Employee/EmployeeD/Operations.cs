using Employee;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeD
{
    public class Operations
    {
        public void Retrive()
        {
            //SQl connection
            string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT ename,deptno FROM EMP", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //retriving data using Getvalue
            /* while (dr.Read())
             {
                 string row = dr.GetValue(0) + " -" + dr.GetValue(1);
                 Console.WriteLine(row);
             } */
            //-----------------------------
            //retriving data using list in while and foreach
            List<EmployeeInfo> emp = new List<EmployeeInfo>();
            while (dr.Read())
            {
                EmployeeInfo employeeInfo = new EmployeeInfo();
                employeeInfo.ename = dr[0].ToString();
                employeeInfo.deptno = dr[1].GetHashCode();
                emp.Add(employeeInfo);
                //Console.WriteLine(employeeInfo.ename + " - " + employeeInfo.deptno);
            }
            foreach (EmployeeInfo employeeInfo in emp)
            {
                Console.WriteLine(employeeInfo.ename + " - " + employeeInfo.deptno);
            }


        }

        public void RetriveMclasses()
        {
            string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select ename,dname from dept as d join emp as e on d.DEPTNO=e.DEPTNO", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Employee Name" + "   " + "Department Name");
            while (dr.Read())
            {
                EmployeeInfo employeeInfo = new EmployeeInfo();
                Department department = new Department();
                employeeInfo.ename = dr[0].ToString();
                department.dname = dr[1].ToString();
                
                Console.WriteLine(dr[0].ToString() + "             " + department.dname);
            }


        }

        public void StoredpRetrive()
        {
            string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open ();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "_DATA";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Department department = new Department();
                EmployeeInfo empinfo = new EmployeeInfo();
                department.dname = dr[0].ToString();
                empinfo.ename = dr[1].ToString();
                Console.WriteLine(dr[0].ToString() + " - " + dr[1].ToString());
            }
           
             
        }

        public void Insert(Department department)
        {
            string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = " INSERT INTO [dbo].[DEPT](DEPTNO,DNAME,LOC)" +
                "VALUES(@DEPTNO,@DNAME,@LOC)";

            //passing values
            cmd.Parameters.AddWithValue("@DEPTNO", department.deptno);
            cmd.Parameters.AddWithValue("@DNAME", department.dname);
            cmd.Parameters.AddWithValue("@LOC", department.loc);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                conn.Close();
                Console.Read();
            }



        }
        public void Insert_storedp(Department department)
        {
            string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT_DEPT";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            //passing values
            cmd.Parameters.AddWithValue("@dept_no", department.deptno);
            cmd.Parameters.AddWithValue("@dept_name", department.dname);
            cmd.Parameters.AddWithValue("@location", department.loc);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                conn.Close();
                Console.Read();
            }

        }

        //public void RetriveMclasses_foreach()
        //{
        //    string connectionstring = "Data Source=.;Initial Catalog=ScottDB;Integrated Security=True";

        //    SqlConnection conn = new SqlConnection(connectionstring);
        //    SqlCommand cmd = new SqlCommand("select ename,dname from dept as d join emp as e on d.DEPTNO=e.DEPTNO", conn);
        //    conn.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    Console.WriteLine("Department Name" + "   " + "Employee Name");
        //    List<Department> list = new List<Department>();
        //    List<EmployeeInfo> employees = new List<EmployeeInfo>();
        //    while (dr.Read())
        //    {
        //        EmployeeInfo employeeInfo = new EmployeeInfo();
        //        Department department = new Department();
        //        employeeInfo.ename = dr[0].ToString();
        //        department.dname = dr[1].ToString();
        //        list.Add(department);
        //        employees.Add(employeeInfo);
        //        Console.WriteLine(dr[0].ToString() + " " + department.dname);

        //        string list = dr[1].ToString();
        //    }
        //    foreach (Department department1 in list)
        //    {
        //        Console.WriteLine(department1.dname);
        //    }
        //    Console.Write(" ");
        //        foreach (EmployeeInfo employeeInfo in employees)
        //        {
        //            Console.WriteLine(employeeInfo.ename);
        //        }
            


        //}
    }
}