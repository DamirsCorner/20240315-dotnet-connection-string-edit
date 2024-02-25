using MySqlConnector;

namespace EditConnectionString;

public static class ConnectionStringExtensions
{
    public static string ApplyRequiredOptions(this string connectionString)
    {
        var builder = new MySqlConnectionStringBuilder(connectionString)
        {
            GuidFormat = MySqlGuidFormat.Binary16,
            AllowLoadLocalInfile = true
        };
        return builder.ConnectionString;
    }
}
