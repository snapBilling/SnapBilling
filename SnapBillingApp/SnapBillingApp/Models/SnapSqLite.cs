
using System.IO;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace SnapBillingApp.Models
{
    public class SnapSqLite
    {
        public const string DbName = "db-sqlite";

        public static SQLiteConnection GetSqlConnection()
        {
            string path = Path.Combine(ApplicationData.
                Current.LocalFolder.Path, DbName);

            SQLiteConnection conn = new SQLiteConnection(new
                SQLitePlatformWinRT(), path);

            return conn;
        }
    }
}
