using System;

namespace Babylon.Blazor
{
    public class SpinnerСommander
    {
        public event EventHandler<bool> SpinnerChanged;

        public void Show()
        {
            OnSpinnerChanged(true);
        }

        public void Hide()
        {
            OnSpinnerChanged(false);
        }

        protected virtual void OnSpinnerChanged(bool visible)
        {
            SpinnerChanged?.Invoke(this, visible);
        }
    }
}
