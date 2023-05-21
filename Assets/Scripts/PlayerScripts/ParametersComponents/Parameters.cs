using System.Collections.Generic;
using ComponentVisitor;
using Interface;
using Parameters.Components;
using PlayerScripts.ParametersComponents.Components;

namespace PlayerScripts.ParametersComponents
{
    public class Parameters : IComponent
    {
        private List<IParameter> _components;

        public Parameters(int accuracy, int endurance, int intellect, int luck, int power, int speed, int strengthOfSpirit)
        {
            _components = new List<IParameter>()
            {
                new Parameter<Accuracy>(accuracy),
                new Parameter<Endurance>(endurance),
                new Parameter<Intellect>(intellect),
                new Parameter<Luck>(luck),
                new Parameter<Power>(power),
                new Parameter<Speed>(speed),
                new Parameter<StrengthOfSpirit>(strengthOfSpirit),
            };
        }

        public void Set<T>(Parameter<T> parameter) where T : IParameterType
        {
            _components.Add(parameter);
        }

        public void Accept(IComponentVisitor visitor)
        {
            foreach (var component in _components)
            {
                component.Accept(visitor);
            }
        }
    }
}