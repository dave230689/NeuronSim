using NeuronSim.Domain.Neurons;

namespace NeuronSim.Domain.Connections
{
    public class Connection
    {
        private ANeuron StartNeuron;
        private ANeuron EndNeuron;


        public Connection(ANeuron startNeuron, ANeuron endNeuron)
        {
            StartNeuron = startNeuron;
            EndNeuron = endNeuron;
        }

        public ANeuron GetStartNeuron()
        {
            return StartNeuron;
        }

        public ANeuron GetEndNeuron()
        {
            return EndNeuron;
        }
    }
}
