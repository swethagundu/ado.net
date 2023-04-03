using Employee;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeD
{
    internal class Calling
    {
        static void Main(string[] args)
        {

            //retriving data using Getvalue
            Operations operations = new Operations();
            // operations.Retrive();  //using Get Value
            // operations.RetriveMclasses(); //using list-while-foreach
            //---------------------------------------
            //retriving data using stored procedure
            // operations.StoredpRetrive();
            //--------------------------
            //inserting values 
            /* Department department = new Department();
             department.deptno = 55;
             department.dname = "QA";
             department.loc = "manassas";
             operations.Insert(department); */
            //-----------------------------------------------------------
            //inserting values using stored procedure
           /* Department department = new Department();
            department.deptno = 57;
            department.dname = "QA";
            department.loc = "manassas";
            operations.Insert_storedp(department); */
            //-----------------------------------------------------------
            
           // FileOperations fileOperations = new FileOperations();
            // fileOperations.FileExist();  //file exist
            //-----------------------------------------------------------
            //fileOperations.FileReadAlllines(); //display files of specific lines
            // fileOperations.FileReadAllText(); //display full lines 
            //fileOperations.FileCopy();  //copying file to another place
           // fileOperations.FileDelete(); //file delete



            Console.Read();
        }
    }
}
