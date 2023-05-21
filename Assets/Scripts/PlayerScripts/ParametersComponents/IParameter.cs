using System;
using Interface;

namespace PlayerScripts.ParametersComponents
{
    public interface IParameter : IComponent
    {
        public Type ApplyTo(Action<IParameterType> action);
    }
}