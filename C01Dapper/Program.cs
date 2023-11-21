// See https://aka.ms/new-console-template for more information
using Dapper;
using C01Dapper.Models;
using System.Data.SqlClient;

string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dapSchool;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

using (var connection = new SqlConnection(cs))
{
    connection.Open();
    var ver = connection.ExecuteScalar<string>("SELECT @@VERSION");
    Console.WriteLine(ver);
    List<Student> students = connection.Query<Student>("SELECT * FROM Students WHERE Firstname LIKE 'J%' ORDER BY Lastname").ToList();
    foreach(Student st in students)
    {
        Console.WriteLine(st.Firstname + " " + st.Lastname);
    }
    List<string> studentNames = connection.Query<string>("SELECT Lastname FROM Students").ToList();
    foreach (var st in studentNames)
    {
        Console.WriteLine(st);
    }
    string? newFirstname = Console.ReadLine();
    string? newLastname = Console.ReadLine();
    int newGrade = Random.Shared.Next(4);
    var res = connection.Execute("INSERT INTO Students (Firstname, Lastname, Grade) VALUES ('" 
        + newFirstname 
        + "','"
        + newLastname
        + "',"
        + newGrade
        + ")");
    Console.WriteLine(res);
    var res2 = connection.Execute("UPDATE Students SET Grade = 1");
    Console.WriteLine(res2);
    var res3 = connection.Execute("DELETE Students WHERE Firstname = 'Jiří'");
    Console.WriteLine(res3);
}