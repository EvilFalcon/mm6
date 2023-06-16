using Interface;
using PlayerScripts.ParametersComponents;

namespace ComponentVisitor
{
    public class ParameterVisitorType<TParameter> : AbstractVisitor where TParameter : IParameterType
    {
        public int Value { get; private set; }

        public override void Visit<T>(Parameter<T> component)
        {
            if (component is Parameter<TParameter> endurance)
                Value += endurance.Value;
        }
    }
}