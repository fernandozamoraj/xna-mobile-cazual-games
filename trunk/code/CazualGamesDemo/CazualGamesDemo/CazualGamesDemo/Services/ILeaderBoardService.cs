using System.Collections.Generic;
using CazualGamesDemo.Screens;

namespace CazualGamesDemo.Services
{
    public interface ILeaderBoardService
    {
        IList<Leader> GetAll();
    }
}