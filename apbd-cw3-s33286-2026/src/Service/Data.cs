namespace apbd_cw3_s33286_2026.Service;
using apbd_cw3_s33286_2026.Model;

public class Data
{
    public List<User> Users { get; } = new();
    public List<Equipment> EquipmentList { get; } = new();
    public List<Rental> Rentals { get; } = new();
}