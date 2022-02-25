using Utf8Json;
using System.Collections.Generic;
using MEC;
using Exiled.API.Features;
using System.IO;
using System;

namespace SrvPanel
{
    static class API
    {
        static readonly string path = Path.Combine(Paths.Configs, "ServerPanelData.json");
        static public SerializableData Data { get; set; } = new SerializableData();
        static public IEnumerator<float> DataLoop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(5);
                Log.Debug("wake up");
                SerializeData();
            }
        }
        static void SerializeData()
        {
            try
            {
                Log.Debug(JsonSerializer.ToJsonString(Data));
                using (FileStream fs = File.Create(path))
                {
                    JsonSerializer.Serialize(fs, Data);
                }
            }
            catch (Exception e)
            {
                Log.Debug(e);
            }
        }
    }
}
