using NeuronSim.Domain.Map;
using NeuronSim.Domain.Neurons;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NeuronSim.Engine
{
    public class MapSimulator
    {
        private const int SimulationStepInterval = 1000;
        private Map NeuroMap;
        private SignalGenerator SignalGenerator;
        private List<ANeuron> NeuronsUnderSimulation;
        private List<ANeuron> NeuronsGeneratingSignals;

        public MapSimulator(Map neuroMap)
        {
            NeuroMap = neuroMap;
        }

        public void Init()
        {
            NeuronsGeneratingSignals = ExtractNeurons(3, NeuroMap.GetNeurons());
            NeuronsUnderSimulation.AddRange(NeuronsGeneratingSignals);
            SignalGenerator = new SignalGenerator(NeuronsGeneratingSignals);
        }

        public void Start()
        {
            while (true)
            {
                SignalGenerator.GenerateSignals();
                foreach (var neuron in NeuronsUnderSimulation)
                {
                    ElaborationPhase(neuron);
                    PropagationPhase(neuron);
                }

                Thread.Sleep(SimulationStepInterval);
            }
        }

        private void ElaborationPhase(ANeuron neuron)
        {
            neuron.ConsumeSignals();
            neuron.ConsumeEnergy();
        }

        private void PropagationPhase(ANeuron neuron)
        {
            var connectedNeurons = NeuroMap.GetConnectedNeurons(neuron);
            if (neuron.IsBufferEnergyEnoughForPropagation(connectedNeurons.Count))
            {
                foreach (var connectedNeuron in connectedNeurons)
                {
                    NeuroMap.AddNeuron(connectedNeuron);
                }
            }
        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }

        private List<ANeuron> ExtractNeurons(int numberOfNeuronsToExtract, List<ANeuron> neurons)
        {
            var neuronsExtracted = 0;
            var result = new List<ANeuron>();
            Random rnd = new Random();

            while (neuronsExtracted < numberOfNeuronsToExtract)
            {
                result.Add(neurons.ToArray()[rnd.Next(neurons.Count)]);
                neuronsExtracted++;
            }

            return result;
        }
    }
}
