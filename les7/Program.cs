

//создать методы создающий этот класс вызывая 
//один из его конструкторов (по одному конструктору на метод).
//Задача не очень сложна и служит больше
//для разогрева перед следующей задачей.



//Напишите 2 метода использующие рефлексию
//1 - сохраняет информацию о классе в строку
//2- позволяет восстановить класс из строки с информацией о методе
//В качестве примере класса используйте класс TestClass.
//Шаблоны методов для реализации:
//static object StringToObject(string s) { }
//static string ObjectToString(object o) { }

//Пример того как мог быть выглядеть сохраненный в строку объект: 
//“TestClass, test2, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null:TestClass | I:1 | S:STR | D:2.0 |”


public class TestClass
{
    public int I { get; set; }
    public string? S { get; set; }
    public decimal D { get; set; }
    public char[]? C { get; set; }
    public TestClass()
    {

    }
    public TestClass(int i)
    {
        I = i;
    }
    public TestClass(int i, string s, decimal d, char[] c) : this(i)
    {
        S = s;
        D = d;
        C = c;
    }


    public static void CreateTestClassInstance(
            int i,
            string s,
            decimal d,
            char[] c)
    {
        var testClassType = typeof(TestClass);
        var testClass = Activator.CreateInstance(testClassType) as TestClass;

        var testClassTwo = Activator.CreateInstance(
            testClassType,
            new object[] { i });

        var testClassThird = Activator.CreateInstance(
            testClassType,
            new object[] { i, s, d, c });

    }
    //https://github.com/NIKKnak/CSharp-course-Lesson-and-DZ-7
}