using NeuronSim.Domain.Neurons;
using System.Collections.Generic;

namespace NeuronSim.Engine
{
    class SignalGenerator
    {
        private List<ANeuron> SignalStartNeurons;

        public SignalGenerator(List<ANeuron> signalStartNeurons)
        {
            SignalStartNeurons = signalStartNeurons; 
        }

        public void GenerateSignals()
        {
            foreach (var neuron in SignalStartNeurons)
            {
                neuron.IncreaseBufferEnergy(11);
            }
        }
    }
}
