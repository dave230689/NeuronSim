using NeuronSim.Domain.Connections;
using NeuronSim.Domain.Map;
using NeuronSim.Domain.Neurons;
using System;

namespace NeuronSim.Engine
{
    public class MapGenerator
    {
        private Random rnd = new Random();
        private Map map;
        public Map Generate(int numberOfNeurons)
        {
            map = Map.Get();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                map.AddNeuron(CreateNeuron());
            }

            CreateConnections(5);

            return map;
        }

        private ANeuron CreateNeuron()
        {
            return new SimpleNeuron();
        }

        private void CreateConnections(int averageConnectionNumber)
        {
            foreach (var neuron in map.GetNeurons())
            {
                int NeuronNumberOfConnections = rnd.Next(2 * averageConnectionNumber + 1);

                for (int i = 0; i < NeuronNumberOfConnections; i++)
                {
                    var endNeuron = ExtractEndNeuron(neuron);
                    map.AddConnection(new Connection(neuron, endNeuron));
                }
            }
        }

        private ANeuron ExtractEndNeuron(ANeuron startNeuron)
        {
            var endNeuronPosition = rnd.Next(map.GetNeurons().Count);

            ANeuron extractedEndNeuron = null;
            while (true)
            {
                extractedEndNeuron = map.GetNeurons().ToArray()[endNeuronPosition];
                endNeuronPosition = rnd.Next(map.GetNeurons().Count);
                if (!extractedEndNeuron.Equals(startNeuron) && !map.ExistsConnection(startNeuron, extractedEndNeuron))
                    return extractedEndNeuron;
            }

        }
    }
}
