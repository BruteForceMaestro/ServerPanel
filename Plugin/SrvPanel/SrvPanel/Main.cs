using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using MEC;

namespace SrvPanel
{
    public class Main : Plugin<Config>
    {
        EventHandlers handlers;
        CoroutineHandle handle;
        public override void OnEnabled()
        {
            handlers = new EventHandlers();
            Player.Verified += handlers.OnPlayerJoined;
            Player.Left += handlers.OnPlayerLeft;
            handle = Timing.RunCoroutine(API.DataLoop());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Verified += handlers.OnPlayerJoined;
            Player.Left += handlers.OnPlayerLeft;
            Timing.KillCoroutines(handle);
            handlers = null;
            base.OnDisabled();
        }
    }
}