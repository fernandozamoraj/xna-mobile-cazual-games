using System.Collections.Generic;

namespace CazualGamesDemo.Services
{
    public class LeaderBoardService : ILeaderBoardService
    {
        public IList<Leader> GetAll()
        {
            return new List<Leader>
                       {
                           new Leader {Name = "Joe", Score = 1024},
                           new Leader {Name = "Mary", Score = 512},
                           new Leader {Name = "Travis", Score = 256},
                           new Leader {Name = "Jon", Score = 128},
                           new Leader {Name = "John", Score = 64},
                           new Leader {Name = "Sergio", Score = 32}
                       };
        }
    }
}