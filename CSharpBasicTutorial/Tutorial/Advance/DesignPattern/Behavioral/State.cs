using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance;

public class State
{
    public interface IUnitContext
    {
        void Attack();
        void Defence();
        void TransitionTo(IUnitState state);
    }
    public abstract class UnitContext: IUnitContext
    {
        protected IUnitState _state;
        public UnitContext(IUnitState state) => TransitionTo(state);

        public abstract void Attack();
        public abstract void Defence();
        public void TransitionTo(IUnitState state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }
    }

    public class Warrior : UnitContext
    {
        public Warrior(IUnitState state) : base(state)
        {
        }

        public override void Attack()
        {
            _state.Attack();
        }

        public override void Defence()
        {
            _state.Defence();
        }
    }

    public interface IUnitState
    {
        void SetContext(IUnitContext context);
        void Attack();
        void Defence();
    }

    public abstract class UnitState : IUnitState
    {
        protected IUnitContext _context;
        public abstract void Attack();
        public abstract void Defence();
        public void SetContext(IUnitContext context) => _context = context;
    }

    public class NormalState : UnitState
    {
        public override void Attack()
        {
            Console.WriteLine("공격 : 무기를 휘두름");
            _context.TransitionTo(new FuryState());
        }

        public override void Defence()
        {
            Console.WriteLine("방어 : 방패를 들어올림");
        }
    }

    public class FuryState : UnitState
    {
        public override void Attack()
        {
            Console.WriteLine("공격 : 무기를 두번 휘두름");
            _context.TransitionTo(new TiredState());
        }

        public override void Defence()
        {
            Console.WriteLine("방어 : 방패를 휘두름");
            _context.TransitionTo(new TiredState());
        }
    }

    public class TiredState : UnitState
    {
        public override void Attack()
        {
            Console.WriteLine("공격: 밀쳐내기");
        }

        public override void Defence()
        {
            Console.WriteLine("방어: 휴식");
            _context.TransitionTo(new NormalState());
        }
    }


    public class Test : ITest
    {
        public void Run()
        {
            var context = new Warrior(new NormalState());
            context.Attack();
            context.Attack();
            context.Attack();
            context.Defence();
            context.Defence();
        }
    }
}


