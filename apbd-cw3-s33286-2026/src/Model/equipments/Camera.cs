namespace apbd_cw3_s33286_2026.Model;

public class Camera: Equipment
{
    public double OpticalZoom { get; set; }
    public int MegaPixel { get; set; }

    public Camera(string name, double opticalZoom, int megaPixel) : base(name)
    {
        OpticalZoom = opticalZoom;
        MegaPixel = megaPixel;
    }
}