namespace Policlinica.DB;

public class ServiceSelected
{
    
    public Service Service { get; set; }
    
    public bool IsSelected { get; set; }

    public ServiceSelected(Service service)
    {
        Service = service;
    }

}
