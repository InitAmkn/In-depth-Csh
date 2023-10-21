

namespace les1
{
    public class PersonWithChildren : Person
    {
        public required Person[] Children { get; set; }
    }
}
