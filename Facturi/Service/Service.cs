using Facturi.Domain;
using Facturi.Repository;

namespace Facturi.Service;

public class Service
{
    private IRepository<string, Document> documentRepo;
    private IRepository<string, Bill> billRepo;
    private IRepository<string, Acquisition> acquisitionRepo;

    public Service(IRepository<string, Document> documentRepo, IRepository<string, Bill> billRepo, IRepository<string, Acquisition> acquisitionRepo)
    {
        this.documentRepo = documentRepo;
        this.billRepo = billRepo;
        this.acquisitionRepo = acquisitionRepo;
    }

    public List<string> DocumentsEmittedIn2023()
    {
        return
            (from document in documentRepo.FindAll()
                where document.EmissionDate.Year == 2023
                select document.Name + " " + document.EmissionDate)
            .ToList();
    }

    public List<string> BillsDueThisMonth()
    {
        return
            (from bill in billRepo.FindAll()
                where bill.DueDate.Month == DateTime.Now.Month
                select bill.Name + " " + bill.DueDate)
            .ToList();
    }


    public List<string> BillsWithAtLeast3AcquiredProducts()
    {
        int noProducts = 0;
        return
            (from bill in billRepo.FindAll()
                where (noProducts = bill.Acquisitions.Sum(ac => ac.Quantity)) >= 3
                select bill.Name + " " + noProducts)
            .ToList();
    }

    public List<string> AcquisitionWithUtilitiesCat()
    {
        return
            (from acquisition in acquisitionRepo.FindAll()
                where acquisition.Bill.Category == Category.Utilities
                select acquisition.Product + " " + acquisition.Bill.Name)
            .ToList();
    }

    public Category CategoryWithHighestExpenses()
    {
        return
            (from bill in billRepo.FindAll()
                group bill by bill.Category into grouped
                orderby grouped.ToList().Sum(b => b.Acquisitions.Sum(ac => ac.Price * ac.Quantity)) descending
                select grouped.Key)
            .ToList()[0];

    }
}