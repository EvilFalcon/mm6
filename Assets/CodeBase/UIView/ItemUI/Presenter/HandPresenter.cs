using UIView.ItemUI.Model;
using UIView.ItemUI.View;

namespace UIView.ItemUI.Presenter
{
    public class HandPresenter
    {
        private readonly HandView _view;

        public HandPresenter(HandView view)
        {
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

        public void SetItem(ItemHand itemHand)
        {
            _view.SetSprite(itemHand.Sprite);
        }
    }
}