namespace CSharpSyntax;
public class MoreTypes
{
    // Todo After Lunch
    // 1. "First Class Citizens"
    // 2. Delegates
    // 3. Properties
    // 4. Constructors
    // 5. More about "kinds" of objects - records

    [Fact]
    public void PropertiesAndStuff()
    {
        var c = new Customer();

        c.Name = "Bob";

        Assert.Equal("Bob", c.Name);

        Object someObj;

        someObj = c;


        someObj = 23;

        //var myLuckyNumbers = new ArrayList()
        //{
        //    c,10, 20, 108
        //};
        var myLuckyNumbers = new List<int>()
        {
           1,10, 20, 108
        };

        var myCustomers = new Dictionary<string, Customer>() {
            { "bob", new Customer() { Name="Bob Smith"} },
            { "sue", new Customer() { Name="Sue Jones"} }
        };

        Assert.Equal(0, myCustomers["sue"].CreditLimit);


        var sum = myLuckyNumbers[0] + myLuckyNumbers[1];

        Assert.Equal(11, sum);


    }
}
