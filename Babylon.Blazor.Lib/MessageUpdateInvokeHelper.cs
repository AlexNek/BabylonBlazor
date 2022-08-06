using System;

using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    public class MessageUpdateInvokeHelper
    {
        private readonly Action _action;

        public MessageUpdateInvokeHelper(Action action)
        {
            _action = action;
        }

        [JSInvokable("Babylon.Blazor")]
        public void UpdateMessageCaller()
        {
            if (_action != null)
            {
                _action.Invoke();
            }
        }
    }
}
