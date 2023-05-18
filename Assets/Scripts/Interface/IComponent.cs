using ComponentVisitor;

namespace Interface
{
    public interface IComponent
    {
        public void Accept(IComponentVisitor visitor);
    }
}