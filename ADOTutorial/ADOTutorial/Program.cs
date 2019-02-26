using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADOTutorial
{
    class Program
    {
        static string connString = "Data Source = .; Initial Catalog = MainGeton; Integrated Security = true; Pooling = true";
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("MainGeton");
            SqlConnection connection = new SqlConnection(connString);
            SqlDataAdapter adapter = CreateCustomerAdapter(connection);
            adapter.TableMappings.Add("Table", "Sarea");
            adapter.Fill(dataSet);
            //Insert
            DataRow row = dataSet.Tables["Sarea"].NewRow();
            row[0] = 300;
            row[1] = "Test";
            dataSet.Tables["Sarea"].Rows.Add(row);
            row = dataSet.Tables["Sarea"].NewRow();
            row[0] = 400;
            row[1] = "Test";
            dataSet.Tables["Sarea"].Rows.Add(row);
            //adapter.Update(dataSet);

            //Update
            foreach (DataRow r in dataSet.Tables["Sarea"].Rows)
            {
                if (r[0].ToString() == "300")
                {
                    r[0] = 500;
                }
            }
            adapter.Update(dataSet);

            //Delete
            foreach (DataRow r in dataSet.Tables["Sarea"].Rows)
            {
                if (r[0].ToString() == "200" || r[0].ToString() == "400" || r[0].ToString() == "500")
                {
                    r.Delete();
                }
            }
            adapter.Update(dataSet);
            dataSet.Tables["Sarea"].AcceptChanges();
        }
        public static SqlDataAdapter CreateCustomerAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand("SELECT * FROM Sarea", connection);
            adapter.SelectCommand = command;

            // Create the InsertCommand.
            command = new SqlCommand(
                "INSERT INTO Sarea (SareaID, SareaName) " +
                "VALUES (@SareaID, @SareaName)", connection);

            // Add the parameters for the InsertCommand.
            command.Parameters.Add("@SareaID", SqlDbType.NChar, 5, "SareaId");
            command.Parameters.Add("@SareaName", SqlDbType.NVarChar, 40, "SareaName");

            adapter.InsertCommand = command;

            // Create the UpdateCommand.
            command = new SqlCommand(
                "UPDATE Sarea SET SareaId = @SareaID, SareaName = @SareaName " +
                "WHERE SareaId = @oldSareaID", connection);

            // Add the parameters for the UpdateCommand.
            command.Parameters.Add("@SareaID", SqlDbType.NChar, 5, "SareaId");
            command.Parameters.Add("@SareaName", SqlDbType.NVarChar, 40, "SareaName");
            SqlParameter parameter = command.Parameters.Add(
                "@oldSareaID", SqlDbType.NChar, 5, "SareaId");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;

            // Create the DeleteCommand.
            command = new SqlCommand(
                "DELETE FROM Sarea WHERE SareaId = @SareaID", connection);

            // Add the parameters for the DeleteCommand.
            parameter = command.Parameters.Add(
                "@SareaID", SqlDbType.NChar, 5, "SareaId");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.DeleteCommand = command;

            return adapter;
        }
    }
}
