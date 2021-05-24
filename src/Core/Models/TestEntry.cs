using Core.Basis;

namespace Core.Models
{
    public class TestEntry : AggregateRoot
    {
        public string PropertyOne { get; init; }
        public int PropertyTwo { get; init; }
        public string PropertyThree { get; init; }
    }
}
