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

            // Modern style:
            Assert.That(actualX, Is.EqualTo(0.0));
            Assert.That(actualY, Is.EqualTo(-0.1550));
            Assert.That(actualZ, Is.EqualTo(0.0));
        }

    }
}
