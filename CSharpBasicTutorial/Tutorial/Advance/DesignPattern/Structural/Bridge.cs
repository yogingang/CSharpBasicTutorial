using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Bridge
{

    public interface IWeapon
    {
        void Attack();
    }

    public class BastardSword : IWeapon
    {
        public void Attack() => Console.WriteLine("대검으로 베기!!");
    }

    public class Dagger : IWeapon
    {
        public void Attack()=> Console.WriteLine("단검으로 찌르기!!");
    }

    public class DoubleSword : IWeapon
    {
        public void Attack() => Console.WriteLine("쌍검으로 연속베기!!");
    }

    public abstract class Unit
    {
        protected IWeapon _weapon;
        public Unit(IWeapon weapon) => _weapon = weapon;
        public abstract void Attack();
    }

    public class Warrior : Unit
    {
        public Warrior(IWeapon weapon) : base(weapon) { }
        public override void Attack()
        {
            Console.Write("전사가 ");
            _weapon.Attack();
        }
    }

    public class Rogue : Unit
    {
        public Rogue(IWeapon weapon) : base(weapon) { }
        public override void Attack()
        {
            Console.Write("도적이 ");
            _weapon.Attack();
        }
    }

    public class Assassin : Unit
    {
        public Assassin(IWeapon weapon) : base(weapon) { }
        public override void Attack()
        {
            Console.Write("암살자가 ");
            _weapon.Attack();
        }
    }


    public class Test : ITest
    {
        public void Run()
        {
            Unit unit = new Warrior(new BastardSword());
            unit.Attack();
            
            unit = new Rogue(new Dagger());
            unit.Attack();

            unit = new Assassin(new DoubleSword());
            unit.Attack();
        }
    }

   

}


