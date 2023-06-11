using System;
using Items.ItemComponent;
using Items.ItemComponent.ItemComponentInfo;

namespace ComponentVisitor
{
    public class ItemPriceVisitor : AbstractVisitor
    {
        private int _defaultPrice;
        private int _bonusPrice;
        private int _multiplier;

        public override void Visit<T>(ItemPrice<T> component)
        {
            Type type = typeof(T);

            if (type == typeof(DefaultPrice))
            {
                _defaultPrice = component.Price;
            }
            else
            {
                _bonusPrice = component.Price;
                _multiplier = component.Multiplier;
            }
        }

        public int GetPrise()
        {
            return (_defaultPrice + _bonusPrice) * _multiplier;
        }
    }
}