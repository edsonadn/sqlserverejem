using System;

namespace ConsoleApp1
{
    public class program
    {
        static void Main()
        {
            ConnectionDB connection = new ConnectionDB();
            connection.Open();
            connection.viewData("Select * from dbo.students;");
            connection.Close();
        }


    }
}
