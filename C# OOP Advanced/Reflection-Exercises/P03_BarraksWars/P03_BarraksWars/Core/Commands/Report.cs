using _03BarracksFactory.Contracts;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.Commands
{
    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data) 
            : base(data)
        {

        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
