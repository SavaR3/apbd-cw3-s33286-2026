namespace apbd_cw3_s33286_2026.Model;

public class Projector: Equipment
{
    public int Lumens {get; set;}
    public string MaximumScreenSize {get; set;}
    public string PixelResolution { get; set; }
    public Projector(string name, int lumens, string maximumScreenSize, string pixelResolution) : base(name)
    {
        Lumens = lumens;
        MaximumScreenSize = maximumScreenSize;
        PixelResolution = pixelResolution;
    }
}