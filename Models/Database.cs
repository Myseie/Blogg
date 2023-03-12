using System.Data;
using System.Data.SqlClient;

namespace Blogg.Models
{
    public class Database
    {
        public List<Blogg> GetBloggs()
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM Bloggs";

            var reader = cmd.ExecuteReader();

            var bloggs = new List<Blogg>();

            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string title = reader["Title"].ToString();
                string summary = reader["Summary"].ToString();
                string content = reader["Content"].ToString();

                bloggs.Add(new Blogg()
                {       
                    Id = id,
                    Title = title,
                    Summary = summary,
                    Content = content
                });

            }
            return bloggs;
        }

        public void SaveBlogg(string title, string summary, string content)
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = $"INSERT INTO Bloggs (Title,Summary,Context) VALUES ('{title}','{summary}', '{content}')";
            cmd.ExecuteNonQuery();
        }

        private static SqlCommand GetDbCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=BloggDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            return cmd;
        }
    } 
}
