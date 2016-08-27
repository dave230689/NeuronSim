using System;

namespace NeuronSim.Domain.Messages
{
    public class SimpleSignal : ASignal
    {
        DateTime SignalCreationDate { get; set; }
    }
}
