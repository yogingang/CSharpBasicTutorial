using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class AbstractFactory
{
    public class Sample
    {
        public void CreateUnit()
        {
            List<IUnitFactory> list = new List<IUnitFactory>();

            list.Add(new WarriorFactory());
            list.Add(new RogueFactory());
            list.Add(new AssassinFactory());

            list.ForEach(u =>
            {
                u.CreateWeapon();
                u.CreateArmor();
            });

        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            sample.CreateUnit();
        }
    }

    public interface IWeapon
    {
        void GetDescription();
    }
    public class BigSword : IWeapon
    {
        public void GetDescription() => Console.WriteLine("BigSword");
    }
    public class PoisonDagger : IWeapon
    {
        public void GetDescription() => Console.WriteLine("Dagger");
    }
    public class DoubleDagger : IWeapon
    {
        public void GetDescription() => Console.WriteLine("DoubleDagger");
    }

    public interface IArmor
    {
        void GetDescription();
    }
    public class PlateArmor : IArmor
    {
        public void GetDescription() => Console.WriteLine("PlateArmor");
    }
    public class LeatherArmor : IArmor
    {
        public void GetDescription() => Console.WriteLine("LeatherArmor");
    }

    public class ClothArmor : IArmor
    {
        public void GetDescription() => Console.WriteLine("ClothArmor");
    }

    public interface IUnitFactory
    {
        void CreateWeapon();
        void CreateArmor();
    }

    public class WarriorFactory : IUnitFactory
    {
        public  void CreateArmor()=> new PlateArmor().GetDescription();
        public  void CreateWeapon() => new BigSword().GetDescription();
    }

    public class RogueFactory : IUnitFactory
    {
        public void CreateArmor() => new LeatherArmor().GetDescription();
        public void CreateWeapon() => new PoisonDagger().GetDescription();
    }

    public class AssassinFactory : IUnitFactory
    {
        public void CreateArmor() => new ClothArmor().GetDescription();
        public void CreateWeapon() => new DoubleDagger().GetDescription();
    }


}


