using NeuronSim.Domain.Messages;
using System;
using System.Collections.Generic;

namespace NeuronSim.Domain.Neurons
{
    public class SimpleNeuron : ANeuron
    {
        private List<ASignal> SignalsQueue = new List<ASignal>();

        public SimpleNeuron()
        {
            Id = Guid.NewGuid();
        }

        public override void ConsumeSignals(ASignal message)
        {
            foreach(var signal in SignalsQueue)
            {
                IncreaseBufferEnergy(signal.GetEnergy());
            }

            SignalsQueue.Clear();
        }

        public override void IncreaseBufferEnergy(int signalEnergy)
        {
            EnergyBuffer = EnergyBuffer + signalEnergy;
        }

        public override void DecreaseBufferEnergy(int signalEnergy)
        {
            EnergyBuffer = EnergyBuffer - signalEnergy;
            if (EnergyBuffer < 0)
                EnergyBuffer = 0;
        }

        public override void SendSignal(ASignal signal)
        {
            SignalsQueue.Add(signal);
        }
    }
}
