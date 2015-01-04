﻿using System;
using System.Collections.Generic;

using Nini.Config;
using Mono.Addins;

using OpenSim.Framework.Servers.HttpServer;

namespace Diva.Interfaces
{
    [TypeExtensionPoint(Path = "/Diva/Wifi/Addon", NodeName = "WifiAddon")]
    public interface IWifiAddon
    {
        string Name
        {
            get;
        }

        void Initialize(IConfigSource config, string configName, IHttpServer server, IWifiApp app);
        string GetContent(IEnvironment env);
    }

    public struct WifiAddon
    {
        public IWifiAddon Addon;
        public string MenuAnchor;
        public string Path;
    }

}
