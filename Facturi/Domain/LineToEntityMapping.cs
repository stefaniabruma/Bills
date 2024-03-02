using System.Globalization;

namespace Facturi.Domain;

public class LineToEntityMapping
{
    public static Acquisition CreateAcquisition(string line)
    {
        string[] fields = line.Split(','); 
        return new Acquisition()
        {
            Id = fields[0],
            Product = fields[1],
            Quantity = Convert.ToInt32(fields[2]),
            Price = Convert.ToDouble(fields[3], CultureInfo.InvariantCulture),
            Bill = new Bill()
            {
                Id = fields[4]
            }
        };
    }
    
    public static Document CreateDocument(string line)
    {
        string[] fields = line.Split(','); 
        return new Document()
        {
            Id = fields[0],
            Name = fields[1],
            EmissionDate = Convert.ToDateTime(fields[2])
        };
    }
    
    public static Bill CreateBill(string line)
    {
        string[] fields = line.Split(','); 
        return new Bill()
        {
            Id = fields[0],
            DueDate = Convert.ToDateTime(fields[1]),
            Category = (Category)Enum.Parse(typeof(Category), fields[2])
        };
    }
}