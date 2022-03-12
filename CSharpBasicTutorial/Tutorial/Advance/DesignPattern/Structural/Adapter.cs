using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Adapter
{

    public interface IMeleeAttack
    {
        void Attack(int damage);
    }

    public class Sword: IMeleeAttack
    {
        public void Attack(int damage) => Console.WriteLine($"검으로 {damage} damage 를 주었다.");
    }


    public class MeleeAttackAdapter : IMeleeAttack
    {

        private readonly Gun _adaptee;
        public MeleeAttackAdapter(Gun gun) => _adaptee = gun;       

        public void Attack(int damage) 
        {
            // gun 관련 기본 거리를 지정한다.
            _adaptee.Fire(5, damage);
        }
    }

    public interface IRangedAttack
    {
        void Fire(int distance, int damage);
    }

    public abstract class NormalRangedWeapon:IRangedAttack
    {
        public abstract void Fire(int distance, int damage);

        protected virtual double GetReduceDamage(int distance) => distance switch
        {
            > 10 => 0.1,
            >= 5 => 0.5,
            > 0 => 1,
            _ => 0
        };
    }

    public class Gun: NormalRangedWeapon
    {  
        public override void Fire(int distance, int damage)=>Console.WriteLine($"총으로 {damage * GetReduceDamage(distance)} damage 를 주었다.");
    }

    public class Sample
    {
        public void Run()
        {
            int attackDamage = 10;
            IMeleeAttack sword = new Sword();
            sword.Attack(attackDamage);

            IMeleeAttack adapter = new MeleeAttackAdapter(new Gun());
            adapter.Attack(attackDamage);

        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            sample.Run();
        }
    }

   

}


