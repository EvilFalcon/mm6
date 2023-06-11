using System;
using Items.ItemComponent;

namespace ComponentVisitor
{
    public class DescriptionVisitor : AbstractVisitor
    {
        private string _descriptionBace;
        private string _descriptionBonus = " Особое :";

        public override void Visit(ItemDescription component)
        {
            if (String.IsNullOrEmpty(_descriptionBace) == false)
                _descriptionBace = "";
            if (String.IsNullOrEmpty(_descriptionBonus) == false)
                _descriptionBace = " Особое :";

            if (component.Order == 1)
                _descriptionBace = component.Description;

            if (component.Order == 2)
                _descriptionBonus = component.Description;
        }

        public string GetDescriptionItem()
        {
            return _descriptionBace + _descriptionBonus;
        }
    }
}