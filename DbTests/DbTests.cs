using Microsoft.Data.Sqlite;
namespace Bank;

public class DbTests
{
    /*
     * CreateConnection() method tests
     */

    // Ensures that the CreateConnection() method in
    // the DbHelpers file (in the Bank.Db project) correctly creates
    // an SqliteConnection object
    [Fact]
    public void CreateConnectionTypeTest()
    {
        DbHelpers dbHelpers = new DbHelpers();
        var sqlite_conn = dbHelpers.CreateConnection();
        Assert.True(sqlite_conn is SqliteConnection);
    }
    // Ensures that the aforementioned CreateConnection() method
    // results in an SqliteConnection with an Open state
    [Fact]
    public void CreateConnectionOpenTest()
    {
        DbHelpers dbHelpers = new DbHelpers();
        var sqlite_conn = dbHelpers.CreateConnection();
        Assert.True(sqlite_conn.State == System.Data.ConnectionState.Open);
    }
    // Ensures that the CreateConnection() method will be correctly assigned
    // the optional path parameter if no other path parameter has been given
    [Fact]
    public void CreateConnectionDefaultConnectionStringTest()
    {
        DbHelpers dbHelpers = new DbHelpers();
        var sqlite_conn = dbHelpers.CreateConnection();
        Assert.True(sqlite_conn.ConnectionString.Equals("" +
            "Data Source = " +
            "/Users/samuelwinkles/Documents/CSharpPrograms/swcbank.db;"));
    }

    /*
     * ReadData() method tests
     */

    [Fact]
    public void ReadDataTest()
    {
        DbHelpers dbHelpers = new DbHelpers();
        var sqlite_conn = dbHelpers.CreateConnection();
        dbHelpers.ReadData(sqlite_conn);
    }

    [Fact]
    public void DatabaseConnectTest()
    {
        using(SwcbankContext db = new())
        {
            Assert.True(db.Database.CanConnect());
        }
    }
}
