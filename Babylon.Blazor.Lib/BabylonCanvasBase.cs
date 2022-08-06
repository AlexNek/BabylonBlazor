using System;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor.Chemical;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    /// <summary>
    /// Class BabylonCanvasBase.
    /// Implements the <see cref="Microsoft.AspNetCore.Components.ComponentBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class BabylonCanvasBase : ComponentBase
    {
        private BabylonInstance _babylonInstance;

        private bool _reRender;

        /// <summary>
        /// Initializes the szene.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        protected virtual async Task InitializeSzene(BabylonInstance babylonInstance, string canvasId)
        {
            ChemicalData panelData;
            if (SceneData is ChemicalData)
            {
                panelData = (ChemicalData)SceneData;
                MoleculeCreator creator = new MoleculeCreator(babylonInstance, canvasId, panelData);
                if (panelData.Atoms.Count > 0)
                {
                    if (panelData.ShowErrorText && !String.IsNullOrEmpty(panelData.ErrorText))
                    {
                        await babylonInstance.DrawText(canvasId, panelData.ErrorText, Color.DarkRed);
                    }
                    else
                    {
                        await creator.CreateAsync(this);
                    }
                }
                else
                {
                    await babylonInstance.DrawText(canvasId, "Nothing to Draw", Color.DarkRed);
                }

            }
            else
            {
                await babylonInstance.DrawText(canvasId, "Scene data is null", Color.DarkRed);
                //use water molecule by errors
                //panelData = new ChemicalData();
                //panelData.Atoms.Add(new AtomDescription { Name = "O", X = 2.5369, Y = -0.1550, Z = 0.0000 });
                //panelData.Atoms.Add(new AtomDescription { Name = "H", X = 3.0739, Y = 0.1550, Z = 0.0000 });
                //panelData.Atoms.Add(new AtomDescription { Name = "H", X = 2.0000, Y = 1.1550, Z = 0.0000 });
                //panelData.Bonds.Add(new BondDescription(1, 2, BondDescription.BondType.Single));
                //panelData.Bonds.Add(new BondDescription(1, 3, BondDescription.BondType.Single));
            }

            
        }

        /// <summary>
        /// on after render as an asynchronous operation.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
        /// <remarks>The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.</remarks>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender || _reRender)
            {
                //https://playground.babylonjs.com
                //https://doc.babylonjs.com/
                try
                {
                    if (_babylonInstance != null)
                    {
                        _babylonInstance.Dispose();
                        _babylonInstance = null;
                    }

                    //await JS.InvokeVoidAsync("console.log", "***Try create JS babylon instance");
                    _babylonInstance = await instanceCreator.CreateBabylonAsync();
                    //var scene = await BabylonInstance.CreateTestScene(canvasId);

                    await InitializeSzene(BabylonInstance, CanvasId);
                }
                catch (Exception ex)
                {
                    await JS.InvokeVoidAsync("console.log", $"***Exception:{ex}");
                }
                finally
                {
                    //it is not the best solution but quickly
                    _reRender = false;
                }
            }
        }

        /// <summary>
        /// Returns a flag to indicate whether the component should render.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ShouldRender()
        {
            //Console.WriteLine("*ShouldRender*");
            _reRender = RecreateControlAfterRefresh;
            return base.ShouldRender();
        }

        /// <summary>
        /// Gets or sets the canvas identifier.
        /// </summary>
        /// <value>The canvas identifier.</value>
        [Parameter]
        public string CanvasId { get; set; } = "babylon-canvas";


        /// <summary>
        /// Gets or sets the scene data.
        /// </summary>
        /// <value>The scene data.</value>
        [Parameter]
        public IData SceneData { get; set; }

        /// <summary>
        /// Gets or sets the idle rotation speed.
        /// </summary>
        /// <value>The idle rotation speed.</value>
        [Parameter]
        public double IdleRotationSpeed { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether [use automatic rotate].
        /// </summary>
        /// <value><c>true</c> if [use automatic rotate]; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool UseAutoRotate { get; set; } = true;

        public bool RecreateControlAfterRefresh { get; set; } = true;

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        protected BabylonInstance BabylonInstance
        {
            get
            {
                return _babylonInstance;
            }
        }

        [Inject]
        private InstanceCreator instanceCreator { get; set; }

        [Inject]
        private IJSRuntime JS { get; set; }

        //[CascadingParameter]
        //public Error Error { get; set; }
        //https://docs.microsoft.com/en-us/aspnet/core/blazor/fundamentals/handle-errors?view=aspnetcore-5.0&pivots=webassembly
    }
}
