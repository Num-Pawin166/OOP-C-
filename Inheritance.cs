class Car
{
    public string Brand;
    public string Color;

    public void Drive()
    {
        Console.WriteLine($"The {Color} {Brand} is driving.");
    }
}

// คลาสลูก
class ElectricCar : Car
{
    public int BatteryLevel;

    public void Charge()
    {
        Console.WriteLine($"Charging {Brand}... Battery at {BatteryLevel}%");
    }
}

class Program
{
    static void Main()
    {
        ElectricCar myCar = new ElectricCar();
        myCar.Brand = "Tesla";
        myCar.Color = "White";
        myCar.BatteryLevel = 80;

        myCar.Drive();   // เมธอดจากคลาสแม่
        myCar.Charge();  // เมธอดของคลาสลูก
    }
}