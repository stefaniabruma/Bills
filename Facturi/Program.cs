// See https://aka.ms/new-console-template for more information

using Facturi.Domain;
using Facturi.Repository;
using Facturi.Repository.InFileRepositories;
using Facturi.Service;
using Facturi.UI;

IRepository<string,  Document> documentInFileRepository = new DocumentInFileRepository("C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\documents.txt");
IRepository<string, Bill> billInFileRepository = new BillInFileRepository("C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\bills.txt", "C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\documents.txt", "C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\acquisitions.txt");
IRepository<string, Acquisition>  acquisitionInFileRepository = new AcquisitionInFileRepository("C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\acquisitions.txt", "C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\bills.txt", "C:\\Users\\stefa\\RiderProjects\\Facturi\\Facturi\\documents.txt");

Service service =  new Service(documentInFileRepository, billInFileRepository, acquisitionInFileRepository);

Ui ui = new Ui(service);

ui.Run();