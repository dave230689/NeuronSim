using NeuronSim.Engine;
using NUnit.Framework;

namespace NeuronSim.Tests.Engine
{
    [TestFixture]
    class MapGeneratorTests
    {
        private MapGenerator _sut;

        [SetUp]
        public void Init()
        {
            _sut = new MapGenerator();
        }

        [Test]
        public void Generate_ReturnsMapContainingXNumbersOfNeurons()
        {
            var numberOfNeurons = 10;

            var result = _sut.Generate(numberOfNeurons);

            Assert.IsNotNull(result);
            Assert.AreEqual(numberOfNeurons, result.GetNeurons().Count);
        }
    }
}
