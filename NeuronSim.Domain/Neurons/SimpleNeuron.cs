using NeuronSim.Domain.Messages;
using System;

namespace NeuronSim.Domain.Neurons
{
    public class SimpleNeuron : ANeuron
    {
        public SimpleNeuron()
        {
            Id = Guid.NewGuid();
        }

        public override void ConsumeMessage(ASignal message)
        {
            IncreaseBufferEnergy(message.GetEnergy());
        }

        public override void IncreaseBufferEnergy(int messageEnergy)
        {
            EnergyBuffer = EnergyBuffer + messageEnergy;
        }

        public override void DecreaseBufferEnergy(int messageEnergy)
        {
            EnergyBuffer = EnergyBuffer - messageEnergy;
            if (EnergyBuffer < 0)
                EnergyBuffer = 0;
        }
    }
}
