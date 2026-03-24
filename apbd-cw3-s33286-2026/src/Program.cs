using apbd_cw3_s33286_2026.Model;
using apbd_cw3_s33286_2026.Service;

namespace apbd_cw3_s33286_2026;

class Program
{
    static void Main(string[] args)
    {
        var database = new Data();
        var userService = new UserService(database);
        var equipmentService = new EquipmentService(database);
        var rentalService = new RentalService(database);

        Console.WriteLine("=== SCENARIUSZ DEMONSTRACYJNY SYSTEMU WYPOŻYCZALNI ===\n");

        var student = new Student("Jan", "Kowalski", "s33286");
        var employee = new Employee("Adam", "Nowak", "Dział IT");
        userService.RegisterUser(student);
        userService.RegisterUser(employee);

        var laptop = new Laptop("Dell XPS 15", "i7", "RTX 4050", "32GB");
        var camera = new Camera("Sony A7 III", 1.5, 24);
        var projector = new Projector("Epson EB-L", 3000, "120'", "FullHD");
        equipmentService.AddEquipment(laptop);
        equipmentService.AddEquipment(camera);
        equipmentService.AddEquipment(projector);

        Console.WriteLine($"Dodano: {student.FullName} oraz {employee.FullName}");
        Console.WriteLine($"Zarejestrowano: {laptop.Name}, {camera.Name}, {projector.Name}\n");

        Console.WriteLine("--- Test 1: Poprawne wypożyczenie ---");
        rentalService.RentEquipment(student.Id, laptop.Id, 7);
        Console.WriteLine($"Sukces: {student.FullName} wypożyczył {laptop.Name}.\n");

        Console.WriteLine("--- Test 2: Próba wypożyczenia zajętego sprzętu ---");
        try
        {
            rentalService.RentEquipment(employee.Id, laptop.Id, 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Zablokowano: {ex.Message}\n");
        }

        Console.WriteLine("--- Test 3: Próba przekroczenia limitu (Student) ---");
        try
        {
            rentalService.RentEquipment(student.Id, camera.Id, 5);
            Console.WriteLine("Drugie wypożyczenie: OK");
            rentalService.RentEquipment(student.Id, projector.Id, 2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Zablokowano: {ex.Message}\n");
        }

        Console.WriteLine("--- Test 4: Zwrot w terminie ---");
        var rental = database.Rentals.First(r => r.EquipmentId == camera.Id && r.IsActive);
        rentalService.ReturnEquipment(rental.Id);
        Console.WriteLine($"Zwrócono: {camera.Name}. Kara: {rental.Fine} zł\n");

        Console.WriteLine("--- Test 5: Zwrot z opóźnieniem ---");
        var rentalLaptop = database.Rentals.First(r => r.EquipmentId == laptop.Id && r.IsActive);
        rentalLaptop.SimulateOverdue(10);
        rentalService.ReturnEquipment(rentalLaptop.Id);
        Console.WriteLine($"Zwrócono: {laptop.Name} z opóźnieniem. Kara: {rentalLaptop.Fine} zł\n");

        Console.WriteLine("--- Test 6: Oznaczenie sprzętu jako niedostępny ---");
        equipmentService.SetUnavailable(projector.Id);
        Console.WriteLine($"{projector.Name} oznaczony jako niedostępny.\n");

        Console.WriteLine("--- Test 7: Aktywne wypożyczenia studenta ---");
        var active = database.Rentals.Where(r => r.UserId == student.Id && r.IsActive).ToList();
        Console.WriteLine($"Aktywne wypożyczenia {student.FullName}: {active.Count}\n");

        Console.WriteLine("--- Test 8: Przeterminowane ---");
        var overdue = database.Rentals.Where(r => r.IsOverdue).ToList();
        Console.WriteLine($"Przeterminowane: {overdue.Count}\n");

        Console.WriteLine("=== RAPORT KOŃCOWY ===");
        var allEquip = equipmentService.GetAllEquipment().ToList();
        var availableEquip = equipmentService.GetAvailableEquipment().ToList();
        var activeRentalsCount = database.Rentals.Count(r => r.ReturnedAt == null);
        Console.WriteLine($"Sprzęt ogólny: {allEquip.Count}");
        Console.WriteLine($"Dostępne: {availableEquip.Count}");
        Console.WriteLine($"Aktywne wypożyczenia: {activeRentalsCount}");
    }
}