using System.Collections.Generic;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class ChemicalData.
    /// Collection of a molecule description
    /// Contains fields from SDF format
    /// Implements the <see cref="Babylon.Blazor.IData" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.IData" />
    public class ChemicalData:IData
    {
        /// <summary>
        /// Gets the atoms.
        /// </summary>
        /// <value>The atoms.</value>
        public List<AtomDescription> Atoms { get; } = new List<AtomDescription>();

        /// <summary>
        /// Gets the bonds.
        /// </summary>
        /// <value>The bonds.</value>
        public List<BondDescription> Bonds { get; } = new List<BondDescription>();

        /// <summary>
        /// Gets the model center.
        /// </summary>
        /// <returns>Point3D.</returns>
        public Point3D GetCenter()
        {
            Point3D ret = null;
            Point3D min = new Point3D() { X = double.MaxValue, Y = double.MaxValue, Z = double.MaxValue };
            Point3D max = new Point3D() { X = double.MinValue, Y = double.MinValue, Z = double.MinValue };
            foreach (AtomDescription atom in Atoms)
            {
                if (atom.X < min.X) { min.X = atom.X; }
                if (atom.Y < min.Y) { min.Y = atom.Y; }
                if (atom.Z < min.Z) { min.Z = atom.Z; }

                if (atom.X > max.X) { max.X = atom.X; }
                if (atom.Y > max.Y) { max.Y = atom.Y; }
                if (atom.Z > max.Z) { max.Z = atom.Z; }

            }
            //relative center
            ret = new Point3D() { X = (max.X - min.X) / 2.0, Y = (max.Y - min.Y) / 2.0 , Z = (max.Z - min.Z) / 2.0 };
            //set absolute center
            ret.X += min.X;
            ret.Y += min.Y;
            ret.Z += min.Z;
            return ret;
        }

        /// <summary>
        /// Gets the bounding box of a molecule
        /// </summary>
        /// <returns>System.ValueTuple&lt;Point3D, Point3D&gt;.</returns>
        public (Point3D Min, Point3D Max) GetBoundingBox()
        {
            Point3D ret = null;
            Point3D min = new Point3D() { X = double.MaxValue, Y = double.MaxValue, Z = double.MaxValue };
            Point3D max = new Point3D() { X = double.MinValue, Y = double.MinValue, Z = double.MinValue };
            foreach (AtomDescription atom in Atoms)
            {
                if (atom.X < min.X) { min.X = atom.X; }
                if (atom.Y < min.Y) { min.Y = atom.Y; }
                if (atom.Z < min.Z) { min.Z = atom.Z; }

                if (atom.X > max.X) { max.X = atom.X; }
                if (atom.Y > max.Y) { max.Y = atom.Y; }
                if (atom.Z > max.Z) { max.Z = atom.Z; }

            }

            return (min, max);
        }

        /// <summary>
        /// Moves the molecule center to zero.
        /// </summary>
        public void MoveCenterToZero()
        {
            Point3D center= GetCenter();
            for (int i = 0; i < Atoms.Count; i++)
            {
                AtomDescription atom = Atoms[i];
                atom.X -= center.X;
                atom.Y -= center.Y;
                atom.Z -= center.Z;
            }
        }
    }
}
