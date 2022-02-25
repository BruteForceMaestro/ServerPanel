using Exiled.Events.EventArgs;
using System;

namespace SrvPanel
{
    internal class EventHandlers
    {
        public void OnPlayerJoined(VerifiedEventArgs ev)
        {
            if (API.Data.Ply.TryGetValue(ev.Player.UserId, out _))
            {
                return;
            }
            API.Data.Ply[ev.Player.UserId] = new SerializablePlayer()
            {
                Nickname = ev.Player.Nickname,
                JoinTime = DateTime.Now,
            };
        }
        public void OnPlayerLeft(LeftEventArgs ev)
        {
            API.Data.Ply.Remove(ev.Player.UserId);
        }
    }
}
