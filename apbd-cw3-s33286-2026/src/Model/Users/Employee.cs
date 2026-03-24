namespace apbd_cw3_s33286_2026.Model;

public class Employee: User
{
    public string Department { get; set; }
    public override int MaxRentals => 5;
    public override string UserType => "Employee";

    public Employee(string firstName, string lastName, string department)
        : base(firstName, lastName)
    {
        Department = department;
    }
}