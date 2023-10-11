using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les1
{
    internal class Task1
    {
        //1
        //Спроектируйте программу для построения генеалогического дерева.
        //Учтите что у нас есть члены семьи у кого нет детей(дет). 
        //Есть члены семьи у кого дети есть (взрослые). Есть мужчины и женщины.


        //2
        //Доработать предыдущий класс реализовав методы вывода родителей, детей,
        //братьев/сестер (включая двоюродных), бабушеки дедушек.
        //Подумайте как лучше реализовать данные методы.

    }

    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Person? ParentOne {  get; set; }
        public Person? ParentTwo { get; set; }

        public List<Person> GetParents()
        {
            List<Person> parents = new List<Person>();
            if (ParentOne!=null)parents.Add(ParentOne);
            if (ParentTwo!= null)parents.Add(ParentTwo);
            return parents;
        }

        public List<Person> GetSiblings()
        {
            List<Person> listSiblings = new List<Person>();
            if (ParentOne != null) listSiblings.AddRange(GetSiblingsByOneParent(ParentOne));
            if (ParentTwo != null) listSiblings.AddRange(GetSiblingsByOneParent(ParentTwo));

            return listSiblings;
        }

        private List<Person> GetSiblingsByOneParent(Person Parent)
        {
            List<Person> listSiblings = new List<Person>();
            if (Parent is PersonWithChildren)
            {
                foreach (var item in ((PersonWithChildren)Parent).GetChildren())
                {
                    if(this != item)
                        listSiblings.Add(item);
                }    
            }
            return listSiblings;
        }

        public List<Person> GetGrandParents()
        {
            List<Person> listGrandParents = new List<Person>();

            if (ParentOne != null) listGrandParents.AddRange(ParentOne.GetParents());
            if (ParentTwo != null) listGrandParents.AddRange(ParentTwo.GetParents());
            return listGrandParents;

        }

    }

  

    public class PersonWithChildren : Person 
    { 
        public required Person[] Children { get; set; }

        public Person[] GetChildren()
        {
            return Children;
        }
    }
    public enum Gender
    {
        Male,
        Female
    }
   
}
