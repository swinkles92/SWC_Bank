using Microsoft.Data.Sqlite;
namespace Bank;

public class DbHelpers
{
	/// <summary>
	/// This method creates an SqliteConnection object and opens it with
	/// either the default, or a provided, path.
	/// </summary>
	/// <param name="optionalPath">File path name for the database</param>
	/// <returns>Opened SqliteConnection Object</returns>
	public SqliteConnection CreateConnection(string optionalPath = "" +
            "Data Source = " +
            "/Users/samuelwinkles/Documents/CSharpPrograms/swcbank.db;")
	{
		SqliteConnection sqlite_conn = new();
		sqlite_conn.ConnectionString = optionalPath;
		sqlite_conn.Open();

		return sqlite_conn;
	}
	public void ReadData(SqliteConnection sqlite_conn)
	{
        SqliteDataReader sqlite_datareader;
        SqliteCommand sqlite_cmd = sqlite_conn.CreateCommand();
        sqlite_cmd.CommandText = "SELECT * FROM users";
        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while (sqlite_datareader.Read())
        {
            string reader = sqlite_datareader.GetString(0);
            WriteLine(reader);
        }
        sqlite_conn.Close();
    }
}

