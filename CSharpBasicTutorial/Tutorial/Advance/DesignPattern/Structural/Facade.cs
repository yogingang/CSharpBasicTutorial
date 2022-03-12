using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Facade
{
    public interface IWeapon
    {
        void Attack();
    }

    public class BastardSword : IWeapon
    {
        public void Attack() => Console.WriteLine("대검으로 공격");
    }
    public class Dagger : IWeapon
    {
        public void Attack() => Console.WriteLine("단검으로 공격");
    }


    public abstract class WeaponDecorator : IWeapon
    {
        public abstract void Attack();
    }

    public class Poison : WeaponDecorator
    {
        private readonly IWeapon _weapon;

        public Poison(IWeapon weapon)=> _weapon = weapon;
        
        public override void Attack()
        {
            Console.Write("독묻은 ");  
            _weapon.Attack() ;
        }
    }

    public class Spike : WeaponDecorator
    {
        private readonly IWeapon _weapon;

        public Spike(IWeapon weapon) => _weapon = weapon;

        public override void Attack()
        {
            Console.Write("대못박힌 ");
            _weapon.Attack();
        }
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

    public class WarriorPartyFacade
    {
        private List<Unit> _units = new List<Unit>();
        public WarriorPartyFacade()
        {
            IWeapon weapon = new Spike(new BastardSword());
            Unit warrior = new Warrior(weapon);

            IWeapon weapon2 = new Poison(new Spike(new Dagger()));
            Unit rogue = new Rogue(weapon2);

            IWeapon weapon3 = new Spike(new Dagger());
            Unit assassin = new Assassin(weapon3);

            _units.Add(warrior);
            _units.Add(rogue);
            _units.Add(assassin);
        }

        public void Attack()
        {
            foreach (var unit in _units)
                unit.Attack();
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            WarriorPartyFacade party = new WarriorPartyFacade();
            party.Attack();
        }
    }

   

}


