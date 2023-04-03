using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;

namespace STTE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionstring = "Data Source=.;Initial Catalog=STTE;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlCommand cmd = new SqlCommand("Select street,city,stateid from address", conn);
            SqlCommand cmd = new SqlCommand("  select t.name,s.name from STUDENT as s join S_COURSE as sc on s.S_ID=sc.S_ID join T_COURSE as tc on tc.C_ID=sc.C_ID join TEACHER as t on t.T_ID=tc.T_ID", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<teacher> stu = new List<teacher>();
            while (dr.Read())
            {
                teacher details1 = new teacher();
                details1.tname = dr[0].ToString();
                details1.sname = dr[1].ToString();

                stu.Add(details1);
            }
            foreach (teacher details1 in stu)
            {
                Console.Write(details1.tname + " - ");
                Console.WriteLine(details1.sname);
            }
            Console.Read();
        }
    }
}
