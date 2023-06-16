using AttackSystem;
using ComponentVisitor;
using Interface;

namespace ManaPoint
{
    public class Mana<TParameter> : AbstractMana where TParameter : IParameterType

    {
        public Mana(IComponent component) : base(component)
        {
        }

        protected override int GetMaxManaPoint()
        {
            ManaVisitor manaPointVisitor = new ManaVisitor();
            ParameterVisitorType<TParameter> parameterVisitorType = new ParameterVisitorType<TParameter>();
            Component.Accept(manaPointVisitor);
            Component.Accept(parameterVisitorType);

            return manaPointVisitor.ManaPoint + Effect.Get(parameterVisitorType.Value);
        }
    }
}