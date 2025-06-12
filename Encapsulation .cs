class Car 
{
    public string Brand; // ไม่อนุญาตให้เก็บค่า null
    public string Color;
    public void Drive()
    {
        Console.WriteLine($"The {Color} {Brand} is driving.");
    }


    static void Main() // (entry point)
    {
        Car myCar = new Car();

        myCar.Brand = "Toyota";
        myCar.Color = "Red";
        myCar.Drive();

    }
}