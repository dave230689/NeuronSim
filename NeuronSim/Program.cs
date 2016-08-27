using NeuronSim.Engine;

namespace NeuronSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfNeurons = 100;
            var mapGenerator = new MapGenerator();

            var map = mapGenerator.Generate(numberOfNeurons);
            var mapSimulator = new MapSimulator(map);
            mapSimulator.Init();
            mapSimulator.Start();

            map.PrintToConsole();
        }
    }
}
