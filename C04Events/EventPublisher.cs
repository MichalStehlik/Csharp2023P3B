using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04Events
{
    internal class EventPublisher
    {
        private int _value;

        public EventPublisher(int value)
        {
            _value = value;
        }

        public int Value 
        { 
            get 
            { 
                return _value; 
            }
            set
            {
                _value = value;
                ValueHasChanged?.Invoke(this, new ExampleEventArgs(value));
            }
        }

        public event ExampleEventHandler ValueHasChanged;
    }
}
