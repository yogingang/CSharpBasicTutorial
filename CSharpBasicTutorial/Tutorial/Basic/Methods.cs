using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial.Basic;
public class Methods : ITest
{
    public void Run()
    {
        /// <summary>
        /// "Hello World!" 를 return 하는 구문
        /// </summary>
        string HelloWorld()
        {
            return "Hello World!";
        }
        Console.WriteLine(HelloWorld()); // 호출 및 Console 에 Print

        /// <summary>
        /// parameter 인 message 에 "Hello World!" 를 전달
        /// </summary>
        string HelloWorldParameter(string message)
        {
            return $"{message}";
        }
        Console.WriteLine(HelloWorldParameter("Hello World!"));  // 호출 및 Console 에 Print

        /// <summary>
        /// parameter 인 message 에 참조(ref)를 통해"Hello World!" 를 전달
        /// </summary>
        string HelloWorldParameterByRef(ref string message)
        {
            message = message.ToUpper();
            return $"{message}";
        }

        var helloWorld = "Hello World!";
        Console.WriteLine(HelloWorldParameterByRef(ref helloWorld));  // helloWorld 변수의 참조를 전달
        Console.WriteLine(helloWorld); // helloWorld 변수의 변화를 확인
        // HelloWorldParameterByRef method 에서
        // 참조로 전달한 helloWorld 변수를 수정하여
        // helloWorld 원본도 변경되었다.

        int[] ints =  {9,6,8,1,0,3,5,2,7 };
        var orderByInts = ints.OrderBy(x => x);
        foreach(var i in orderByInts)
        {
            Console.WriteLine(i);
        }

        // string 에 대한 확장메서드 WriteLine 을 통해
        // helloWorld 를 console 에 찍어보자
        helloWorld.WriteLine();

        // optional parameter message 는 parameter 를 전달하지 않으면 Hello World! 를 기본값으로 가지고 있다.
        void HelloWorldNamedAndOptionalParameter(string name, int age, string message="Hello World!")
        {
            $"Your name is {name}! ur age is {age} and {message} ".WriteLine(); // string interpolation 과 extension method 를 활용하자 
        }

        // 선택적 인수를 생략해서 호출 (message 생략 기본값 호출)
        HelloWorldNamedAndOptionalParameter("yogingang", 1);

        // 선택적 인수를 변경해서 호출
        HelloWorldNamedAndOptionalParameter("yogingang", 1, "안녕하세요");

        // 인수를 명명하여 호출 (순서대로 하지 않아도 됨)
        HelloWorldNamedAndOptionalParameter(message : "오호 이런 방법이", name:"내이름은 뭐징!", age: 10);

        /* 출력
         * Your name is yogingang! ur age is 1 and Hello World!
         * Your name is yogingang! ur age is 1 and 안녕하세요
         * Your name is 내이름은 뭐징!! ur age is 10 and 오호 이런 방법이
         */
    }
}

/// <summary>
/// string 형태에 WriteLine 이라는 확장 method 를 추가한다. 
/// WriteLine 은 return 이 없는 Console.WriteLine 을 활용한 확장 메소드이다.
/// </summary>
public static class StringExtensions
{
    public static void WriteLine(this string self)
    {
        Console.WriteLine(self);
    }
}

