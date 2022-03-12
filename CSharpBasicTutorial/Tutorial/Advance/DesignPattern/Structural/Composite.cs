using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Composite
{
    public interface IWeapon
    {
        int AttackPower();
    }

    public class BastardSword : IWeapon
    {
        public int AttackPower() => 7;
    }

    public class Dagger : IWeapon
    {
        public int AttackPower() => 5;
    }

    public class DoubleSword : IWeapon
    {
        public int AttackPower() => 20;
    }

    public interface ICompositeWeapon:IWeapon
    {
        void Add(IWeapon weapon);
        void Remove(IWeapon weapon);
    }
    public class CompositeWeapon: ICompositeWeapon
    {
        private List<IWeapon> _weapons = new List<IWeapon>();

        public void Add(IWeapon weapon) => _weapons.Add(weapon);
        public void Remove(IWeapon weapon) => _weapons.Remove(weapon);
        public int AttackPower() => _weapons.Sum(weapon => weapon.AttackPower());
       
    }

    public abstract class Unit
    {
        protected ICompositeWeapon _weapon;
        public Unit(ICompositeWeapon weapon) => _weapon = weapon;
        public abstract void Attack();
    }

    public class Warrior : Unit
    {
        public Warrior(ICompositeWeapon weapon) : base(weapon) { }
        public override void Attack() => Console.WriteLine($"전사가 공격하여 {_weapon.AttackPower()} 데미지를 입혔습니다.");
    }

    public class Rogue : Unit
    {
        public Rogue(ICompositeWeapon weapon) : base(weapon) { }
        public override void Attack() => Console.WriteLine($"도적이 공격하여 {_weapon.AttackPower()} 데미지를 입혔습니다.");
    }

    public class Assassin : Unit
    {
        public Assassin(ICompositeWeapon weapon) : base(weapon) { }
        public override void Attack() => Console.WriteLine($"암살자가 공격하여 {_weapon.AttackPower()} 데미지를 입혔습니다.");
    }


    public class Test : ITest
    {
        public void Run()
        {
            ICompositeWeapon weapon = new CompositeWeapon();
            weapon.Add(new BastardSword());
            
            Unit unit = new Warrior(weapon);
            unit.Attack();

            weapon = new CompositeWeapon();
            weapon.Add(new Dagger());
            weapon.Add(new DoubleSword());
            unit = new Rogue(weapon);
            unit.Attack();

            unit = new Assassin(weapon);
            weapon.Add(new Dagger());
            weapon.Add(new Dagger());
            weapon.Add(new DoubleSword());
            unit.Attack();
        }
    }

   

}


