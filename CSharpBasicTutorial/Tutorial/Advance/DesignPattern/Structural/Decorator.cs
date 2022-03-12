using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Decorator
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

   
    public class Test : ITest
    {
        public void Run()
        {
            IWeapon weapon = new Poison(new Spike(new Dagger()));
            weapon.Attack();

            weapon = new Spike(new BastardSword());
            weapon.Attack();
        }
    }

   

}


