namespace apbd_cw3_s33286_2026.Model;

public abstract class Equipment
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;

    protected Equipment(string name)
    {
        this.Name = name;
    }
}