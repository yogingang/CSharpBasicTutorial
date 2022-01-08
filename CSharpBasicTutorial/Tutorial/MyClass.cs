using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicTutorial.Tutorial;

/// <summary>
/// 여러가지 생성자 정의
/// </summary>
public class MyClass
{
    private readonly string _lastName;
    private readonly string _firstName;

    private static readonly string _staticField;

    /// <summary>
    /// 생성자를 통해 lastName 과 firstName 을 설정한다. 
    /// </summary>
    /// <param name="lastName"></param>
    /// <param name="firstName"></param>
    public MyClass(string lastName, string firstName)
    {
        _lastName = lastName;
        _firstName = firstName;
    }

    /// <summary>
    /// parameter 가 없는 기본 생성자
    /// </summary>
    public MyClass()
    {
        _lastName = "David"; 
        _firstName = "anderson";
    }



    /// <summary>
    /// 정적 생성자는 parameter 를 가질 수 없다.
    /// application 실행 시 한번만 실행된다. 
    /// </summary>
    static MyClass()
    {
        _staticField = "한번만 실행되는 생성자";
    }

    /// <summary>
    /// 각 field 값 print
    /// </summary>
    public void PrintFields()
    {
        $"staticField = {_staticField}, _firstName = {_firstName}, _lastName = {_lastName}".WriteLine();
    }
    
}

