using UIView.Model;

namespace UIView
{
    public interface IView
    {
        void Show(InventoryItem[] inventoryItems);
        void Hide();
    }
}