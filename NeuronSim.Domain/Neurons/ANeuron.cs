using NeuronSim.Domain.Messages;
using System;

namespace NeuronSim.Domain.Neurons
{
    abstract public class ANeuron
    {
        protected Guid Id;
        protected int EnergyBuffer;

        public Guid GetId()
        {
            return Id;
        }

        public int GetEnergyBuffer()
        {
            return EnergyBuffer;
        }

        abstract public void ConsumeSignals();

        abstract public void IncreaseBufferEnergy(int messageEnergy);

        abstract public void DecreaseBufferEnergy(int messageEnergy);

        abstract public void ConsumeEnergy();

        abstract public void SendSignal(ASignal signal);

        abstract public bool IsBufferEnergyEnoughForPropagation(int numberOfConnectedNeurons);
    }
}
