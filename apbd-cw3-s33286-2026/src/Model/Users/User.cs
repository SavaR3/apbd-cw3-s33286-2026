namespace apbd_cw3_s33286_2026.Model;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxRentals { get; }
    public abstract string UserType { get; }

    protected User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{FirstName} {LastName}";
}