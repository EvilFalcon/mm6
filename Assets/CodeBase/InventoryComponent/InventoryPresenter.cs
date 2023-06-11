namespace InventoryComponent
{
    public class InventoryPresenter : IPresenter
    {
        private readonly Inventory _inventory;
        private readonly InventoryView _view;

        public InventoryPresenter(Inventory inventory, InventoryView view)
        {
            _inventory = inventory;
            _view = view;
        }

        public void Enable()
        {
            _view.Show();
        }

        public void Disable()
        {
            _view.Hide();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}