using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SrvPanel
{
    public class Config : IConfig
    {
        [Description("Indicates if plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
    }
}