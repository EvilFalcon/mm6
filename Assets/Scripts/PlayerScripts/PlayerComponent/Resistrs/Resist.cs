using System;
using ComponentVisitor;
using Interface;

namespace PlayerScripts.PlayerComponent.Resistrs
{
    public class Resist<T> : IResists where T : IResistType

    {
        public Resist(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyToAll()
        {
            return typeof(T);
        }
    }
}