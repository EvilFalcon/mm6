using UIView.Model;

namespace UIView.InventoryUI
{
    public interface IView
    {
        void Show(InventoryItem[] inventoryItems);
        void Hide();
    }
}