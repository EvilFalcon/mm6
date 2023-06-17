using UIView.ItemUI.View;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace UIView.ItemUI.Presenter
{
    public class HandPresenter
    {
        private readonly HandView _view;

        public HandPresenter(HandView view, Sprite sprite)
        {
            _view = view;
            _view.SetSprite(sprite);
        }

        public void Enable()
        {
            Update(Mouse.current.position);
            _view.Show();
        }

        public void Disable()
        {
            _view.Hide();
        }

        public void Update(Vector2Control position)
        {
            _view.SetPosition(position.value);
        }
    }
}