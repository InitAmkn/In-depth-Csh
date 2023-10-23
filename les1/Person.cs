

using System;

namespace les1
{

    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Person? ParentOne {  get; set; }
        public Person? ParentTwo { get; set; }


        public Person[] GetAllDescendants()
        {
            var generations = new List<Person>() { this };
         
            int i = 0;

            while (i < generations.Count)
            { 
                if (generations[i] is PersonWithChildren)
                {
                   var nextGeneration = ((PersonWithChildren)generations[i]).Children;
                    foreach (var item in nextGeneration)
                    {
                        if (!generations.Contains(item))
                        generations.Add(item);
                    }
                }
                i++;
             }
            return generations.ToArray()[1..];
        }
        private bool IsGenerationHaveChildren(List<Person> Generation)
        {
            foreach (var item in Generation)
            {
                if (item is PersonWithChildren)
                {
                    return true;

                }
            }
            return false;
        }

        public List<Person> GetParents()
        {
            List<Person> parents = new List<Person>();
            if (ParentOne!= null) parents.Add(ParentOne);
            if (ParentTwo!= null) parents.Add(ParentTwo);
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

                foreach (var item in ((PersonWithChildren)Parent).Children)
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

        public override string ToString()
        {
            return $"Name: {Name}; Age: {Age}; Gender {Gender}";
        }
    }
   
}
