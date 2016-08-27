using System;

namespace NeuronSim.Domain.Messages
{
    abstract public class ASignal
    {
        protected Guid Id;
        protected int Energy;

        public ASignal(int energy)
        {
            Id = Guid.NewGuid();
            Energy = energy;    
        }

        public Guid GetId()
        {
            return Id;
        }

        public int GetEnergy()
        {
            return Energy;
        }

        public void CreateSignal(int energy)
        {
            Id = Guid.NewGuid();
            Energy = energy;
        }
    }
}
