namespace Facturi.Domain;

public class Document : Entity<string>
{
    public string Name { get; set; }
    
    public DateTime EmissionDate { get; set; }

    public override string ToString()
    {
        return base.ToString() + " " + Name + " " + EmissionDate;
    }
}