using ComponentVisitor;
using Interface;

namespace PlayerScripts.PlayerComponent.Resistrs
{
    public abstract class BaseResist : IResists
    {
        public abstract void Accept(IComponentVisitor visitor);
    }
}