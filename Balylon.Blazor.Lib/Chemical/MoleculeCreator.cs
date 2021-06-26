using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class MoleculeCreator.
    /// Create 3D scene from description
    /// Implements the <see cref="Babylon.Blazor.SceneCreator" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.SceneCreator" />
    public class MoleculeCreator : SceneCreator
    {
        /// <summary>
        /// The connector radius
        /// </summary>
        private const double ConnectorRadius = 0.075;

        /// <summary>
        /// The internal data storage
        /// </summary>
        private readonly ChemicalData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoleculeCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon interop library instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <param name="data">The data.</param>
        public MoleculeCreator(BabylonInstance babylonInstance, string canvasId, ChemicalData data)
            : base(babylonInstance, canvasId)
        {
            _data = data;
        }

        /// <summary>
        /// create the scene  asynchronous .
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        /// <exception cref="Dictionary<string, AtomMapper>"></exception>
        public override async Task CreateAsync(BabylonCanvasBase canvas)
        {
            var tuple = _data.GetBoundingBox();
            double dx = Math.Abs(tuple.Max.X - tuple.Min.X);
            double dy = Math.Abs(tuple.Max.Y - tuple.Min.Y);
            double absolutMax = Math.Max(dx, dy);
            
            //Console.WriteLine($"bounding box:{tuple.Min}..{tuple.Max}, dx:{dx}, dy:{dy}, Zmin:{tuple.Min.Z}");
            //test:       bounding box:(-1.01, -1, -1)..                       (1, 1, 1),                dx:2.01, dy:2, Zmin:-1
            //epinephrine:bounding box:(-3.969, -3.2062999999999997, -1.8589)..(4.5925, 2.8441, 2.3907), dx: 8.5615, dy: 6.0504, Zmin: -1.8589

            Engine engine = await BabylonInstance.CreateEngine(CanvasId, true);
            Scene scene = await engine.CreateScene();
            //Scene scene = await BabylonInstance.CreateScene(engine);
            //set rotation center
            var cameraTarget = await BabylonInstance.CreateVector3(0, 0, 0);
            //set camera
            //var camera = await scene.CreateArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 10, cameraTarget, CanvasId);
            var camera = await scene.CreateArcRotateCamera("Camera", 3 * Math.PI / 2, 3 * Math.PI / 8, absolutMax * 3.6, cameraTarget, CanvasId);
            var hemisphericLightDirection = await BabylonInstance.CreateVector3(1, 1, 0);
            var light1 = await scene.CreateHemispehericLight("light1", hemisphericLightDirection, 0.98);

            // don't really need
            //var pointLightDirection = await BabylonInstance.CreateVector3(0, 1, -1);
            //var light2 = await scene.CreatePointLight("light2", pointLightDirection,0.4);

            Dictionary<string, AtomMapper> atomMap = new Dictionary<string, AtomMapper>();
            foreach (AtomDescription atomDescription in _data.Atoms)
            {
                if (!atomMap.ContainsKey(atomDescription.Name))
                {
                    atomMap.Add(atomDescription.Name, new AtomMapper(){Name = atomDescription.Name });
                    //Console.WriteLine($"added: {atomDescription.Name}");
                }
            }

            Color[] colors = ColorPalette.GetColors;
            var atomMapKeys = atomMap.Keys;
            int index = 0;
            foreach (string key in atomMapKeys)
            {
                AtomMapper atomMapper = atomMap[key];
                Color mainColor = colors[index];

                var diffuseColor = await BabylonInstance.CreateColor3(mainColor); //Brown,DarkRed
                //atomMapper.Material = await scene.CreateMaterial(key, diffuseColor, null, 0.4);
                atomMapper.Material = await scene.CreateMaterial(key, diffuseColor, null, 1.0);
                string colorAsText = $"#{mainColor.R:X2}{mainColor.G:X2}{mainColor.B:X2}";
                DynamicTexture texture = await scene.CreateDynamicTexture(key, "bold 60px monospace", colorAsText, 2 * Math.PI * 40, 2 * Math.PI * 20);
                atomMapper.Material.SetTexture(texture);
                index++;
                index %= colors.Length;
            }
            
            _data.MoveCenterToZero();

            foreach (AtomDescription atomDescription in _data.Atoms)
            {
                SphereOptions options = new SphereOptions { Diameter = 1.0 };
                MeshParameters parameters = new MeshParameters(BabylonInstance) { Options = options };
                await parameters.SetPosition(atomDescription.X * DistanceScale, atomDescription.Y * DistanceScale, atomDescription.Z * DistanceScale);
                //rotate for correct viewing of text texture
                await parameters.SetRotation(0, 0, Tools.GradToRadian(180));
                var sphere = await scene.CreateSphere($"sphere{atomDescription.Name}", parameters);
                AtomMapper atomMapper = atomMap[atomDescription.Name];
                sphere.SetMaterial(atomMapper.Material);
            }


            foreach (BondDescription bond in _data.Bonds)
            {
                try
                {
                    int fromAtomIndex = bond.FromAtomIndex;
                    int toAtomIndex = bond.ToAtomIndex;
                    AtomDescription fromAtom = _data.Atoms[fromAtomIndex - 1];
                    AtomDescription toAtom = _data.Atoms[toAtomIndex - 1];
                    switch (bond.Type)
                    {
                        case BondDescription.BondType.Single:
                            await DrawSingleBond(toAtom, fromAtom, scene, fromAtomIndex, toAtomIndex);
                            break;
                        case BondDescription.BondType.Double:
                            await DrawDoubleBond(toAtom, fromAtom, scene, fromAtomIndex, toAtomIndex, 0.075);
                            break;
                        case BondDescription.BondType.Triple:
                            await DrawSingleBond(toAtom, fromAtom, scene, fromAtomIndex, toAtomIndex);
                            await DrawDoubleBond(toAtom, fromAtom, scene, fromAtomIndex, toAtomIndex, 0.1);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{bond}, Max count:{_data.Atoms.Count}  {ex}");
                }
            }

            //await BabylonInstance.CreateGrid(5, 5, 0.1, Color.Aqua);
            //await scene.ShowWorldAxis(6);

            await camera.SetAutoRotate(canvas.UseAutoRotate, canvas.IdleRotationSpeed);
            await BabylonInstance.RunRenderLoop(engine, scene);
        }

        /// <summary>
        /// Draws the single bond.
        /// </summary>
        /// <param name="toAtom">To atom.</param>
        /// <param name="fromAtom">From atom.</param>
        /// <param name="scene">The scene.</param>
        /// <param name="fromAtomIndex">Index of from atom.</param>
        /// <param name="toAtomIndex">Index of to atom.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        private async Task DrawSingleBond(AtomDescription toAtom, AtomDescription fromAtom, Scene scene, int fromAtomIndex, int toAtomIndex)
        {
            Vector3 fromPos = await BabylonInstance.CreateVector3(fromAtom.X * DistanceScale, fromAtom.Y * DistanceScale, fromAtom.Z * DistanceScale);

            Vector3 toPos = await BabylonInstance.CreateVector3(toAtom.X * DistanceScale, toAtom.Y * DistanceScale, toAtom.Z * DistanceScale);

            var tube = await scene.CreateTube($"tube{fromAtomIndex}-{toAtomIndex}", fromPos, toPos, ConnectorRadius);

            // colorize main connection for test
            //var diffuseColor = await BabylonInstance.CreateColor3(Color.MediumOrchid); //Brown,DarkRed
            ////var emissiveColor= await BabylonInstance.CreateColor3(mainColor);
            //var material = await scene.CreateMaterial("key", diffuseColor, null, 1);
            //tube.SetMaterial(material);
        }


        /// <summary>
        /// Draws the double bond.
        /// </summary>
        /// <param name="toAtom">To atom.</param>
        /// <param name="fromAtom">From atom.</param>
        /// <param name="scene">The scene.</param>
        /// <param name="fromAtomIndex">Index of from atom.</param>
        /// <param name="toAtomIndex">Index of to atom.</param>
        /// <param name="lineDistance">The line distance.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        private async Task DrawDoubleBond(AtomDescription toAtom, AtomDescription fromAtom, Scene scene, int fromAtomIndex, int toAtomIndex, double lineDistance)
        {
            const double Epsilon = 0.001;

            double dxRel = toAtom.X - fromAtom.X;
            double dxOrig = Math.Abs(dxRel);
            double dyRel = toAtom.Y - fromAtom.Y;
            double dyOrig = Math.Abs(dyRel);
            double dzOrig = Math.Abs(toAtom.Z - fromAtom.Z);

            double dz = 0;
            int signX = 1;
            if ((dxRel > 0 && dyRel < 0) || (dxRel < 0 && dyRel > 0))
            {
                signX = -1;
            }

            (double X, double Y) tuple2 = new(0, 0);
            if (dxOrig < Epsilon && dzOrig < Epsilon && dyOrig > 0)
            {
                tuple2.X = lineDistance;
                //Console.WriteLine($"Atoms90: {fromAtom} -> {toAtom} dzOrig={dzOrig}, dyOrig={dyOrig}, angle orig:{90}");
            }
            else if (dxOrig < Epsilon && dyOrig < Epsilon)
            {
                var tuple1 = Tools.RectangularTriangleSolutionAngle(dzOrig, dyOrig);
                double connectionAngleRadian = Tools.GradToRadian(90) - tuple1.Angle;
                //Console.WriteLine($"Atoms00: {fromAtom} -> {toAtom} dzOrig={dzOrig}, dyOrig={dyOrig}, angle orig:{Tools.RadianToGrad(connectionAngleRadian)}");
                
                var tuple3 = Tools.RectangularTriangleSolutions(lineDistance, connectionAngleRadian);
                //Console.WriteLine($"Offsets for distance {lineDistance}: {tuple3.X} - {tuple3.Y}");
                dz = tuple3.X;
                tuple2.Y = tuple3.Y;
            }
            else
            {
                var tuple1 = Tools.RectangularTriangleSolutionAngle(dxOrig, dyOrig);
                //Console.WriteLine($"Atoms:{fromAtom} -> {toAtom} dxRel={dxRel}, dxOrig={dxOrig}, dyRel={dyRel}, dyOrig={dyOrig}, angle grad:{Tools.RadianToGrad(tuple1.Angle)}");

                double connectionAngleRadian = Tools.GradToRadian(90) - tuple1.Angle;
                tuple2 = Tools.RectangularTriangleSolutions(lineDistance, connectionAngleRadian);
                //Console.WriteLine($"Offset for distance {lineDistance}: {tuple2.X} - {tuple2.Y}, connectionAngle grad:{Tools.RadianToGrad(connectionAngleRadian)}");
            }

            Vector3 fromPos2 = await BabylonInstance.CreateVector3(
                                   (fromAtom.X - signX * tuple2.X) * DistanceScale,
                                   (fromAtom.Y + tuple2.Y) * DistanceScale,
                                   (fromAtom.Z + dz) * DistanceScale);
            Vector3 fromPos3 = await BabylonInstance.CreateVector3(
                                   (fromAtom.X + signX * tuple2.X) * DistanceScale,
                                   (fromAtom.Y - tuple2.Y) * DistanceScale,
                                   (fromAtom.Z + dz) * DistanceScale);

            Vector3 toPos2 = await BabylonInstance.CreateVector3(
                                 (toAtom.X - signX * tuple2.X) * DistanceScale,
                                 (toAtom.Y + tuple2.Y) * DistanceScale,
                                 (toAtom.Z + dz) * DistanceScale);

            Vector3 toPos3 = await BabylonInstance.CreateVector3(
                                 (toAtom.X + signX * tuple2.X) * DistanceScale,
                                 (toAtom.Y - tuple2.Y) * DistanceScale,
                                 (toAtom.Z + dz) * DistanceScale);


            var tube2 = await scene.CreateTube($"tube{fromAtomIndex}-{toAtomIndex}B", fromPos2, toPos2, ConnectorRadius);
            var tube3 = await scene.CreateTube($"tube{fromAtomIndex}-{toAtomIndex}C", fromPos3, toPos3, ConnectorRadius);
        }

        /// <summary>
        /// Gets or sets the distance scale.
        /// </summary>
        /// <value>The distance scale.</value>
        public double DistanceScale { get; set; } = 2.0;
    }
}
