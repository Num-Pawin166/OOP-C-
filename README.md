**property** _มันคือสิ่งที่ใช้จัดการกับข้อมูลภายในคลาส (**class**) แต่ต่างจากฟิลด์ (**field**) หรือแอตทริบิวต์ตรงที่ **property** ทำหน้าที่เหมือนเป็นตัวกลางให้เราเข้าถึงข้อมูล (**get**) หรือกำหนดค่า (**set**) โดยที่เราสามารถควบคุมพฤติกรรมเวลาที่เข้าถึงหรือเปลี่ยนแปลงค่าได้_

สรุปง่าย ๆ คือ

class/object คือ โครงสร้างหรือแม่แบบสำหรับสร้างวัตถุที่มีข้อมูลและพฤติกรรม

property คือ ส่วนประกอบหนึ่งในคลาส ที่ใช้สำหรับเก็บหรือเข้าถึงข้อมูลภายในวัตถุโดยผ่านเมธอดพิเศษ (getter/setter)



# Encapsulation (ห่อหุ้มข้อมูล)
_คือการเก็บข้อมูลและฟังก์ชันที่เกี่ยวข้องไว้ด้วยกันในกล่องเดียว (เรียกว่า **Class**)_
**public string Brand { get; set; }** _เป็นการประกาศตัวแปรในคลาส อ่าน (**get**) และเขียน (**set**) ค่าให้ (**property**) 
**code C# หรือจะไปดูที่ Encapsulation.cs**

```cs
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
```

# Inheritance (สืบทอด)
 _คือการสร้าง **Class** ใหม่ที่เอาคุณสมบัติของ **Class** เดิมมาใช้แล้วเพิ่มของตัวเองได้_
_เหมือนลูกได้คุณสมบัติจากพ่อแม่ แต่เพิ่มความสามารถของตัวเอง_
**code C# หรือจะไปดูที่ Inheritance.cs**

```cs
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
```

# Polymorphism (หลายรูปแบบ)
_ความสามารถของอ็อบเจ็กต์ชนิดเดียวกันที่แสดงพฤติกรรมต่างกัน โดยใช้_

* virtual 

* override 

_ระหว่างคลาสแม่และลูก_
**code C# หรือจะไปดูที่ Polymorphism.cs**

```cs
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
```

# Abstraction (การซ่อนรายละเอียด)
Abstraction คือ “การซ่อนรายละเอียดที่ไม่จำเป็น” แล้วแสดงเฉพาะสิ่งที่จำเป็นต่อการใช้งาน เช่น เวลาเราขับรถ เราแค่หมุนพวงมาลัย เหยียบเบรก โดยไม่ต้องรู้ว่าภายในรถทำงานอย่างไร

จุดต่าง | ตัวอย่าง 1 (Car) | ตัวอย่าง 2 (Animal)
----- | ----- | ----- |
ฟิลด์/พร็อพเพอร์ตี้	 | มีฟิลด์ Brand และ Color | ไม่มี field หรือ property |
จำนวนคลาสลูก	 | มีคลาสลูกแค่ 1 (ElectricCar) | มี 2 คลาสลูก (Dog, Cat) |
Output | ใช้ข้อความประกอบข้อมูล (Color, Brand) | เป็นเสียงของสัตว์ (Meow, Bark) |
เนื้อหาในการแสดงผล	 | มีการรวม string กับข้อมูล | ไม่มีข้อมูลเสริมจาก field/properties |


**code C# หรือจะไปดูที่ Abstraction.cs**

**ตัวอย่าง1**
```cs

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
```

**ตัวอย่าง2**

```cs

public abstract class Animal
{
    public abstract void MakeSound(); // เมธอดแบบ abstract ไม่มีการ implement
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark!");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

class Program
{
    static void Main()
    {
        Animal myDog = new Dog();
        Animal myCat = new Cat();

        myDog.MakeSound();  // แสดงผล: Bark!
        myCat.MakeSound();  // แสดงผล: Meow!
    }
}
```
