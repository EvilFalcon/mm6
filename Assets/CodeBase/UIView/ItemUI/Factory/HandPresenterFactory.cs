using UIView.ItemUI.Presenter;
using UIView.ItemUI.View;

namespace UIView.ItemUI.Factory
{
    public class HandPresenterFactory
    {
        private readonly HandViewFactory _handViewFactory;

        public HandPresenterFactory(HandViewFactory handViewFactory)
        {
            _handViewFactory = handViewFactory;
        }

        public HandPresenter Create()
        {
            HandView handView = _handViewFactory.Create();
            return new HandPresenter(handView);
        }
    }
}