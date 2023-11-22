using System;

namespace Babylon.Blazor
{
    public class ShowLoadingСommander
    {
        public event EventHandler<bool> LoadingChanged;

        public void Show()
        {
            OnLoadingChanged(true);
        }

        public void Hide()
        {
            OnLoadingChanged(false);
        }

        protected virtual void OnLoadingChanged(bool visible)
        {
            LoadingChanged?.Invoke(this, visible);
        }
    }
}
