using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class FactoryMethod
{
    public class Sample
    {
        private readonly ICreator _creator;
        public Sample(ICreator creator)=> _creator = creator;
        public void Attack()=> _creator.CreateUnit().Attack();
        public void Defence()=> _creator.CreateUnit().Defence();
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample(new WarriorCreator());
            sample.Attack();
            sample = new Sample(new RogueCreator());
            sample.Attack();
            sample = new Sample(new AssassinCreator());
            sample.Defence();
        }
    }
 
    public interface ICreator
    {
        public IUnitProduct CreateUnit();
    }

    public class WarriorCreator : ICreator
    {
        public IUnitProduct CreateUnit() => new Warrior();
    }

    public class RogueCreator : ICreator
    {
        public IUnitProduct CreateUnit() => new Rogue();
    }

    public class AssassinCreator : ICreator
    {
        public IUnitProduct CreateUnit() => new Assassin();
    }

    public interface IUnitProduct
    {
        void Attack();
        void Defence();
    }

    public class Warrior : IUnitProduct
    {
        public  void Attack() => Console.WriteLine("대검으로 공격");
        public  void Defence() => Console.WriteLine("방패로 방어");
    }

    public class Rogue : IUnitProduct
    {
        public void Attack() => Console.WriteLine("독묻은 단검으로 공격");
        public void Defence() => Console.WriteLine("상대의 공격을 회피하여 방어");
    }

    public class Assassin : IUnitProduct
    {
        public void Attack() => Console.WriteLine("쌍검으로 공격");
        public void Defence() => Console.WriteLine("쌍검을 교차하여 방어");
    }


}


