namespace CSharpSyntax;
public class Customer
{
    //private string _name = ""; // backing field
    //public string Name
    //{
    //    get { return _name; }
    //     set { _name = value; }
    //}
    public string Name { get; set; } = "";

    public decimal CreditLimit { get; private set; }

    public override string ToString()
    {
        return $"{Name} has {CreditLimit: c}";
    }



}
