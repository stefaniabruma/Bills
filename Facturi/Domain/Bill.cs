namespace Facturi.Domain;

public class Bill : Document
{
    public DateTime DueDate { get; set; }
    
    public List<Acquisition> Acquisitions { get; set; }

    public Category Category { get; set; }

    public override string ToString()
    {
        return base.ToString() + " " + DueDate + " " + Category;
    }
}