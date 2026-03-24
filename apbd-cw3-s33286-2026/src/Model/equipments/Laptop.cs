namespace apbd_cw3_s33286_2026.Model;

public class Laptop: Equipment
{
    public string Procesor { get; set; }
    public string Gpu { get; set; }
    public string Ram { get; set; }
    
    public Laptop(string name, string procesor, string gpu, string ram ) : base(name)
    {
        Procesor = procesor;
        Gpu = gpu;
        Ram = ram;
    }
}