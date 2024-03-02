using Facturi.Domain;
using Facturi.Repository.utils;

namespace Facturi.Repository.InFileRepositories;

public class AcquisitionInFileRepository : InFileRepository<string, Acquisition>
{
    private string billFileName;
    private string documentFileName;
    public AcquisitionInFileRepository(string fileName, string billFileName, string documentFileName) : base(fileName, null)
    {
        this.billFileName = billFileName;
        this.documentFileName = documentFileName;
        loadFromFile();
    }

    private new void loadFromFile()
    {
        List<Document> documents = DataReader.ReadData(documentFileName, LineToEntityMapping.CreateDocument);
        List<Bill> bills = DataReader.ReadData(billFileName, LineToEntityMapping.CreateBill);
        
        
        using (StreamReader sr = new StreamReader(fileName))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Acquisition entity = LineToEntityMapping.CreateAcquisition(s);
                _dictionary.Add(entity.Id, entity);
                
                entity.Bill = bills.Find(bill => bill.Id == entity.Bill.Id);

                var document = documents.Find(doc => doc.Id == entity.Bill.Id);
                entity.Bill.Name = document.Name;
                entity.Bill.EmissionDate = document.EmissionDate;
            }
            
            foreach (var acquisition in FindAll())
            {
                acquisition.Bill.Acquisitions = FindAll().ToList().FindAll(ac => ac.Bill.Id == acquisition.Bill.Id);
            }
        }
    }
}