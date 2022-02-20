using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Builder
{
    public class Sample
    {
        public void CreateUnit()
        {           
            Director director = new Director(new WarriorBuilder());
            director.BuildFullFeature();
            director.Builder.GetUnitProduct().Show();

            director = new Director(new RogueUnitBuilder());
            director.BuildFullFeature();
            director.Builder.GetUnitProduct().Show();

            director = new Director(new  AssassinBuilder());
            director.BuildFullFeature();
            director.Builder.GetUnitProduct().Show();
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

    public class Director
    {
        public IUnitBuilder Builder { get;init;}    
        public Director(IUnitBuilder builder) => Builder = builder;
        public void BuildWeaponOnly() => Builder.BuildWeapon();
        public void BuildArmorOnly() => Builder.BuildArmor();
        public void BuildFullFeature()
        {
            Builder.BuildWeapon();
            Builder.BuildArmor();
        }
    }

    public interface IUnitBuilder
    {
        public  void BuildWeapon();
        public  void BuildArmor();
        public  UnitProduct GetUnitProduct();
    }

    public class UnitProduct
    {
        private List<IPart> _parts = new List<IPart>();
        public void Add(IPart part) =>_parts.Add(part);
        public void Show()
        {
            Console.WriteLine("\nUnit Equipments ---------");
            foreach (var part in _parts)
                part.GetDescription();
        }
        
    }
    public interface IPart { void GetDescription(); }
    public interface IWeapon : IPart { }
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

    public interface IArmor : IPart { }
   
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



    public abstract class AbstractUnitBuilder : IUnitBuilder
    {
        protected UnitProduct _product { get; set; } = new UnitProduct();
        public abstract void BuildArmor();

        public abstract void BuildWeapon();

        public virtual UnitProduct GetUnitProduct() => _product;
        
    }

    public class WarriorBuilder : AbstractUnitBuilder
    {
        public override void BuildArmor() => _product.Add(new PlateArmor());
        public override void BuildWeapon() => _product.Add(new BigSword());   
    }

    public class RogueUnitBuilder : AbstractUnitBuilder
    {
        public override void BuildArmor() => _product.Add(new LeatherArmor());
        public override void BuildWeapon() => _product.Add(new PoisonDagger());
     
    }

    public class AssassinBuilder : AbstractUnitBuilder
    {
        public override void BuildArmor() => _product.Add(new ClothArmor());
        public override void BuildWeapon() => _product.Add(new DoubleDagger());
    }


}


