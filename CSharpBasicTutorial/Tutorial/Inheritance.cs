using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicTutorial.Tutorial;

public class Inheritance
{
    public class BaseClass
    {
        private int _id; // BaseClass 내부 에서만 접근, 상속 클래스 에서 접근 안됨
        protected int _age; // BaseClass 내부 에서 접근, 상속 클래스 에서 접근
        protected string MyName { get; set; } // BaseClass 내부 에서 접근, 상속 클래스 에서 접근
        internal string Description { get; set; }// 같은 assembly 내에서 접근가능. BaseClass 내부, 외부, 상속 클래스 에서 접근
        public string Title { get; set; }// 모든 assembly 에서 접근 가능. BaseClass 내부, 외부, 상속 클래스 에서 접근


        /// <summary>
        /// virtual keyword 를 통해 상속한 child class 에서 
        /// Exectue() 를 재정의 (overriding) 할 수 있도록 한다. 
        /// </summary>
        /// <returns></returns>
        public virtual void Execute()
        {
            Console.WriteLine($"{nameof(BaseClass)} Execute");
        }
    }

    public class ChildClass : BaseClass
    {
        /// <summary>
        /// override keyword 를 통해 BaseClass 로 부터
        /// Execute 클래스를 재정의 합니다. 
        /// </summary>
        public override void Execute()
        {
            Console.WriteLine($"{nameof(ChildClass)} Execute");
        }
    }
}



