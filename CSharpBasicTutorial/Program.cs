// See https://aka.ms/new-console-template for more information 

string[] names;

string[] myNames = { "david", "chriss", "clark", "yogingang" };

int[] myNums = { 10,20,30,40};

string[] newCreate = new string[4] { "david", "chriss", "clark", "yogingang" };
//string[] newCreate = new string[] { "david", "chriss", "clark", "yogingang" };

// 0번째 배열 요소 찍기
Console.WriteLine(myNames[0]); // david

// 0번째 배열 요소 변경
myNames[0] = "tompson";
Console.WriteLine(myNames[0]); // tompson

// 배열 길이
Console.WriteLine(myNames.Length); // 4


// loop 
for( int i = 0; i< myNums.Length; i++ )
{
    Console.WriteLine(myNames[i]);
}


foreach(var myName in myNames)
{
    Console.WriteLine(myName);
}


// sorting
Array.Sort(myNames);
foreach (var myName in myNames)
{
    Console.WriteLine(myName);
}

// Linq
Console.WriteLine(myNums.Max());
Console.WriteLine(myNums.Min());
Console.WriteLine(myNums.Sum());

var orderByAccendingMyNums = myNums.OrderBy(n => n);
foreach(var myNum in orderByAccendingMyNums) Console.WriteLine(myNum);

var orderByDescendingMyNums = myNums.OrderByDescending(n => n);
foreach (var myNum in orderByDescendingMyNums) Console.WriteLine(myNum);


// List
List<string> myNameList = new List<string>()
{
    "david", 
    "chriss", 
    "clark",
    "yogingang"
};

myNameList.Add("tompson");
myNameList.Remove("david");

foreach(var myName in myNameList)
    Console.WriteLine(myName);

Console.WriteLine("order by asc list");
myNameList.OrderBy(n => n).ToList().ForEach(n => Console.WriteLine(n));

Console.WriteLine("order by desc list");
myNameList.OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine(n));