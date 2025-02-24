using Cradle.Shared.Systems;
using System.Timers;

namespace Cradle.Shared.Models
{
    public delegate Task PlayerUpdated();

    public interface IPlayerView
    {
        string Name { get; }
        List<Core> Cores { get; }
        event PlayerUpdated OnPlayerUpdated;
    }

    public class Player : IPlayerView
    {
        public event PlayerUpdated OnPlayerUpdated;

        public string Name { get; private set; }
        public List<Core> Cores { get; private set; }

        public Player(string name)
        {
            Name = name;
            Cores = [];

            ICore core = new Core();

            core.OnMadraCycled += PlayerUpdated;

            Cores.Add(core as Core);
        }

        public async Task PlayerUpdated()
        {
            OnPlayerUpdated?.Invoke();
        }
    }
}
