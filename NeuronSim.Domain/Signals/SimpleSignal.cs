using System;

namespace NeuronSim.Domain.Messages
{
    public class SimpleSignal : ASignal
    {
        private DateTime SignalCreationDate { get; set; }

        public SimpleSignal(int energy) : base(energy)
        {
            SignalCreationDate = DateTime.Now;
        }
    }
}
