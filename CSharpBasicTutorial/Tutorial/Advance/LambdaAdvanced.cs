using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Advance
{
    public class LambdaAdvanced
    {

        public class AAttribute :Attribute
        {
        }

        public class VariableCaptureGame
        {
            public Action<int> UpdateCapturedLocalVariable;
            public Func<int, bool> IsEqualToCapturedLocalVariable;

            public void Run(int input)
            {
                int j = 0;

                // 바깥쪽 j 를 update 함
                // j capture
                UpdateCapturedLocalVariable = x =>
                {
                    j = x;
                    bool result = j > input;
                    Console.WriteLine($"{j} is greater than {input}: {result}");
                };

                // j 사용 
                // j capture
                IsEqualToCapturedLocalVariable = x => x == j;


                // run 내부에서 lambda 문인  UpdateCapturedLocalVariable 를 호출하여
                // j 의 값을 10으로 설정함
                // Run 함수를 벗어나면 일반 적으로 int j 는 초기화 되므로
                // UpdateCapturedLocalVariable 람다 문의 캡쳐된 j 나
                // IsEqualToCapturedLocalVariable 의 캡쳐된 j 도
                // 초기화 될것이라 생각할수 있으나 초기화 되지 않고 캡쳐한 값을 유지한다.
                // 즉 가비지시 수집되지 않는다. 
                Console.WriteLine($"Local variable before lambda invocation: {j}");
                UpdateCapturedLocalVariable(10);
                Console.WriteLine($"Local variable after lambda invocation: {j}");
            }
        }

        public class Test : ITest
        {
            public void Run()
            {

                //속성을 람다식에 적용 가능하다.
   
                var f = [A] () => { };        // [A] lambda
                //var f = [return: A] x => x;    // syntax error at '=>'
                //var f = [return: A] (x) => x;  // [A] lambda
                //var f = [A] static x => x;    // syntax error at '=>'

                //var f = ([A] x) => x;         // [A] x
                //var f = ([A] ref int x) => x; // [A] x


                // 명시적으로 반환 유형을 지정할 수 있다.
                var parse = (string s)=>int.Parse(s);

                //object parse = (string s) => int.Parse(s);   // Func<string, int>
                //Delegate parse = (string s) => int.Parse(s); // Func<string, int>

                System.Linq.Expressions.LambdaExpression parseExpr = (string s) => int.Parse(s); // Expression<Func<string, int>>
                //System.Linq.Expressions.Expression parseExpr = (string s) => int.Parse(s);       // Expression<Func<string, int>>

                var game = new VariableCaptureGame();

                int gameInput = 5;
                game.Run(gameInput);

                int jTry = 10;
                bool result = game.IsEqualToCapturedLocalVariable(jTry);
                Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

                int anotherJ = 3;
                game.UpdateCapturedLocalVariable(anotherJ);

                bool equalToAnother = game.IsEqualToCapturedLocalVariable(anotherJ);
                Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
            }
        }

       
    }
}
