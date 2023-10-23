

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


        public List<List<Person>> GetAllDescendants()
        {
            var generations = new List<Person>() { this };
            var nextGeneration = new List<Person>();
            if (this is PersonWithChildren)
            {
                nextGeneration.AddRange(((PersonWithChildren)this).Children);
            }
            else
            {
                return generations;
            }

            int i = 0;
            while (IsGenerationHaveChildren(generations[i]))
                {
                var generation = new List<Person>();
                    foreach (var person in generations[i])
                    {
                        if (person is PersonWithChildren)
                        {
                            generation.AddRange(((PersonWithChildren)person).Children);
                        }
                    }
                     generations.Add(generation);
                 i++;
                }
            return generations;
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
