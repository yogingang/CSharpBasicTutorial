using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial
{
    public class StringsTest : ITest
    {
        public void Run()
        {

            string firstName = "david";
            string lastName = "anderson";

            // 문자열 연결, 길이 check
            string fullName = firstName + " " + lastName;
            Console.WriteLine($"fullName = {fullName}, " +
                                $"length = {fullName.Length}");

            // 소문자로 변경
            Console.WriteLine($"Lower fullName  = {fullName.ToLower()}, " +
                                $"length = {fullName.Length}");

            // 대문자로 변경
            Console.WriteLine($"Upper fullName  = {fullName.ToUpper()}, " +
                                $"length = {fullName.Length}");

            // 문자열 분리
            Console.WriteLine($"firstName = {fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]}, " +
                                $"lastName = {fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]}");


            // 문자열 탐색
            Console.WriteLine(fullName[0]); // d
            Console.WriteLine(fullName[1]); // a
            Console.WriteLine(fullName[2]); // v
            Console.WriteLine(fullName[3]); // i
            Console.WriteLine(fullName[4]); // d

            Console.WriteLine(fullName.IndexOf('i')); // 3  (i 의 첫번째 인덱스 위치)
            Console.WriteLine(fullName.IndexOfAny("zi".ToArray())); //3 (zi 중 발견된 char 의 첫번째 인덱스 위치)

            // 특수문자
            // 특수문자를 입력하기 위해서는 \ 를 특수문자 앞에 넣으면 된다.
            string specialFullname = fullName + " \"My friend\" ";
            Console.WriteLine(specialFullname); // david anderson "My friend"
            specialFullname = fullName + " \'My friend\' ";
            Console.WriteLine(specialFullname); // david anderson 'My friend'
            specialFullname = fullName + " \\My friend\\ ";
            Console.WriteLine(specialFullname); // david anderson \My friend\

            // string.format

            Console.WriteLine(string.Format("my first name is {0}, my last name is {1} ", firstName, lastName));
            Console.WriteLine($"my first name is {firstName}, my last name is {lastName} ");


            // 문자열로 변경
            int number = 10;
            bool result = false;
            DateTime dateTime = DateTime.Now;

            Console.WriteLine(number.ToString());
            Console.WriteLine(result.ToString());
            Console.WriteLine(dateTime.ToString());

        }
    }
}
