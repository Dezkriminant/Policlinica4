using System;

namespace Policlinica.DB;

public class Records
{
    public int Id { get; set; }
    
    public string ClientName { get; set; }
    
    public string ClientSurname { get; set; }
    
    public int DoctorId { get; set; }
    
    public int UserId { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public DateTime RecordDate { get; set; }
}