using System.Collections.Generic;
using System.Linq;
using UIView.Model;
using UIView.View;

namespace UIView.Presenter
{
    public class InventoryPresenter : IPresenter
    {
        private List<ItemPresenter> _presenters;
        private readonly InventoryView _view;
        private readonly ItemPresenterFactory _itemPresenterFactory;

        public InventoryPresenter(InventoryView view, ItemPresenterFactory itemPresenterFactory)
        {
            _view = view;
            _itemPresenterFactory = itemPresenterFactory;
        }

        public void Enable()
        {
            Update();
            _presenters.ForEach(presenter => presenter.Enable());
        }

        public void Disable()
        {
            _presenters.ForEach(presenter => presenter.Disable());
        }

        public void Update()
        {
        }

        public void Add(InventoryItem item)
        {
            ItemPresenter presenter = _itemPresenterFactory.Create(item);
            presenter.Enable();

            _presenters.Add(presenter);
        }

        public void Remove(InventoryItem item)
        {
            _presenters.Remove(_presenters.FirstOrDefault(presenter => presenter.IsEqual(item)));
        }
    }
}