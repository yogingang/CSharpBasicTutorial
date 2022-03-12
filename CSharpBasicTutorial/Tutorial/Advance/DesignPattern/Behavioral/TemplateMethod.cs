using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class TemplateMethod
{
    public interface IUnit
    {
        void AutoHunt();
  
    }
    public abstract class AbstractUnit : IUnit
    {

        public void AutoHunt()
        {
            FindMob();
            MainAttack();
            MainDefence();
            SpecialAttack();
            SpecialDefence();
            FinalAttack();

        }
        public void FindMob()
        {
            Console.WriteLine($"{GetType().Name} (이)가 주변에서 적절한 Level 의 몹을 찾는다.");
        }
        protected abstract void MainAttack();
        protected abstract void SpecialAttack();
        protected abstract void MainDefence();
        protected abstract void SpecialDefence();
        protected abstract void FinalAttack();
    }

    public class Warrior : AbstractUnit
    {
        protected override void FinalAttack()
        {
            Console.WriteLine("목을 대검으로 베기");
        }

        protected override void MainAttack()
        {
            Console.WriteLine("대검 휘두르기");
        }

        protected override void MainDefence()
        {
            Console.WriteLine("방패로 막기");
        }

        protected override void SpecialAttack()
        {
            Console.WriteLine("점프하여 대검으로 찍기");
        }

        protected override void SpecialDefence()
        {
            Console.WriteLine("방패로 밀치기");
        }
    }

    public class Rogue : AbstractUnit
    {
        protected override void FinalAttack()
        {
            Console.WriteLine("심장에 단검 찌르기");
        }

        protected override void MainAttack()
        {
            Console.WriteLine("단검으로 찌르기");
        }

        protected override void MainDefence()
        {
            Console.WriteLine("회피");
        }

        protected override void SpecialAttack()
        {
            Console.WriteLine("독을 단검에 바르고 찌르기");
        }

        protected override void SpecialDefence()
        {
            Console.WriteLine("반격");
        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            AutoHunt(new Warrior());
            AutoHunt(new Rogue());
        }

        public void AutoHunt(IUnit unit)
        {
            unit.AutoHunt();
        }
    }
}


