using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicTutorial.Tutorial;

public class ClassFieldPropertyMethodFinalizersObjectInitializerMethodOverload
{
    private string _lastName; // 필드 선언

    /// <summary>
    /// property 선언
    /// </summary>
    public string LastName { get => _lastName; set => LastName = value; }

    /// <summary>
    /// auto property 선언
    /// </summary>
    public string FirstName { get; set; } 


    /// <summary>
    /// Finalizer
    /// 종료자(이전에는 소멸자 라고 함)는 가비지 수집기에서 
    /// 클래스 인스턴스를 수집할 때 필요한 최종 정리를 수행하는 데 사용됨.
    /// </summary>
    ~ClassFieldPropertyMethodFinalizersObjectInitializerMethodOverload()
    {

    }


    /// <summary>
    /// method overload
    /// 메소드 이름은 같고 parameter 가 다르다.
    /// parameter 를 입력하지 않으면 WriteName() 이 실행되고
    /// string parameter 를 입력하면 WriteName(string middleName) 이 실행된다.
    /// int parameter 를 입력하면 WriteName(int age) 이 실행된다.
    /// </summary>
    public void WriteName()=>Console.WriteLine(FirstName + " " + LastName);
    public void WriteName(string middleName)=> Console.WriteLine(FirstName + $" {middleName} " + LastName);
    public void WriteName(int age) => Console.WriteLine(FirstName + " " + LastName + $" is {age} years old ");
}

