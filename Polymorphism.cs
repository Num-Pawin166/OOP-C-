class Car
{
    public string Brand;
    public string Color;

    // เมธอด virtual เพื่อให้ลูก override ได้
    public virtual void Drive()
    {
        Console.WriteLine($"The {Color} {Brand} is driving.");
    }
}

class ElectricCar : Car
{
    public int BatteryLevel;

    // override เมธอด Drive
    public override void Drive()
    {
        Console.WriteLine($"The electric {Color} {Brand} is driving silently. Battery: {BatteryLevel}%");
    }
}

class Program
{
    static void Main()
    {
        Car myCar = new Car();
        myCar.Brand = "Toyota";
        myCar.Color = "Red";

        Car myElectricCar = new ElectricCar();
        myElectricCar.Brand = "Tesla";
        myElectricCar.Color = "White";
        ((ElectricCar)myElectricCar).BatteryLevel = 90;

        myCar.Drive();           // เรียกเมธอดของ Car
        myElectricCar.Drive();   // เรียกเมธอดของ ElectricCar (Polymorphism)
    }
}