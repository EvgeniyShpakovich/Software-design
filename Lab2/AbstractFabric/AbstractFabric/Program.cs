interface ILaptop {
    public void ShowInfo();
}
interface ISmartphone
{
    public void ShowInfo();
}

class IProneLaptop : ILaptop
{
    public void ShowInfo() => Console.WriteLine("IProne Laptop Created");
}

class KiaomiLaptop : ILaptop
{
    public void ShowInfo() => Console.WriteLine("Kiaomi Laptop Created");
}

class BalaxyLaptop : ILaptop
{
    public void ShowInfo() => Console.WriteLine("Balaxy Laptop Created");
}

class IProneSmartphone : ISmartphone
{
    public  void ShowInfo() => Console.WriteLine("IProne Smartphone Created");
}

class KiaomiSmartphone : ISmartphone
{
    public void ShowInfo() => Console.WriteLine("Kiaomi Smartphone Created");
}

class BalaxySmartphone : ISmartphone
{
    public void ShowInfo() => Console.WriteLine("Balaxy Smartphone Created");
}

interface ITechFactory
{
    ILaptop CreateLaptop();
    ISmartphone CreateSmartphone();
}

class IProneFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new IProneLaptop();
    public ISmartphone CreateSmartphone() => new IProneSmartphone();
}

class KiaomiFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
}

class BalaxyFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}

class Program
{
    static void Main()
    {
        ITechFactory iproneFactory = new IProneFactory();
        ITechFactory kiaomiFactory = new KiaomiFactory();
        ITechFactory balaxyFactory = new BalaxyFactory();

        ILaptop iproneLaptop = iproneFactory.CreateLaptop();
        ISmartphone kiaomiSmartphone = kiaomiFactory.CreateSmartphone();
        ILaptop balaxyLaptop = balaxyFactory.CreateLaptop();

        iproneLaptop.ShowInfo();
        kiaomiSmartphone.ShowInfo();
        balaxyLaptop.ShowInfo();
    }
}
