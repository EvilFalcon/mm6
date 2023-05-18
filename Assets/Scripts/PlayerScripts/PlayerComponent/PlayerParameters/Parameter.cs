using System;
using ComponentVisitor;
using Interface;

namespace PlayerScripts.PlayerComponent.PlayerParameters
{
    public class Parameter<T> : IParameter where T : IParameterType
    {
        public Parameter(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public Type ApplyTo(Action<IParameterType> action)
        {
            return typeof(T);
        }
    }
}