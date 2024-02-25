using FluentAssertions;
using MySqlConnector;

namespace EditConnectionString;

public class ConnectionStringTests
{
    [Test]
    [TestCase("server=localhost;user=root;password=root;database=blogsample")]
    [TestCase(
        "server=localhost;user=root;password=root;database=blogsample;AllowLoadLocalInfile=false"
    )]
    [TestCase(
        "server=localhost;user=root;password=root;database=blogsample;AllowLoadLocalInfile=true"
    )]
    public void SetsLocalInfileOption(string originalConnectionString)
    {
        var modifiedConnectionString = originalConnectionString.ApplyRequiredOptions();

        var builder = new MySqlConnectionStringBuilder(modifiedConnectionString);
        builder.AllowLoadLocalInfile.Should().BeTrue();
    }

    [Test]
    [TestCase("server=localhost;user=root;password=root;database=blogsample")]
    [TestCase("server=localhost;user=root;password=root;database=blogsample;GuidFormat=Char36")]
    [TestCase("server=localhost;user=root;password=root;database=blogsample;GuidFormat=Binary16")]
    public void SetsGuidFormatOption(string originalConnectionString)
    {
        var modifiedConnectionString = originalConnectionString.ApplyRequiredOptions();

        var builder = new MySqlConnectionStringBuilder(modifiedConnectionString);
        builder.GuidFormat.Should().Be(MySqlGuidFormat.Binary16);
    }
}
