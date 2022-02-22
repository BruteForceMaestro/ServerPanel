using Exiled.API.Features;
using MEC;

namespace SrvPanel
{
    public class Main : Plugin<Config>
    {
        public override void OnEnabled()
        {
            base.OnEnabled();
            Timing.RunCoroutine(API.DataLoop());
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}