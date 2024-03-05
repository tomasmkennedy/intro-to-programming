namespace TodosApi.UnitTests;
public class FormattingNames
{
    [Theory]
    [InlineData("Bob", "Smith", "Smith, Bob")]
    [InlineData("Jill", "Jones", "Jones, Jill")]
    public void NamesAreFormattedProperly(string firstName, string lastName, string expected)
    {
        var utils = new Utils();

        var fullName = utils.FormatName(firstName, lastName);

        Assert.Equal(expected, fullName);
    }
}
