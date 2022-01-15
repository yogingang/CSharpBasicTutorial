using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial
{
    public class VariableAndTypesTest:ITest
    {
        public void Run()
        {
            // See https://aka.ms/new-console-template for more information 
            // <--- slash 두개는 주석을 의미한다. 그 줄은 전부 주석 처리된다. 
            /* 여러줄을 하고 싶다면
             * 이와 같이 하자 
             * 아주 편하다.
             */

            int age = 10; // type = int ,  variableName = age , value = 10
            bool isJava = false; // type = bool ,  variableName = isJava , value = false
            string language = "C#"; // type = string ,  variableName = language , value = "C#"

            object obj = age; // type = object ,  variableName = obj , value = age
                              // 변수를 대입한다. (복사됨)
            Console.WriteLine($"obj = {obj}"); // obj = 10

            obj = 13; // obj 의 값을 13 으로 바꾼다. 
            Console.WriteLine($"obj = {obj}, age ={age}"); // obj = 13, age =10
                                                           // obj의 변화가 age 에 영향을 주지 않는다. 

            obj = isJava;
            Console.WriteLine($"obj = {obj}"); //obj = False

            obj = language;
            Console.WriteLine($"obj = {obj}"); //obj = C#

            ChangeTarget(ref age);

            void ChangeTarget(ref int src)
            {
                Console.WriteLine($"src={src}, age={age}");
                src = 15;
                Console.WriteLine($"src={src}, age={age}");
            }


        }
    }
}
