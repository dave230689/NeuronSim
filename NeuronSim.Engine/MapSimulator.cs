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
            foreach (var neuron in NeuronsUnderSimulation)
            {
                SignalGenerator.GenerateSignals();
                ElaborationPhase();
                PropagationPhase();

                Thread.Sleep(SimulationStepInterval);
            }    
        }

        private void ElaborationPhase(ANeuron neuron)
        {
            neuro.n
        }

        private void PropagationPhase(ANeuron neuron)
        {
            throw new NotImplementedException();
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

            while(neuronsExtracted < numberOfNeuronsToExtract)
            {
                result.Add(neurons.ToArray()[rnd.Next(neurons.Count)]);
                neuronsExtracted++;
            }

            return result;
        }
    }
}
