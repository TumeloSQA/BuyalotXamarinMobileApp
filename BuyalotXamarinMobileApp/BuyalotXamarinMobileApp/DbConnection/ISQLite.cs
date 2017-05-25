using SQLite.Net;

namespace BuyalotXamarinMobileApp.DbConnection
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
