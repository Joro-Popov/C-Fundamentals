using System;
using System.Collections.Generic;
using System.Text;

namespace EventImplementation
{
    public class Dispatcher : IDispatcher
    {
        private string name;
        public event EventHandler<NameChangeEventArgs> NameChange;

        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);

        }
    }
}
