// คลาส abstract (ไม่สามารถสร้างอ็อบเจกต์จากคลาสนี้ได้)
public abstract class Car
{
    public string Brand;
    public string Color;

    // เมธอด abstract (ไม่มีรายละเอียดในคลาสนี้)
    public abstract void Drive();
}

// คลาสลูกต้อง implement เมธอด Drive เอง
class ElectricCar : Car
{
    public override void Drive()
    {
        Console.WriteLine($"The electric {Color} {Brand} is driving silently.");
    }
}

class Program
{
    static void Main()
    {
        Car myCar = new ElectricCar();
        myCar.Brand = "Tesla";
        myCar.Color = "White";
        myCar.Drive();
    }
}