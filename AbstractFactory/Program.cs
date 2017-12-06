//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbstractFactory
{
    interface IPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }

    interface IDumb
    {
        string Name();
    }
    interface ISmart
    {
        string Name();
    }

    class Asha : IDumb
    {
        public string Name()
        {
            return "Asha";
        }
    }

    class Primo : IDumb
    {
        public string Name()
        {
            return "Guru";
        }
    }

    class Genie : IDumb
    {
        public string Name()
        {
            return "Genie";
        }
    }

    class Lumia : ISmart
    {
        public string Name()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        public string Name()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        public string Name()
        {
            return "Titan";
        }
    }

    class SamsungFactory : IPhoneFactory
    {
        public ISmart GetSmart()
        {
            return new GalaxyS2();
        }

        public IDumb GetDumb()
        {
            return new Primo();
        }
    }

    class HTCFactory : IPhoneFactory
    {
        public ISmart GetSmart()
        {
            return new Titan();
        }

        public IDumb GetDumb()
        {
            return new Genie();
        }
    }

    class NokiaFactory : IPhoneFactory
    {
        public ISmart GetSmart()
        {
            return new Lumia();
        }

        public IDumb GetDumb()
        {
            return new Asha();
        }
    }

    enum MANUFACTURERS
    {
        SAMSUNG,
        NOKIA,
        HTC
    }
    class PhoneTypeChecker
    {
        IPhoneFactory factory;
        MANUFACTURERS manu;

        public PhoneTypeChecker(MANUFACTURERS m)
        {
            manu = m;
        }

        public void CheckProducts()
        {
            switch (manu)
            {
                case MANUFACTURERS.SAMSUNG:
                    factory = new SamsungFactory();
                    break;
                case MANUFACTURERS.HTC:
                    factory = new HTCFactory();
                    break;
                case MANUFACTURERS.NOKIA:
                    factory = new NokiaFactory();
                    break;
            }

            Console.WriteLine(manu.ToString() + ":\nSmart Phone: " +
            factory.GetSmart().Name() + "\nDumb Phone: " + factory.GetDumb().Name());
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PhoneTypeChecker checker = new PhoneTypeChecker(MANUFACTURERS.SAMSUNG);

            checker.CheckProducts();

            Console.ReadLine();

            checker = new PhoneTypeChecker(MANUFACTURERS.HTC);

            checker.CheckProducts();
            Console.ReadLine();

            checker = new PhoneTypeChecker(MANUFACTURERS.NOKIA);

            checker.CheckProducts();
            Console.Read();
        }
    }
}