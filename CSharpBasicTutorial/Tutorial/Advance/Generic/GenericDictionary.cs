using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpTutorial.Tutorial.Advance
{
    /// <summary>
    /// List<T>  형태에 대한 Test
    /// </summary>
    public class GenericDictionary
    {
        public class Shape
        {
            protected virtual string GetClassName() => GetType().Name;
            public virtual void PrintDraw() =>Console.WriteLine($"Drawing a {GetClassName()}");           
        }
        public class Circle : Shape { }
        public class Rectangle : Shape { }
        public class Triangle : Shape { }
      
        public class Test : ITest
        {
            public void Run()
            {
                Dictionary<string, Shape> dic = new Dictionary<string, Shape>();
                // dic 에  하나씩 입력
                Shape newItem = new Shape();
                dic.Add(newItem.GetType().Name, newItem);

                newItem = new Circle();
                // 상속한 클래스도 입력 가능 
                dic.Add(newItem.GetType().Name, newItem);

                // 초기화 선언
                Dictionary<string, Shape> subList = new Dictionary<string, Shape>()
                {
                    { typeof(Rectangle).Name, new Rectangle() },
                    { typeof(Triangle).Name, new Triangle() },
                };

                // addRange 는 dictionary 에는 없다.
                // dic.AddRange(subList);
                // 그래서 확장 메소드중 concat 를 이용한다. (linq)
                // 실제로 c# 에서 Linq 를 제외하면 coding 이 상당히 힘들어 지게 된다.
                dic = dic.Concat(subList).ToDictionary(d=>d.Key, d=>d.Value);

                // print
                Print(dic);

                // 삭제
                dic.Remove(dic.FirstOrDefault().Key);

                Console.WriteLine($"\ndic.first 삭제 후에 dic 내용\n");
                // print
                Print(dic);

                // 찾기
                Console.WriteLine("\ncircle 을 찾습니다.\n");
                var key = typeof(Circle).Name;
                if (dic.ContainsKey(key))
                {
                    var item = dic[key];
                    if (item != null)
                        Console.WriteLine("circle 을 찾았습니다.");
                    item?.PrintDraw();
                } else
                {
                    Console.WriteLine("circle 을 찾지 못했습니다.");
                }
            }

            private void Print(IDictionary<string,Shape> list)
            {
                foreach (var item in list) item.Value.PrintDraw();
            }
        }
    }
    //public static class GenericExtensions 
    //{
    //    public static void AddRange<K, T, TI>(this IDictionary<K, T> target, IEnumerable<TI> source, Func<TI, K> key, Func<TI, T> selector, bool set = true)
    //    {
    //        source.ForEach(i =>
    //        {
    //            var dKey = key(i);
    //            var dValue = selector(i);
    //            if (set)
    //            {
    //                target[dKey] = dValue;
    //            }
    //            else
    //            {
    //                target.Add(key(i), selector(i));
    //            }
    //        });

    //    }
    //}

}

