using System.Web;

/// <summary>
/// Summary description for DbConn
/// </summary>
public class DbConn
{
    public DbConn()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string DbConnection()
    {
        string dbPath = HttpContext.Current.Server.MapPath("/db/csharpaccessdb.MDB");

        string dbConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + "";

        return dbConnectionString;
    }
}