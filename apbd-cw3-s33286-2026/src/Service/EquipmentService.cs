namespace apbd_cw3_s33286_2026.Service;
using apbd_cw3_s33286_2026.Model;

public class EquipmentService
{
    private readonly Data _db;

    public EquipmentService(Data db)
    {
        _db = db;
    }

    public void AddEquipment(Equipment equipment)
    {
        _db.EquipmentList.Add(equipment);
    }

    public IEnumerable<Equipment> GetAllEquipment() => _db.EquipmentList;
    
    public IEnumerable<Equipment> GetAvailableEquipment() => 
        _db.EquipmentList.Where(e => e.IsAvailable);
    
    public void SetUnavailable(Guid id)
    {
        var eq = _db.EquipmentList.FirstOrDefault(e => e.Id == id);
        if (eq != null) eq.IsAvailable = false;
    }
}