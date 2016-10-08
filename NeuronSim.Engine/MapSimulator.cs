using NeuronSim.Domain.Map;
using NeuronSim.Domain.Messages;
using NeuronSim.Domain.Neurons;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NeuronSim.Engine
{
    public class MapSimulator
    {
        private const int SimulationStepInterval = 1000;
        private int SimulationStep = 0;
        private bool RunSimulation = false;
        private Map NeuroMap;
        private SignalGenerator SignalGenerator;
        private List<ANeuron> NeuronsUnderSimulation;
        private List<ANeuron> NeuronsGeneratingSignals;

        public MapSimulator(Map neuroMap)
        {
            NeuroMap = neuroMap;
            NeuronsUnderSimulation = new List<ANeuron>();
            NeuronsGeneratingSignals = new List<ANeuron>();
        }

        public void Init()
        {
            NeuronsGeneratingSignals = ExtractNeurons(3, NeuroMap.GetNeurons());
            NeuronsUnderSimulation.AddRange(NeuronsGeneratingSignals);
            SignalGenerator = new SignalGenerator(NeuronsGeneratingSignals);
            SimulationStep = 0;
        }

        public void Start()
        {
            RunSimulation = true;
            var neuronsToAdd = new List<ANeuron>();

            while (RunSimulation)
            {
                SignalGenerator.GenerateSignals();
                foreach (var neuron in NeuronsUnderSimulation)
                {
                    ElaborationPhase(neuron);
                    neuronsToAdd = PropagationPhase(neuron);
                }

                foreach (var newNeuron in neuronsToAdd)
                {
                    if (!NeuronsUnderSimulation.Contains(newNeuron))
                    {
                        NeuronsUnderSimulation.Add(newNeuron);
                    }
                }

                Console.Clear();
                Console.WriteLine($"PROCESSING STEP {SimulationStep++}");
                foreach(var neuron in NeuronsUnderSimulation)
                {
                    var actualEnergyBuffer = string.Empty;
                    for(int i=0; i<neuron.GetEnergyBuffer(); i++)
                    {
                        actualEnergyBuffer += "|";
                    }

                    Console.WriteLine($"Neuron {neuron.GetId()}: {actualEnergyBuffer}");
                }

                Thread.Sleep(SimulationStepInterval);
            }
        }

        private void ElaborationPhase(ANeuron neuron)
        {
            neuron.ConsumeSignals();
            neuron.ConsumeEnergy();
        }

        private List<ANeuron> PropagationPhase(ANeuron neuron)
        {
            var result = new List<ANeuron>();
            var connectedNeurons = NeuroMap.GetConnectedNeurons(neuron);
            if (neuron.IsBufferEnergyEnoughForPropagation(connectedNeurons.Count))
            {
                foreach (var connectedNeuron in connectedNeurons)
                {
                    connectedNeuron.SendSignal(new SimpleSignal(1));
                    result.Add(connectedNeuron);
                }
            }

            return result;
        }

        public void Pause()
        {
            RunSimulation = false;
        }

        public void Stop()
        {
            RunSimulation = false;
            NeuronsUnderSimulation.Clear();
            NeuronsGeneratingSignals.Clear();
            SignalGenerator = null;
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
