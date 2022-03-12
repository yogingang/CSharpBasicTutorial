using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class Prototype
{
    public class Sample
    {
        public void Clone()
        {
            var warriorA = new Warrior(1,2,3);
            var warriorB = warriorA.Clone(4,5);

            var warriorC = warriorA;

            warriorA.ToString().Print();

            warriorB.ToString().Print();
            warriorC.ToString().Print();

        }

        public void MemberClone()
        {
            var warriorA = new Warrior(1, 2, 3);
            var warriorB = warriorA.MemberClone();

            var warriorC = warriorA;
            
            warriorA.ToString().Print();

            warriorB.ToString().Print();
            warriorC.ToString().Print();

            

        }
    }

    public class Test : ITest
    {
        public void Run()
        {
            var sample = new Sample();
            sample.Clone();
            sample.MemberClone();
        }
    }
 
   
    public interface IUnit
    {
        IUnit Clone();
        IUnit MemberClone();
    }
    public abstract class BaseUnit:IUnit
    {
        protected int _rank { get;init;}
        public int HP { get; init; }
        public int Power { get; init; }

        public abstract IUnit Clone();
        public BaseUnit(int hp, int power, int rank)
        {
            HP = hp;
            Power = power;
            _rank = rank;
        }

        public override string ToString()
        {
           return $"HP = {HP}, Power = {Power}, Rank = {_rank}";
        }

        public abstract IUnit MemberClone();
    }

    public class Warrior : BaseUnit
    {
        public Warrior(int hp, int power, int rank) : base(hp, power, rank)
        {
        }

        public  void Attack() => Console.WriteLine("대검으로 공격");

        public override IUnit Clone()=> Clone();
        public  IUnit Clone(int hp=-1, int power=-1, int rank =-1)
        {
            return new Warrior(hp != -1 ? hp : HP
                , power != -1 ? power : Power
                , rank != -1 ? rank : _rank);
        }

        public  void Defence() => Console.WriteLine("방패로 방어");

        public override IUnit MemberClone()
        {
            return (IUnit)this.MemberwiseClone();
        }
    }


    //public class Rogue : BaseUnit
    //{
    //    public void Attack() => Console.WriteLine("독묻은 단검으로 공격");

    //    public override object Clone()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Defence() => Console.WriteLine("상대의 공격을 회피하여 방어");
    //}

    //public class Assassin : BaseUnit
    //{
    //    public void Attack() => Console.WriteLine("쌍검으로 공격");

    //    public override object Clone()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Defence() => Console.WriteLine("쌍검을 교차하여 방어");
    //}


}


