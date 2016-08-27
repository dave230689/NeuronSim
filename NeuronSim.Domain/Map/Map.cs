using NeuronSim.Domain.Neurons;
using NeuronSim.Domain.Connections;
using System;
using System.Collections.Generic;

namespace NeuronSim.Domain.Map
{
    public class Map
    {
        private static Map map;
        private List<ANeuron> _neurons = new List<ANeuron>();
        private List<Connection> _connections = new List<Connection>();

        public Map()
        {
        }

        public static Map Get()
        {
            if (map == null)
            {
                map = new Map();
            }

            return map;
        }

        public List<ANeuron> GetNeurons()
        {
            return _neurons;
        }

        public List<Connection> GetConnections()
        {
            return _connections;
        }

        public void AddNeuron(ANeuron neuron)
        {
            _neurons.Add(neuron);
        }

        public void AddConnection(Connection connection)
        {
            _connections.Add(connection);
        }

        public bool ExistsConnection(ANeuron startNeuron, ANeuron endNeuron)
        {
            foreach(var connection in _connections)
            {
                if (connection.GetStartNeuron().Equals(startNeuron) && connection.GetEndNeuron().Equals(endNeuron))
                    return true;
            }

            return false;
        }

        //Visualizzazione in console
        public void PrintToConsole()
        {
            Console.WriteLine("**** NeuronSIM - Map Visualization ****\n\n");

            Console.WriteLine("CONNECTIONS:\n");
            var neuronNumber = 0;
            foreach(var neuron in _neurons)
            {
                Console.WriteLine(string.Format("{0,-20} {1, -20}", $"Neuron-{neuronNumber++} : ",  $"{ neuron.GetId()}"));
            }

            Console.WriteLine();
            Console.WriteLine("CONNECTION:\n");

            var connectionNumber = 0;
            foreach(var connection in _connections)
            {
                Console.WriteLine(string.Format("{0,-20} {1, -20}", $"Connection-{connectionNumber++} : ", $"{ connection.GetStartNeuron().GetId()} --> {connection.GetEndNeuron().GetId()}"));
            }
            Console.ReadKey();
        }
    }
}
