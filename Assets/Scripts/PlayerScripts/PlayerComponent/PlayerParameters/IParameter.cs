using System;
using Interface;

namespace PlayerScripts.PlayerComponent.PlayerParameters
{
    public interface IParameter : IComponent
    {
        public Type ApplyTo(Action<IParameterType> action);
    }
}