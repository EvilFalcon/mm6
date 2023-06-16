using AttackSystem;
using ComponentVisitor;
using Interface;
using PlayerScripts.ParametersComponents.Components;

namespace ManaPoint
{
    public class ManaDoobleType<TIntellect, TStrengthOfSpirit> : AbstractMana
        where TIntellect : Intellect
        where TStrengthOfSpirit : StrengthOfSpirit
    {
        public ManaDoobleType(IComponent component) : base(component)
        {
        }

        protected override int GetMaxManaPoint()
        {
            ManaVisitor manaPointVisitor = new ManaVisitor();
            ParameterVisitorType<TIntellect> parameterVisitorTypeIntellect = new ParameterVisitorType<TIntellect>();
            ParameterVisitorType<TStrengthOfSpirit> parameterVisitorStrengthOfSpirit = new ParameterVisitorType<TStrengthOfSpirit>();
            Component.Accept(parameterVisitorTypeIntellect);
            Component.Accept(parameterVisitorStrengthOfSpirit);
            Component.Accept(manaPointVisitor);
            return manaPointVisitor.ManaPoint + Effect.Get
                (parameterVisitorTypeIntellect.Value + parameterVisitorStrengthOfSpirit.Value);
        }
    }
}