using NeuronSim.Domain.Messages;
using System;

namespace NeuronSim.Domain.Neurons
{
    abstract public class ANeuron
    {
        protected Guid Id;
        protected int ActivationThreshold;
        protected int EnergyBuffer;

        public Guid GetId()
        {
            return Id;
        }

        public int GetActivationTreshhold()
        {
            return ActivationThreshold;
        }

        public int GetEnergyBuffer()
        {
            return EnergyBuffer;
        }

        abstract public void ConsumeSignals(ASignal message);

        abstract public void IncreaseBufferEnergy(int messageEnergy);

        abstract public void DecreaseBufferEnergy(int messageEnergy);

        abstract public void SendSignal(ASignal signal);
    }
}
