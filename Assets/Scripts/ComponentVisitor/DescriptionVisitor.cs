using System;
using Items.ItemComponent;

namespace ComponentVisitor
{
    public class DescriptionVisitor : AbstractVisitor
    {
        private string _description;

        public override void Visit(ItemDescription component)
        {
            if (String.IsNullOrEmpty(_description) == false)
                _description = "";

            _description = component.Description;
        }

        public string GetDescriptionItem()
        {
            return _description;
        }
    }
}