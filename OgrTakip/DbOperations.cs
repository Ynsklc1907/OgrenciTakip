using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrTakip
{
    public static class DbOperations
    {
        static string connectionString = "Data Source=.;Initial Catalog=myShop;Integrated Security=True";

        public static void InsertData(Student s)
        {
            string queryString = String.Format("insert into Students values('{0}','{1}',{2})", s.Name, s.Surname, s.Age);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static List<Student> LoadData()
        {
            List <Student> studentList = new List<Student>();

            string queryString = "select * from Students";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                connection.Close();
            }

            foreach (DataRow item in dt.Rows)
            {
                Student s1 = new Student();
                s1.Id = Convert.ToInt32(item["Id"]);
                s1.Name = item["Name"].ToString();
                s1.Surname = item["SurName"].ToString();
                s1.Age = Convert.ToInt32(item["Age"]);

                studentList.Add(s1);
            }

            return studentList;
        }

        public static void DeleteStudent(int Id)
        {
            string queryString = String.Format("Delete from Students where Id={0}", Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
