

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




//ДЗ
//Разработайте атрибут позволяющий методу ObjectToString
//сохранять поля классов с использованием произвольного имени.
//Метод StringToObject должен также
//уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.
//[CustomName(“CustomFieldName”)]
//public int I = 0.
//Если использовать формат строки с данными использованной
//нами для предыдущего примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0
//Подсказка:
//Если GetProperty(propertyName) вернул null то очевидно свойства с
//таким именем нет и возможно имя является алиасом заданным с помощью
//CustomName.Возможно, если перебрать все поля с таким атрибутом то для
//одного из них propertyName = совпадает с таковым заданным атрибутом.




using System.Text;
using System.Reflection;
using TestLes7;

namespace les7
{
    class Program
    {
        static void Main(string[] args)
        {

            var v = CreateTestClassInstance(1, 11, "ssad", 3, new char[] { '4', '3', '8', '2' }, new char[] { 'f', 'g', 'k', 'i' });

            string str = ObjectToString(v);
            Console.WriteLine(str);
            object str2 = StringToObject(str);

        }

        public static TestClass CreateTestClassInstance(int i, int ii, string s, decimal d, char[] c, char[] cc)
        {
            var testClassType = typeof(TestClass);
            var testClass = Activator.CreateInstance(testClassType) as TestClass;

            var testClassTwo = Activator.CreateInstance(testClassType, new object[] { i });

            var testClassThird = Activator.CreateInstance(testClassType, new object[] { i, ii, s, d, c, cc });

            return testClassThird as TestClass;
        }
        public static string ObjectToString(object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var type = obj.GetType();
            stringBuilder.Append(type.ToString() + "\n");
            stringBuilder.Append(type.Assembly + "\n");
            stringBuilder.Append(type.Name + "\n");
            var properties = type.GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var item in properties)
            {
                var value = item.GetValue(obj);

                stringBuilder.Append(GetPropertyName(item) + ":");
                if (item.PropertyType == typeof(char[]))
                {
                    stringBuilder.Append(new String(value as char[]) + "\n");
                }
                else
                {
                    stringBuilder.Append(value + "\n");
                }
            }

            return stringBuilder.ToString();
        }


        private static string GetPropertyName(PropertyInfo property)
        {
            var customNameAttribute = (CustomNameAttribute)Attribute.GetCustomAttribute(property, typeof(CustomNameAttribute));
            return customNameAttribute != null ? customNameAttribute.CustomFieldName : property.Name;
        }


        public static object StringToObject(string endString)
        {
            string[] str = endString.Split("\n");
            var typeName = str[2];
            var assemblyName = str[1];
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == assemblyName);
            if (assembly != null)
            {
                var type = assembly.GetTypes().FirstOrDefault(t => t.FullName == typeName);
                if (type != null)
                {
                    var obj = Activator.CreateInstance(type);
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    for (int i = 3; i < str.Length - 1; i++)
                    {
                        var propertyString = str[i].Split(":");
                        var propertyName = propertyString[0];
                        var propertyValue = propertyString[1];
                        var property = properties.FirstOrDefault(p => GetPropertyName(p) == propertyName.Trim()); 
                        if (property != null)
                        {
                            if (property.PropertyType == typeof(int))
                            {
                                property.SetValue(obj, int.Parse(propertyValue.Trim()));
                            }
                            else if (property.PropertyType == typeof(string))
                            {
                                property.SetValue(obj, propertyValue.Trim());
                            }

                        }
                    }
                    return obj;
                }
            }
            return null;
        }


    }
}