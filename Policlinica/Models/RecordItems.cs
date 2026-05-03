namespace Policlinica.DB;

public class RecordItems
{
    public int Id { get; set; }
    
    public int ServiceId { get; set; }
    
    public int RecordId  { get; set; }
    
    public decimal ServicePrice { get; set; }
}