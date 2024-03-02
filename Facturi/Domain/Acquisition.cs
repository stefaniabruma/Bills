namespace Facturi.Domain;

public class Acquisition  : Entity<string>
{
    public string Product { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }
    
    public Bill Bill { get; set; }
    
}