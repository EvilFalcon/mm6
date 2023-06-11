using System;
using ComponentVisitor;

namespace PlayerScripts.PlayerComponent.Resistrs
{
    public class Resist<T> : BaseResist where T : IResistType

    {
        public Resist(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public Type ApplyToAll()
        {
            return typeof(T);
        }
    }
}