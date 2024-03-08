namespace TodosApi;

public class AdvancedFormatters : IFormatDisplayInformation
{
    public string FormatName(string firstName, string lastName)
    {
        return $"{lastName}, {firstName}";
    }
}
