using Facturi.Domain;

namespace Facturi.Repository.InFileRepositories;

public class DocumentInFileRepository : InFileRepository<string, Document>
{
    public DocumentInFileRepository(string fileName) : base(fileName, LineToEntityMapping.CreateDocument)
    {
    }
}