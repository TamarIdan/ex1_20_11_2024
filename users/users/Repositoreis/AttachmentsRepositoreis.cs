using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using users.Models;

namespace users.Repositoreis
{
    public class AttachmentsRepositoreis : IAttachmentsRepositoreis
    {
        private readonly string _connectionString;

        public AttachmentsRepositoreis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable CreateAttachments(string name, string path, string dateUplode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("Add_Attachments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@a_name", name));
                    command.Parameters.Add(new SqlParameter("@a_path", path));
                    command.Parameters.Add(new SqlParameter("@a_dateUplode", dateUplode));

                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public bool ProcessTransaction(Attachment attachment, Models.Task task)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Description, IsDone, CreateDate)  VALUES (@Description, @IsDone, @CreateDate)", connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@Description", task.Description);

                        command1.Parameters.AddWithValue("@IsDone", task.IsDone);
                        command1.Parameters.AddWithValue("@CreateDate", task.CreatDate);
                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachments (name, path, dateUplode) VALUES (@name, @path,@dateUplode)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@name", attachment.Name);
                        command2.Parameters.AddWithValue("@path", attachment.Path);
                        command2.Parameters.AddWithValue("@dateUplode", attachment.DateUplode);
                        command2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
