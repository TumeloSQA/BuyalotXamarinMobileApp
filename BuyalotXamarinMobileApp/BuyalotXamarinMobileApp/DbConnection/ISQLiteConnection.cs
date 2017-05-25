using SQLite.Net.Async;

namespace BuyalotXamarinMobileApp.DbConnection
{
    public interface ISQLiteConnection
    {
        string GetDataBasePath();
        SQLiteAsyncConnection GetConnection();
    }
}

