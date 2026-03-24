namespace apbd_cw3_s33286_2026.Model;

public class Rental
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId { get; }
    public Guid EquipmentId { get; }
    public DateTime RentedAt { get; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public decimal Fine { get; set; }

    public bool IsActive => ReturnedAt == null;
    public bool IsOverdue => IsActive && DateTime.Now > DueDate;

    public Rental(Guid userId, Guid equipmentId, int days)
    {
        UserId = userId;
        EquipmentId = equipmentId;
        RentedAt = DateTime.Now;
        DueDate = DateTime.Now.AddDays(days);
    }

    public void CompleteRental(decimal fine)
    {
        ReturnedAt = DateTime.Now;
        Fine = fine;
    }
    
    public void SimulateOverdue(int days)
    {
        DueDate = DateTime.Now.AddDays(-days);
    }
}