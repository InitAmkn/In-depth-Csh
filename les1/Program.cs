using les1;
using System;

class Program
{
    public static void Main()
    {
        var person1 = new Person()
        { 
            Name = "Иван",
            Age = 10,
            Gender = Gender.Male
        };
        
      
        var person5 = new Person()
        {
            Name = "Катя",
            Age = 1,
            Gender = Gender.Female
        };

        var person2 = new PersonWithChildren()
        {
            Name = "Алиса",
            Age = 14,
            Gender = Gender.Female,
            Children = new[] { person1}
        };
        var person3 = new PersonWithChildren()
        {
            Name = "Лев",
            Age = 54,
            Gender = Gender.Male,
            Children = new[] { person1, person2}
        }; 
        
        var person4 = new PersonWithChildren()
        {
            Name = "Петр",
            Age = 92,
            Gender = Gender.Male,
            Children = new[] { person3}
        };

        foreach (var descendant in person4.GetAllDescendants())
        {
                Console.WriteLine(descendant);
        }


        //Доработайте приложение генеалогического дерева таким образом чтобы программа
        //выводила на экран близких родственников(жену / мужа).
        //Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.
        //(реализация с урока есть в FamilyMember_task3.cs, но будет лучше если вы напишите свою)



    }
}