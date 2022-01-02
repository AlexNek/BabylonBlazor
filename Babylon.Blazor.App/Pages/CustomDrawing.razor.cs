using System.Threading.Tasks;

using Babylon.Blazor;

namespace BabylonBlazorApp.Pages
{
    public class CustomDrawingData : IData
    {

    }

    public partial class CustomDrawing
    {
        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// Override this method if you will perform an asynchronous operation and
        /// want the component to refresh when that operation is completed.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await InitPage();
        }

        private async Task InitPage()
        {
            await Task.Delay(0);
        }

        public CustomDrawingData PanelData { get; set; }
    }
}