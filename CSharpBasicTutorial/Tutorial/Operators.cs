using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicTutorial.Tutorial
{
    public class OperatorsTest: ITest
    {
        public void Run()
        {
            // Arithmetic Operators (산술 연산자)
            int sum = 100 + 50; // add
            Console.WriteLine($"sum ={sum}"); //sum =150
            sum = sum - 50; // substract
            Console.WriteLine($"sum ={sum}"); //sum =100
            sum = sum * 2; // multiply
            Console.WriteLine($"sum ={sum}"); //sum =200
            sum = sum / 2; // divide
            Console.WriteLine($"sum ={sum}"); //sum =100
            sum = ++sum; // increment (sum = sum + 1)
            Console.WriteLine($"sum ={sum}"); //sum =101
            sum = --sum; // decrement (sum = sum - 1)
            Console.WriteLine($"sum ={sum}"); //sum =100


            // Assignment Operators (대입 연산자)
            int sum2 = sum;
            sum2 += 50;
            Console.WriteLine($"sum2 ={sum2}"); //sum2 =150
            sum2 -= 50;
            Console.WriteLine($"sum2 ={sum2}"); //sum2 =100
            sum2 *= 2;
            Console.WriteLine($"sum2 ={sum2}"); //sum2 =200
            sum2 /= 2;
            Console.WriteLine($"sum2 ={sum2}"); //sum2 =100

            // Comparison Operators (비교 연산자)
            Console.WriteLine($"(sum == sum2) is {sum == sum2}"); // equal
            Console.WriteLine($"(sum != sum2) is {sum != sum2}"); // not equal
            Console.WriteLine($"(sum > sum2) is {sum > sum2}");   // greater 
            Console.WriteLine($"(sum >= sum2) is {sum >= sum2}"); // greater or equal
            Console.WriteLine($"(sum < sum2) is {sum < sum2}");   // less 
            Console.WriteLine($"(sum <= sum2) is {sum <= sum2}"); // less or equal

            // Logical Operators (논리 연산자)

            Console.WriteLine($"(sum  > 50 && sum2 < 100) is {sum > 50 && sum2 < 100}"); //  && ==> 두 조건이 다 true라면 true 이다.
            Console.WriteLine($"(sum  > 50 || sum2 < 100) is {sum != sum2}"); // || ==> 두 조건중 하나라도 true 라면 true 이다. 
            Console.WriteLine($"!(sum  > 50 && sum2 < 100) is {sum > sum2}"); // ! ==> 두조건에 대한 연산값이 true 라면 false , false 라면 true 즉 not 의 의미이다.

            // 비트 연산자 (각 비트를 반대로 하여 해당 피연산자의 비트 보수를 생성)
            uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
            uint b = ~a;
            Console.WriteLine(Convert.ToString(b, toBase: 2));
            // Output:
            // 11110000111100001111000011110011
            // 기타 비트 연산은 아래 참조
            // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators

            // 기타 연산자

            string? name = null; // 이것은 null 대입이 가능한 string 문자열이다. string 뒤에 ? 를 써서 표현한다. 

            name = name == null ? string.Empty : name;  // null 이면 string.empty 실행  아니라면 name 값을 사용
                                                        // ? <true 라면 이곳 실행> : <아니라면 이곳 실행> 

            name = name ?? string.Empty; // 위와 동일 ?? 은 null 이라면 string.empty 실행 아니라면 자신의 값을 사용

            name ??= string.Empty; // 위와 동일 ??=  은 null 이라면 string.empty 실행 아니라면 자신의 값을 사용

            

        }
    }
}
