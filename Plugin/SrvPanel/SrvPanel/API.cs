using YamlDotNet.Serialization;
using System.Collections.Generic;
using MEC;
using Exiled.API.Features;
using System.IO;

namespace SrvPanel
{
    static class API
    {
        public static IEnumerator<float> DataLoop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(5);
                SerializeData();
            }
        }
        public static void SerializeData()
        {
            List<SerializablePlayer> data = new List<SerializablePlayer>();
            foreach (Player ply in Player.List)
            {
                data.Add(
                    new SerializablePlayer()
                    {
                        UserId = ply.UserId,
                        Nickname = ply.Nickname,
                    });
            }
            var serializer = new SerializerBuilder().Build();
            File.WriteAllText(Path.Combine(Paths.Configs, "ServerPanelData.yaml"), serializer.Serialize(data));
        }
    }
}
