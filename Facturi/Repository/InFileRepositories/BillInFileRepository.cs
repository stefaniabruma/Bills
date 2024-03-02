using Facturi.Domain;
using Facturi.Repository.utils;

namespace Facturi.Repository.InFileRepositories;

public class BillInFileRepository : InFileRepository<string, Bill>
{
    private string documentFileName;
    private string acquisitionFileName;
        
    public BillInFileRepository(string fileName, string documentFileName, string acquisitionFileName) : base(fileName, null)
    {
        this.documentFileName = documentFileName;
        this.acquisitionFileName = acquisitionFileName;
        loadFromFile();
    }

    private new void loadFromFile()
    {
        List<Document> documents = DataReader.ReadData(documentFileName, LineToEntityMapping.CreateDocument);
        List<Acquisition> acquisitions = DataReader.ReadData(acquisitionFileName, LineToEntityMapping.CreateAcquisition);

        using (StreamReader sr = new StreamReader(fileName))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Bill entity = LineToEntityMapping.CreateBill(s);
                
                var document = documents.Find(doc => doc.Id == entity.Id);
                entity.Name = document.Name;
                entity.EmissionDate = document.EmissionDate;
                
                entity.Acquisitions = acquisitions.FindAll(ac => ac.Bill.Id == entity.Id);
                
                entity.Acquisitions.ForEach(ac =>
                {
                    ac.Bill = entity;
                });

                _dictionary.Add(entity.Id, entity);
            }
        }
    }
}