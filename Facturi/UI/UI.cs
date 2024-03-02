namespace Facturi.UI;

public class Ui
{
    private Service.Service _service;

    public Ui(Service.Service service)
    {
        this._service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Introduce exercise number:");
            int cmd = Convert.ToInt32(Console.ReadLine());

            switch (cmd)
            {
                case 1:
                    Execute1();
                    break;
                case 2:
                    Execute2();
                    break;
                case 3:
                    Execute3();;
                    break;
                case 4:
                    Execute4();;
                    break;
                case 5:
                    Execute5();;
                    break;
                case 0:
                    return;
            }
        }
    }

    public void Execute1()
    {
        foreach (var s in _service.DocumentsEmittedIn2023())
        {
            Console.WriteLine(s);
        }
    }
    
    public void Execute2()
    {
        foreach (var s in _service.BillsDueThisMonth())
        {
            Console.WriteLine(s);
        }
    }
    
    public void Execute3()
    {
        foreach (var s in _service.BillsWithAtLeast3AcquiredProducts())
        {
            Console.WriteLine(s);
        }
    }
    
    public void Execute4()
    {
        foreach (var s in _service.AcquisitionWithUtilitiesCat())
        {
            Console.WriteLine(s);
        }
    }
    
    public void Execute5()
    {
        Console.WriteLine( _service.CategoryWithHighestExpenses());
    }
}
