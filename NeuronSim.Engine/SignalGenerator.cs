using NeuronSim.Domain.Messages;
using NeuronSim.Domain.Neurons;
using System.Collections.Generic;

namespace NeuronSim.Engine
{
    class SignalGenerator
    {
        private List<ANeuron> SignalStartNeurons;
        private const int GeneratedSignalEnergy = 2;

        public SignalGenerator(List<ANeuron> signalStartNeurons)
        {
            SignalStartNeurons = signalStartNeurons; 
        }

        public void GenerateSignals()
        {
            foreach (var neuron in SignalStartNeurons)
            {
                var signal = new SimpleSignal(GeneratedSignalEnergy);
                neuron.SendSignal(signal);
            }
        }
    }
}
