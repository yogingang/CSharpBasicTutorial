using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.Tutorial
{
    public class CondintionsTest : ITest
    {
        public void Run()
        {

            int i = 15;
            if (i > 15)
            {
                Console.WriteLine("i > 15");
            }

            if (i > 15)
            {
                Console.WriteLine("i > 15");
            }
            else
            {
                Console.WriteLine("i <= 15"); //<-- 조건문상 아래가 실행됨
            }

            if (i > 15)
            {
                Console.WriteLine("i > 15");
            }
            else if (i < 15)
            {
                Console.WriteLine("i < 15");
            }
            else
            {
                Console.WriteLine("i <= 15"); //<-- 조건문상 아래가 실행됨
            }


            bool result = i < 15 ? false : true;
            Console.WriteLine(result);

            switch (i)
            {
                case > 15:
                    Console.WriteLine("i > 15");
                    break;
                case < 15:
                    Console.WriteLine("i < 15");
                    break;
                default:
                    Console.WriteLine("i <= 15"); //<-- 조건문상 아래가 실행됨
                    break;

            }

            object variantData = 10;
            //variantData = "10";
            //variantData = 10.1;
            //variantData = DateTime.Now;
            //variantData = false;

            switch (variantData)
            {
                case 10:
                    Console.WriteLine($"int {variantData}");
                    break;
                case "10":
                    Console.WriteLine($"string {variantData}");
                    break;
                case 10.1:
                    Console.WriteLine($"float or double {variantData}");
                    break;
                case DateTime: // type check
                    Console.WriteLine($"Datetime {variantData}");
                    break;
                default:
                    Console.WriteLine($"No Match {variantData.GetType().FullName} = {variantData}");
                    break;

            }

            // 이와 같이 변경해도 같은 동작
            switch (variantData)
            {
                case int:
                    Console.WriteLine($"int {variantData}");
                    break;
                case string:
                    Console.WriteLine($"string {variantData}");
                    break;
                case float or double:
                    Console.WriteLine($"float or double {variantData}");
                    break;
                case DateTime: // type check
                    Console.WriteLine($"Datetime {variantData}");
                    break;
                default:
                    Console.WriteLine($"No Match {variantData.GetType().FullName} = {variantData}");
                    break;

            }

            // 변수를 사용하여 condition 을 추가하거나 동작을 재 정의 할 수도 있음
            switch (variantData)
            {
                case int num when num > 5:
                    Console.WriteLine($"int {variantData} > 5");
                    break;
                case int num when num <= 5:
                    Console.WriteLine($"int {variantData} <= 5");
                    break;
                case string s:
                    Console.WriteLine($"string {variantData}");
                    break;
                case float or double:
                    Console.WriteLine($"float or double {variantData}");
                    break;
                case DateTime dt: // type check
                    Console.WriteLine($"Datetime {variantData}");
                    break;
                default:
                    Console.WriteLine($"No Match {variantData.GetType().FullName} = {variantData}");
                    break;

            }

            // 변수 생략도 가능함
            switch (variantData)
            {
                case var _ when (int)variantData > 5:
                    Console.WriteLine($"int {variantData} > 5");
                    break;
                case var _ when (int)variantData <= 5:
                    Console.WriteLine($"int {variantData} <= 5");
                    break;
                case string s:
                    Console.WriteLine($"string {variantData}");
                    break;
                case float or double:
                    Console.WriteLine($"float or double {variantData}");
                    break;
                case DateTime dt: // type check
                    Console.WriteLine($"Datetime {variantData}");
                    break;
                default:
                    Console.WriteLine($"No Match {variantData.GetType().FullName} = {variantData}");
                    break;

            }

            // switch expression
            string GetDay()
            {
                return DateTime.Now.DayOfWeek switch
                {
                    DayOfWeek.Monday => DayOfWeek.Monday.ToString(),
                    DayOfWeek.Tuesday => DayOfWeek.Tuesday.ToString(),
                    DayOfWeek.Wednesday => DayOfWeek.Wednesday.ToString(),
                    DayOfWeek.Thursday => DayOfWeek.Thursday.ToString(),
                    DayOfWeek.Friday => DayOfWeek.Friday.ToString(),
                    DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend",

                };
            }

            Console.WriteLine(GetDay());

            string GetDayByLambda() => DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => DayOfWeek.Monday.ToString(),
                DayOfWeek.Tuesday => DayOfWeek.Tuesday.ToString(),
                DayOfWeek.Wednesday => DayOfWeek.Wednesday.ToString(),
                DayOfWeek.Thursday => DayOfWeek.Thursday.ToString(),
                DayOfWeek.Friday => DayOfWeek.Friday.ToString(),
                _ => "Weekend",
            };

            Console.WriteLine(GetDayByLambda());



        }
    }
}
