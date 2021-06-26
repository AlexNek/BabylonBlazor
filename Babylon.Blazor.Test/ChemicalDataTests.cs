using System;

using Babylon.Blazor.Chemical;

using NUnit.Framework;

namespace Babylon.Blazor.Test
{
    public class ChemicalDataTests
    {
        [Test]
        public void MoveToZeroTest()
        {
            ChemicalData panelData = new ChemicalData();
            panelData.Atoms.Add(new AtomDescription() { Name = "O", X = 2.5369, Y = -0.1550, Z = 0.0000 });
            panelData.Atoms.Add(new AtomDescription() { Name = "H", X = 3.0739, Y = 0.1550, Z = 0.0000 });
            panelData.Atoms.Add(new AtomDescription() { Name = "H", X = 2.0000, Y = 0.1550, Z = 0.0000 });
            panelData.Bonds.Add(new BondDescription(1, 2, BondDescription.BondType.Single));
            panelData.Bonds.Add(new BondDescription(1, 3, BondDescription.BondType.Single));
            panelData.MoveCenterToZero();

            AtomDescription atom = panelData.Atoms[0];
            double actualX = Math.Round(atom.X, 4, MidpointRounding.AwayFromZero);
            double actualY = Math.Round(atom.Y, 4, MidpointRounding.AwayFromZero);
            double actualZ = Math.Round(atom.Z, 4, MidpointRounding.AwayFromZero);
            Assert.AreEqual(0, actualX, $"X expected 0 but was {actualY}");
            Assert.AreEqual(-0.155, actualY, $"Y expected -0.155 but was {actualY}");
            Assert.AreEqual(0, actualZ, $"Z expected 0 but was {actualY}");
        }

    }
}
