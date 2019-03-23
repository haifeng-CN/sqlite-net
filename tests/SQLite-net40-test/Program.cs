using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLite;
using SQLite_net40_test.Entity;

namespace SQLite_net40_test
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable();
            TestInsert();
            TestUpdate();
            TestDelete();
            TestTable();

            Console.ReadKey();
        }

        static SQLiteConnection CreateConnection()
        {
            var conn = new SQLiteConnection("test.db");
            return conn;
        }

        static void CreateTable()
        {
            var conn = CreateConnection();
            conn.CreateTable<User>();

            Console.WriteLine("create table done.");
        }

        static void TestInsert()
        {
            var u = new User() { UserName = "john", Password = "123", Email = "john@msn.com" };
            var conn = CreateConnection();
            conn.Insert(u);

            var list = conn.Table<User>().ToList();
            foreach(var obj in list)
            {
                Console.WriteLine(string.Format("Id={0},name={1},pass={2},email={3}", obj.Id, obj.UserName, obj.Password, obj.Email));
            }

            Console.WriteLine("insert done.");
        }

        static void TestUpdate()
        { }

        static void TestDelete()
        { }

        static void TestTable()
        {
            Console.WriteLine("\nTest Query and return DataTable");

            var sql = "select * from User";
            var conn = CreateConnection();
            var table = conn.QueryTable(sql);
            int colCount = table.Columns.Count;
            foreach(DataColumn col in table.Columns)
            {
                Console.Write(col.ColumnName);
                Console.Write(",    ");
            }
            Console.Write("\n");

            foreach(DataRow row in table.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    Console.Write(row[i]);
                    Console.Write(",    ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("End of Test.");
        }


    }
}
