using System;
using System.Collections.Generic;
using System.Linq;
using Items.ItemComponent;

namespace ComponentVisitor
{
    public class ItemNameVisitor : AbstractVisitor
    {
        private List<ItemName> _components = new List<ItemName>();
        private ItemName[] _sortedNames;
        
        private ItemName[] SortedNames => _sortedNames
            ??= _components
                .OrderBy(component => component.Order)
                .ToArray();

        public override void Visit(ItemName component)
        {
            _components.Add(component);
        }

        public string GetNameItem()
        {
            return String.Join(' ', SortedNames.Select(itemName => itemName.Type));
        }
    }
}