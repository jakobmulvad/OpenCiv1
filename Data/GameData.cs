﻿using OpenCiv1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace OpenCiv1.Data
{
	public class GameData
	{
		public short Year = 0;
		public ushort RandomSeed = 0;
		public ushort DifficultyLevel = 0;
		public ushort Players = 0;
		public short PlayerFlags = 0;
		public short CivilizationIdentityFlags;
		public short ActiveCivilizationFlags = 0;

		public ushort GameTurnCount = 0;
		public short PeaceTurnCount;
		public short AIOpponentCount;
		public short NextAnthologyTurn;

		public Civilization[] Civilizations = new Civilization[8];
		public short PalaceLevel;
		public short[] PalaceData1 = new short[24];
		public short[] PalaceData2 = new short[24];

		public short[] PerContinentSizeAndPerOceanSize = new short[128];
		public short[] PerContinentCityBuildSitesCount = new short[16];
		public byte[] ScoreGraphData = new byte[1200];
		public byte[] PeaceGraphData = new byte[1200];

		public City[] aCities = new City[128];
		public string[,] CityName = new string[16, 16];
		public sbyte[,] CityXPosition = new sbyte[16, 16];
		public sbyte[,] CityYPosition = new sbyte[16, 16];

		public short WonderCount;
		public short[] WonderCityID = new short[21];

		public ushort[] TechnologyFirstDiscoveredBy = new ushort[72];
		public short MaximumTechnologyCount;
		public short PlayerFutureTechnology;

		public UnitDefinition[] aUnitDefinitions = new UnitDefinition[28];

		public byte[] MapVisibility = new byte[4000];

		public short PollutedSquareCount;
		public short PollutionEffectLevel;
		public short GlobalWarmingCount;

		public ushort ReplayDataLength;
		public byte[] ReplayData = new byte[4096];

		public byte[] LandPathfinding = new byte[260];

		public short GameSettingsFlags;
		public short DebugFlags;
		
		public short SpaceshipFlags;
		public short PlayerSpaceshipSuccessRate;
		public short AISpaceshipSuccessRate;
		
		public GameData() { }
	}
}
