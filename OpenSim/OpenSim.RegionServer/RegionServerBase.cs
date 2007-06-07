/*
* Copyright (c) Contributors, http://www.openmetaverse.org/
* See CONTRIBUTORS.TXT for a full list of copyright holders.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither the name of the OpenSim Project nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
* 
*/
using System;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using libsecondlife;
using libsecondlife.Packets;
using OpenSim.RegionServer.Simulator;
using OpenSim.Terrain;
using OpenSim.Framework.Interfaces;
using OpenSim.Framework.Types;
using OpenSim.UserServer;
using OpenSim.RegionServer.Assets;
using OpenSim.RegionServer.CAPS;
using OpenSim.Framework.Console;
using OpenSim.Physics.Manager;
using Nwc.XmlRpc;
using OpenSim.Servers;
using OpenSim.GenericConfig;

namespace OpenSim.RegionServer
{
    public class RegionServerBase
    {
        protected IGenericConfig localConfig;
        protected PhysicsManager physManager;
        protected Grid GridServers;
        protected AssetCache AssetCache;
        protected InventoryCache InventoryCache;
        protected Dictionary<EndPoint, uint> clientCircuits = new Dictionary<EndPoint, uint>();
        protected DateTime startuptime;
        protected RegionInfo regionData;

        protected System.Timers.Timer m_heartbeatTimer = new System.Timers.Timer();
        public string m_physicsEngine;
        public bool m_sandbox = false;
        public bool m_loginserver;
        public bool user_accounts = false;
        public bool gridLocalAsset = false;
        protected bool configFileSetup = false;
        public string m_config;

        protected UDPServer m_udpServer;
        protected BaseHttpServer httpServer;
        protected AuthenticateSessionsBase AuthenticateSessionsHandler;

        protected ConsoleBase m_console;

        public RegionServerBase()
        {

        }

        public RegionServerBase(bool sandBoxMode, bool startLoginServer, string physicsEngine, bool useConfigFile, bool silent, string configFile)
        {
            this.configFileSetup = useConfigFile;
            m_sandbox = sandBoxMode;
            m_loginserver = startLoginServer;
            m_physicsEngine = physicsEngine;
            m_config = configFile;
        }

        protected World m_localWorld;
        public World LocalWorld
        {
            get { return m_localWorld; }
        }

        /// <summary>
        /// Performs initialisation of the world, such as loading configuration from disk.
        /// </summary>
        public virtual void StartUp()
        {
        }

        protected virtual void SetupLocalGridServers()
        {
        }

        protected virtual void SetupRemoteGridServers()
        {

        }

        protected virtual void SetupLocalWorld()
        {
        }

        protected virtual void SetupHttpListener()
        {
        }

        protected virtual void ConnectToRemoteGridServer()
        {

        }
    }
}
