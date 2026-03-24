namespace apbd_cw3_s33286_2026.Service;

using apbd_cw3_s33286_2026.Model;

public class RentalService
{
    private readonly Data _db;
    private const decimal DailyFineRate = 15.50m; // Легко змінити ставку штрафу

    public RentalService(Data db)
    {
        _db = db;
    }

    public void RentEquipment(Guid userId, Guid equipmentId, int rentalDays)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId) 
                   ?? throw new Exception("Użytkownik nie istnieje.");
        
        var equipment = _db.EquipmentList.FirstOrDefault(e => e.Id == equipmentId) 
                        ?? throw new Exception("Sprzęt nie istnieje.");
        
        if (!equipment.IsAvailable)
            throw new InvalidOperationException("Sprzęt jest obecnie niedostępny.");
        
        int activeCount = _db.Rentals.Count(r => r.UserId == userId && r.IsActive);
        if (activeCount >= user.MaxRentals)
            throw new InvalidOperationException($"Użytkownik przekroczył limit ({user.MaxRentals}).");
        
        var rental = new Rental(userId, equipmentId, rentalDays);
        _db.Rentals.Add(rental);
        equipment.IsAvailable = false;
    }

    public void ReturnEquipment(Guid rentalId)
    {
        var rental = _db.Rentals.FirstOrDefault(r => r.Id == rentalId && r.IsActive)
                     ?? throw new Exception("Nie znaleziono aktywnego wypożyczenia.");

        var equipment = _db.EquipmentList.First(e => e.Id == rental.EquipmentId);
        
        decimal fine = 0;
        if (DateTime.Now > rental.DueDate)
        {
            int delayDays = (DateTime.Now - rental.DueDate).Days;
            fine = delayDays * DailyFineRate;
        }

        rental.CompleteRental(fine);
        equipment.IsAvailable = true;
    }
}