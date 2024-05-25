using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_1d12
	{
		private Game oParent;
		private CPU oCPU;

		// Local variables used exclusively inside this section

		private ushort Var_2494 = 0;
		private ushort Var_2496 = 0;

		// 0x652e - after this offset the default values are set to 0

		private short Var_653e_CityID = 0;
		private ushort Var_6540 = 0;
		private ushort Var_6542 = 0;
		private ushort Var_6546 = 0;
		private short Var_6548_PlayerID = 0;
		private ushort Var_6b30 = 0;
		private ushort Var_70e8 = 0;
		private ushort Var_deb6 = 0;

		public Segment_1d12(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_1d12_000a(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_000a({xPos}, {yPos})");

			// function body
			for (int i = 0; i < 21; i++)
			{
				if (this.oParent.CityOffsets[i].X == xPos && this.oParent.CityOffsets[i].Y == yPos)
				{
					this.oCPU.AX.Word = (ushort)i;
					goto L0040;
				}
			}

			this.oCPU.AX.Word = 0xffff;

		L0040:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_000a");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="flag"></param>
		public void F0_1d12_0045(short cityID, short flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_0045({cityID}, {flag})");

			// function body
			short[] Arr_3e = new short[21];
			short[] Arr_74 = new short[18];
			short[,] Arr_a6 = new short[5, 5];
			City city = this.oParent.GameState.Cities[cityID];

			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10c);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			if (city.StatusFlag == 0xff)
				goto L6927;

			this.Var_2496 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfe), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca), 0);

			// Instruction address 0x1d12:0x007e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 0x0);

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					Arr_a6[i, j] = 0;
				}
			}

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), (short)city.Position.X);
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), (short)city.Position.Y);

			this.Var_653e_CityID = cityID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2), 0x7);

			if ((city.BuildingFlags0 & 0x1) != 0)
			{
				this.oCPU.AX.Word = 0x0;
			}
			else
			{
				this.oCPU.AX.Word = 0x20;
			}

			this.Var_6b30 = this.oCPU.AX.Word;

			if (city.ShieldsCount > 999 || city.ShieldsCount < 0)
			{
				city.ShieldsCount = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);
			goto L015a;

		L0157:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

		L015a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x80);
			if (this.oCPU.Flags.L) goto L0164;
			goto L02f7;

		L0164:
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L0176;
			goto L0157;

		L0176:
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0157;
			goto L0184;

		L0184:
			// Instruction address 0x1d12:0x01a2, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L01bb;
			goto L01cd;

		L01bb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0)), 0x0);
			if (this.oCPU.Flags.NE) goto L01c5;
			goto L01cd;

		L01c5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2), this.oCPU.AX.Word);

		L01cd:			
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID !=
				city.PlayerID)
			goto L0211;

			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.NE) goto L01fe;
			goto L0211;

		L01fe:
			this.oCPU.AX.Word = this.Var_6b30;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L020a;
			goto L0211;

		L020a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0));
			this.Var_6b30 = this.oCPU.AX.Word;

		L0211:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0)), 0x5);
			if (this.oCPU.Flags.LE) goto L021b;
			goto L0157;

		L021b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0228;

		L0224:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0228:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x14);
			if (this.oCPU.Flags.LE) goto L0232;
			goto L0157;

		L0232:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word &= this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].WorkerFlags0;
			this.oCPU.BX.Word &= this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].WorkerFlags1;

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L025c;
			goto L0266;

		L025c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x14);
			if (this.oCPU.Flags.E) goto L0266;
			goto L0224;

		L0266:
			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)));
			
			// Instruction address 0x1d12:0x02a7, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.LE) goto L02b7;
			goto L0224;

		L02b7:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));
			
			// Instruction address 0x1d12:0x02c0, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.LE) goto L02d0;
			goto L0224;

		L02d0:
			Arr_a6[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)) + 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) + 2] = 1;

			goto L0224;

		L02f7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8e), 0x0);
			this.Var_6548_PlayerID = city.PlayerID;
			this.Var_6540 = 0x15;
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc2), this.oParent.Var_d4cc_XPos);
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd0), this.oParent.Var_d75e_YPos);

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType <= 1)
			{
				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0x2;
			}			

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);
			this.oParent.Var_b882 = 0;

			if ((city.BuildingFlags0 & 0x1000) != 0)
				goto L03c6;

			// Instruction address 0x1d12:0x035e, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Industrialization);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L036e;

			goto L0372;

		L036e:
			this.oParent.Var_b882++;

		L0372:
			// Instruction address 0x1d12:0x037a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Automobile);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L038a;

			goto L038e;

		L038a:
			this.oParent.Var_b882++;

		L038e:
			// Instruction address 0x1d12:0x0396, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.MassProduction);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
			{
				this.oParent.Var_b882++;
			}

			// Instruction address 0x1d12:0x03b2, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Plastics);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
			{
				this.oParent.Var_b882++;
			}

		L03c6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), 0xa);

			this.oCPU.AX.Word = city.WorkerFlags0;
			this.oCPU.DX.Word = city.WorkerFlags1;
			this.oCPU.CX.Low = 26;
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) >> this.oCPU.CX.Low);

			this.oParent.Var_e8b8 = this.oCPU.AX.Word;
			
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L045f;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Year >= 0 &&
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking == 7 &&
				this.oParent.GameState.DifficultyLevel > 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a),
					this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), 0x2));
			}

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0431;
			goto L045f;

		L0431:
			if ((city.StatusFlag & 0x1) == 0)
			{
				this.oParent.Var_e8b8 = 0;
			}
			else
			{
				city.WorkerFlags0 = 0;
				city.WorkerFlags1 = 0;
			}

		L045f:
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), (short)city.Position.X);
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), (short)city.Position.Y);

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L048f;
			goto L0701;

		L048f:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L0497;
			goto L0701;

		L0497:
			// Instruction address 0x1d12:0x049a, size: 5
			this.oParent.Segment_1866.F0_1866_0006(cityID);

			// Instruction address 0x1d12:0x04ba, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x1d12:0x04d2, size: 5
			F0_1d12_70cb(2, 1, 208, 21);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x1);
			goto L04ed;

		L04e9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L04ed:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));
			if (this.oCPU.Flags.GE) goto L0503;
			goto L050e;

		L0503:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));
			goto L04e9;

		L050e:
			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x051f, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x052b, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x1d12:0x053b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (Pop:");

			// Instruction address 0x1d12:0x0547, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0337(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));

			// Instruction address 0x1d12:0x0557, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			// Instruction address 0x1d12:0x056f, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 104, 2, 15);

			// Instruction address 0x1d12:0x0587, size: 5
			F0_1d12_70cb(127, 23, 208, 104);

			this.oCPU.AX.Word = (ushort)((short)city.Position.X);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x5);
			this.oParent.Var_d4cc_XPos = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)city.Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x3);
			this.oParent.Var_d75e_YPos = (short)this.oCPU.AX.Word;
			
			// Instruction address 0x1d12:0x05cd, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(city.Position.X,
				city.Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L05e2;

		L05de:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L05e2:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L05ee;
			goto L0701;

		L05ee:
			this.oCPU.AX.Word = (ushort)((short)(city.Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(city.Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L065c;

			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L05de;

		L065c:
			// Instruction address 0x1d12:0x0664, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xffff);
			if (this.oCPU.Flags.NE) goto L067a;
			goto L0699;

		L067a:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) == this.Var_6548_PlayerID)
				goto L0699;

			// Instruction address 0x1d12:0x068e, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			goto L05de;

		L0699:
			// Instruction address 0x1d12:0x06a1, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			if (Arr_a6[this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X + 2,
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y + 2] == 0)
				goto L06fe;

			// Instruction address 0x1d12:0x06f6, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)) - this.oParent.Var_d4cc_XPos) * 16 + 80,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)) - this.oParent.Var_d75e_YPos) * 16 + 8,
				15, 15, 12);

		L06fe:
			goto L05de;

		L0701:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L070c;
			goto L0965;

		L070c:
			city.StatusFlag &= 0x7f;

			if (city.FoodCount >= 0)
				goto L0881;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);

			goto L073e;

		L073a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L073e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x80);
			if (this.oCPU.Flags.GE)
				goto L0792;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID != 0)
				goto L073a;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].HomeCityID != cityID)
				goto L073a;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

		L0792:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1d12:0x07a6, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Food storage exhausted\nin ");

				// Instruction address 0x1d12:0x07b1, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) != 0xffff)
				{
					// Instruction address 0x1d12:0x07d1, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "!\nSettlers lost.\n");
				}
				else
				{
					// Instruction address 0x1d12:0x07d1, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "!\nFamine feared.\n");
				}

				// Instruction address 0x1d12:0x07dd, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				this.oParent.Overlay_21.F21_0000_0000(cityID);

				// Instruction address 0x1d12:0x07f4, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);
			}

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0806;
			goto L0819;

		L0806:
			// Instruction address 0x1d12:0x080e, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			
			goto L0863;

		L0819:
			city.ActualSize--;
			if (city.ActualSize>0)
				goto L0863;

			// Instruction address 0x1d12:0x0843, size: 5
			this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

			this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

			// Instruction address 0x1d12:0x085b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L6927;

		L0863:
			city.FoodCount = 0;

			// Instruction address 0x1d12:0x0879, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

		L0881:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)city.FoodCount);
			if (this.oCPU.Flags.LE) goto L089b;
			goto L0965;

		L089b:
			city.ActualSize++;
			
			this.oCPU.TESTWord(city.BuildingFlags0, 0x4);
			if (this.oCPU.Flags.NE) goto L08b9;
			goto L08cd;

		L08b9:
			this.oCPU.AX.Low = 0x5;
			this.oCPU.IMULByte(this.oCPU.AX, (byte)city.ActualSize);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			goto L08d0;

		L08cd:
			this.oCPU.AX.Word = 0x0;

		L08d0:
			city.FoodCount = (short)this.oCPU.AX.Word;

			this.oCPU.CMPByte((byte)city.ActualSize, 0xa);
			if (this.oCPU.Flags.G) goto L08e6;
			goto L0955;

		L08e6:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x100);
			if (this.oCPU.Flags.E) goto L08f9;
			goto L0955;

		L08f9:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x4);
			if (this.oCPU.Flags.NE) goto L0903;
			goto L0955;

		L0903:
			city.ActualSize--;

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L0955;

			this.oParent.Var_2f9e_Unknown = 0x4;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x0929, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x0939, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " requires an AQUEDUCT\nfor further growth.\n");

			// Instruction address 0x1d12:0x094d, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L0955:
			// Instruction address 0x1d12:0x095d, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

		L0965:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);

			this.Var_6546 = 0;
			this.oParent.Var_deb8 = 0;
			this.oParent.Var_d2f6 = 0;
			this.oParent.Var_e3c6 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);

			goto L0992;

		L098e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0992:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x2);
			if (this.oCPU.Flags.L) goto L099c;
			goto L09b9;

		L099c:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.CMPByte((byte)city.Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))], 0xff);
			if (this.oCPU.Flags.NE) goto L09b2;
			goto L09b6;

		L09b2:
			this.oParent.Var_deb8++;

		L09b6:
			goto L098e;

		L09b9:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
			if (this.oCPU.Flags.L) goto L09cf;
			goto L09e6;

		L09cf:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.CX.Word = this.oParent.Var_deb8;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oParent.Var_d2f6 = this.oCPU.CX.Word;

		L09e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L09f3;

		L09ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L09f3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x80);
			if (this.oCPU.Flags.L) goto L09fe;
			goto L0b4e;

		L09fe:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID == -1)
				goto L09ef;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].HomeCityID != cityID)
				goto L09ef;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID >= 26)
				goto L0b2b;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);

			this.oParent.Var_deb8++;

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
			if (this.oCPU.Flags.GE) goto L0a6f;

			this.oParent.Var_d2f6++;

			goto L0a8d;

		L0a6f:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType > 1 &&
				(this.oParent.GameState.DebugFlags & 2) != 0)
			{
				this.oParent.Var_d2f6++;
			}

		L0a8d:
			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID].AttackStrength == 0)
				goto L0b2b;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID].TerrainCategory == 1)
				goto L0b27;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.X ==
				city.Position.X)
				goto L0afe;

			goto L0b27;

		L0afe:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.Y ==
				city.Position.Y)
				goto L0b2b;

			L0b27:
			this.Var_6546++;

		L0b2b:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID == 0)
			{
				this.oParent.Var_e3c6++;
			}

			goto L09ef;

		L0b4e:
			this.Var_70e8 = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0b61;

		L0b5d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0b61:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0b6d;
			goto L0cae;

		L0b6d:
			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 0;

			this.oCPU.AX.Word = (ushort)((short)(city.Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(city.Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			if (this.Var_6548_PlayerID == 0)
				goto L0bec;

			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0be1;
			goto L0bec;

		L0be1:
			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 1;

		L0bec:
			// Instruction address 0x1d12:0x0bf4, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0c0a;
			goto L0c49;

		L0c0a:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) == this.Var_6548_PlayerID)
				goto L0c49;

			Arr_a6[this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X + 2,
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y + 2] = 1;

			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 1;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0c43;
			goto L0c49;

		L0c43:
			this.Var_70e8 = 0x1;

		L0c49:
			if (Arr_a6[this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X + 2,
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y + 2] == 0)
				goto L0c75;

			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 1;

		L0c75:
			if (Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] == 0)
				goto L0cab;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;			
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			city.WorkerFlags0 &= this.oCPU.CX.Word;
			city.WorkerFlags1 &= this.oCPU.BX.Word;

		L0cab:
			goto L0b5d;

		L0cae:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0cbb;

		L0cb7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0cbb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x4);
			if (this.oCPU.Flags.L) goto L0cc5;
			goto L0cd4;

		L0cc5:
			this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 0;

			goto L0cb7;

		L0cd4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee), 0);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE)
				goto L0d1b;

			if (((cityID + this.oParent.GameState.TurnCount) & 0x3) != 0)
				goto L0d1b;

			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE)
				goto L0d1b;

			this.oCPU.CMPWord(this.Var_70e8, 0x0);
			if (this.oCPU.Flags.E)
				goto L0e91;

		L0d1b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0d28;

		L0d24:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0d28:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0d34;
			goto L0d64;

		L0d34:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;			
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word &= city.WorkerFlags0;
			this.oCPU.BX.Word &= city.WorkerFlags1;

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L0d5e;
			goto L0d61;

		L0d5e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

		L0d61:
			goto L0d24;

		L0d64:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.GE) goto L0d6d;
			goto L0e07;

		L0d6d:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0d8b;

		L0d87:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0d8b:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0d97;
			goto L0e7a;

		L0d97:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.NE) goto L0da0;
			goto L0e01;

		L0da0:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word &= city.WorkerFlags0;
			this.oCPU.BX.Word &= city.WorkerFlags1;

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L0dca;
			goto L0e01;

		L0dca:
			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] = 1;

			// Instruction address 0x1d12:0x0ddf, size: 5
			F0_1d12_692d(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), flag);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec)), this.oCPU.DX.Word));

		L0e01:
			goto L0d87;

		L0e07:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0e12;
			goto L0e69;

		L0e12:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L0e69;

			// Instruction address 0x1d12:0x0e26, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Population decrease\nin ");

			// Instruction address 0x1d12:0x0e31, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x0e41, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_Unknown = 0x4;

			// Instruction address 0x1d12:0x0e5b, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oParent.Var_b1e8 = 0x1;

		L0e69:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);

		L0e7a:
			this.oCPU.AX.Word = this.oParent.Var_e8b8;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0e85;
			goto L1292;

		L0e85:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.E) goto L1292;

		L0e91:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.G) goto L0e9a;
			goto L0ec9;

		L0e9a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.E) goto L0ea3;
			goto L0ec9;

		L0ea3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);

			// Instruction address 0x1d12:0x0eb2, size: 5
			F0_1d12_692d(cityID, 20, flag);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee)), 0x0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec)), 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

		L0ec9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oParent.Var_70da_Arr[0]);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.Var_e3c6);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.LE) goto L0efa;
			goto L0f0c;

		L0efa:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x3);
			if (this.oCPU.Flags.L) goto L0f0c;
			goto L1088;

		L0f0c:
			this.oCPU.AX.Word = this.oParent.Var_e8b8;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0f17;
			goto L1088;

		L0f17:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0f21;
			goto L1088;

		L0f21:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xce), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L0f3f;

		L0f3b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L0f3f:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0f4b;
			goto L103e;

		L0f4b:
			if (Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] != 0)
				goto L103b;

			this.oCPU.AX.Word = (ushort)((short)(city.Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(city.Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x0f9e, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x0fb6, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 1);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x1);
			if (this.oCPU.Flags.E) goto L0fcd;
			goto L0fe4;

		L0fcd:
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[1], 0x0);
			if (this.oCPU.Flags.E) goto L0fd7;
			goto L0fe4;

		L0fd7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), 0x0);
			if (this.oCPU.Flags.E) goto L0f3b;

		L0fe4:
			// Instruction address 0x1d12:0x0ff0, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xce));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L1009;
			goto L1023;

		L1009:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xce));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1016;
			goto L103b;

		L1016:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L1023;
			goto L103b;

		L1023:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xce), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.AX.Word);

		L103b:
			goto L0f3b;

		L103e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1048;
			goto L1088;

		L1048:
			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))] = 1;

			// Instruction address 0x1d12:0x105d, size: 5
			F0_1d12_692d(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), flag);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec)), this.oCPU.DX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));
			goto L0ec9;

		L1088:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L10aa;

			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L10a6;
			goto L10aa;

		L10a6:
			this.oParent.Var_e8b8++;

		L10aa:
			this.oCPU.AX.Word = this.oParent.Var_e8b8;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L10b5;
			goto L1292;

		L10b5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe2), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xce), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L10d7;

		L10d3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L10d7:
			this.oCPU.AX.Word = this.Var_6540;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L10e3;
			goto L1248;

		L10e3:
			if (Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))] != 0)
				goto L1245;

			this.oCPU.AX.Word = (ushort)((short)(city.Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(city.Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x1151, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70da_Arr[0] - (city.ActualSize * 2) -
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)) *
					(short)this.oParent.Var_e3c6), 
				1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x10;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x1173, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x1190, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 1);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x11af, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70da_Arr[1] - (short)this.oParent.Var_d2f6,
				1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = 0x3;
			this.oCPU.IMULByte(this.oCPU.AX, (byte)city.ActualSize);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), this.oCPU.AX.Word));

			// Instruction address 0x1d12:0x11dc, size: 5
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)), 2);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.SI.Word);

			// Instruction address 0x1d12:0x11f7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70da_Arr[2], 1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L1226;
			goto L1245;

		L1226:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe2), this.oCPU.AX.Word);

		L1245:
			goto L10d3;

		L1248:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1252;
			goto L1292;

		L1252:
			Arr_3e[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))] = 1;

			// Instruction address 0x1d12:0x1267, size: 5
			F0_1d12_692d(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), flag);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec)), this.oCPU.DX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

			goto L10aa;

		L1292:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = 0x1a;
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xee)));
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xec)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			city.WorkerFlags0 = this.oCPU.CX.Word;
			city.WorkerFlags1 = this.oCPU.BX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae), this.oCPU.AX.Word);

		L12c2:
			this.oCPU.AX.Word = (ushort)((short)city.Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)city.Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L12f9;

		L12f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L12f9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1305;
			goto L132c;

		L1305:
			// Instruction address 0x1d12:0x1309, size: 5
			F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L1319;
			goto L1329;

		L1319:
			// Instruction address 0x1d12:0x1321, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 3);

		L1329:
			goto L12f5;

		L132c:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L133a;

		L1336:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L133a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x8);
			if (this.oCPU.Flags.L) goto L1344;
			goto L1357;

		L1344:
			// Instruction address 0x1d12:0x134c, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0);

			goto L1336;

		L1357:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf8), 0);
			this.oParent.Var_6c98 = 1;

			this.oCPU.TESTWord(city.BuildingFlags0, 0x4000);
			if (this.oCPU.Flags.NE) goto L137b;
			goto L1381;

		L137b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf8), 0x2);

		L1381:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x8000);
			if (this.oCPU.Flags.NE) goto L1394;
			goto L139a;

		L1394:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf8), 0x4);

		L139a:
			this.oCPU.TESTWord(city.BuildingFlags1, 0x4);
			if (this.oCPU.Flags.NE) goto L13ad;
			goto L13b3;

		L13ad:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), 0x2);

		L13b3:
			this.oCPU.TESTWord(city.BuildingFlags1, 0x8);
			if (this.oCPU.Flags.NE) goto L13c6;
			goto L13d2;

		L13c6:
			this.oParent.Var_6c98 = 2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), 0x2);

		L13d2:
			this.oCPU.TESTWord(city.BuildingFlags1, 0x10);
			if (this.oCPU.Flags.NE) goto L13e5;
			goto L13f1;

		L13e5:
			this.oParent.Var_6c98 = 2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), 0x2);

		L13f1:
			// Instruction address 0x1d12:0x13f9, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 15);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L1409;
			goto L145f;

		L1409:
			// Instruction address 0x1d12:0x1428, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[15]].Position.X,
				this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[15]].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x1442, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				city.Position.X,
				city.Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c)));
			if (this.oCPU.Flags.E) goto L1453;
			goto L145f;

		L1453:
			this.oParent.Var_6c98 = 2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), 0x2);

		L145f:
			this.oCPU.TESTWord(city.BuildingFlags1, 0x2);
			if (this.oCPU.Flags.NE) goto L1472;
			goto L1478;

		L1472:
			this.oParent.Var_6c98 = 3;

		L1478:
			// Instruction address 0x1d12:0x1484, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac)),
				0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf8)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[1];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[2];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xac));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_70da_Arr[1]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf8));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_70da_Arr[1]);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			
			this.oParent.Var_70da_Arr[1] = (ushort)((short)oParent.Var_70da_Arr[1] + (short)this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L14de;
			goto L2673;

		L14de:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
			this.oCPU.DX.Word = this.oParent.Var_70da_Arr[0];
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			city.FoodCount += (short)this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[1];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L1522;
			goto L1528;

		L1522:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0x0);

		L1528:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			city.ShieldsCount += (short)this.oCPU.AX.Word;

			if (city.CurrentProductionID < 0)
				goto L1b63;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)city.ShieldsCount);
			if (this.oCPU.Flags.LE) goto L156a;
			goto L1b60;

		L156a:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.E) goto L157c;
			goto L159b;

		L157c:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x1);
			if (this.oCPU.Flags.E) goto L158e;
			goto L159b;

		L158e:
			if (this.oParent.GameState.DifficultyLevel == 0)
				goto L2307;

		L159b:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			city.ShieldsCount -= (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 0xffff);

			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L15da;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
			if (this.oCPU.Flags.NE) goto L15da;
			goto L1606;

		L15da:
			// Instruction address 0x1d12:0x15fa, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				this.Var_6548_PlayerID,
				city.CurrentProductionID,
				city.Position.X,
				city.Position.Y);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), this.oCPU.AX.Word);

		L1606:
			this.oCPU.TESTByte((byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[city.CurrentProductionID], 0x8);
			if (this.oCPU.Flags.E) goto L1626;
			goto L1664;

		L1626:
			// Instruction address 0x1d12:0x1640, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(6, (byte)((sbyte)this.Var_6548_PlayerID), (byte)city.CurrentProductionID);
			
			this.oParent.GameState.TechnologyFirstDiscoveredBy[city.CurrentProductionID] |= 8;

		L1664:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x2);
			if (this.oCPU.Flags.NE) goto L1676;
			goto L1697;

		L1676:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1680;
			goto L1697;

		L1680:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].Status |= 0x20;

		L1697:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L16a1;
			goto L174b;

		L16a1:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.E) goto L16b3;
			goto L174b;

		L16b3:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x1);
			if (this.oCPU.Flags.LE) goto L16c5;
			goto L16d5;

		L16c5:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].CityCount > 1) goto L16d5;

			goto L174b;

		L16d5:
			city.ActualSize--;
			if (city.ActualSize == 0) goto L16e6;
			goto L174b;

		L16e6:
			// Instruction address 0x1d12:0x16ff, size: 5
			this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

			// Instruction address 0x1d12:0x1727, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				this.Var_6548_PlayerID,
				city.CurrentProductionID,
				city.Position.X,
				city.Position.Y);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), this.oCPU.AX.Word);

			this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

			// Instruction address 0x1d12:0x1743, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L6927;

		L174b:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L1ab6;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1761;
			goto L1ab6;

		L1761:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1b);
			if (this.oCPU.Flags.E) goto L1773;
			goto L1816;

		L1773:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);
			goto L1789;

		L1786:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

		L1789:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x80);
			if (this.oCPU.Flags.L) goto L1793;
			goto L1802;

		L1793:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID == this.Var_6548_PlayerID)
				goto L17ff;

			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L17bb;
			goto L17ff;

		L17bb:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L17ff;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)));
			if (this.oCPU.Flags.G) goto L17e7;
			goto L17ff;

		L17e7:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.AX.Word);

		L17ff:
			goto L1786;

		L1802:
			// Instruction address 0x1d12:0x180e, size: 5
			this.oParent.Segment_2459.F0_2459_0948(
				this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));

		L1816:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
			if (this.oCPU.Flags.E) goto L1828;
			goto L1a77;

		L1828:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), 0x7fff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);
			goto L1845;

		L1842:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

		L1845:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x80);
			if (this.oCPU.Flags.L) goto L184f;
			goto L19af;

		L184f:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L1842;

			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L1842;

			// Instruction address 0x1d12:0x1898, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0177(
				this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oParent.Var_6c9a;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x3);
			// Instruction address 0x1d12:0x18ab, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);
			this.oParent.Var_6c9a = this.oCPU.AX.Word;

			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].StatusFlag, 0x20);
			if (this.oCPU.Flags.NE) goto L18c8;
			goto L18ce;

		L18c8:
			this.oParent.Var_6c9a = 3;

		L18ce:
			this.oCPU.AX.Word = this.oParent.Var_6c9a;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L18da;
			goto L18fe;

		L18da:
			this.oCPU.AX.Word = this.oParent.Var_6c9a;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L18e6;
			goto L19ac;

		L18e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));
			
			// Instruction address 0x1d12:0x18ee, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L18fe;
			goto L19ac;

		L18fe:
			// Instruction address 0x1d12:0x191e, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Position.X,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L192e;
			goto L19ac;

		L192e:
			// Instruction address 0x1d12:0x1956, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Position.X,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x1970, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c)));
			if (this.oCPU.Flags.E) goto L1981;
			goto L19ac;

		L1981:
			this.oCPU.AX.Word = this.oParent.Var_6c9a;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L198d;
			goto L1996;

		L198d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x1);
			goto L199d;

		L1996:
			this.oCPU.AX.Word = this.oParent.Var_6c9a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), this.oCPU.AX.Word);

		L199d:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0), this.oCPU.AX.Word);

		L19ac:
			goto L1842;

		L19af:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), 0x3);
			if (this.oCPU.Flags.LE) goto L19b9;
			goto L1a5c;

		L19b9:
			if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) != 0)
				goto L1a5c;

			// Instruction address 0x1d12:0x19f9, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				this.Var_6548_PlayerID,
				0x1a,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))].Position.X,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))].Position.Y);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1a0f;
			goto L1a59;

		L1a0f:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0))].Position.X;

			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb0))].Position.Y;

		L1a59:
			goto L1a77;

		L1a5c:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			city.ShieldsCount += (short)this.oCPU.AX.Word;

		L1a77:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x19);
			if (this.oCPU.Flags.E) goto L1a89;
			goto L1aa8;

		L1a89:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ActiveUnits[25] == 1)
			{
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ContactPlayerCountdown = -1;
			}

		L1aa8:
			// Instruction address 0x1d12:0x1aab, size: 5
			this.oParent.Segment_25fb.F0_25fb_34b6(cityID);
			
			goto L1b60;

		L1ab6:
			city.ShieldsCount = 0;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1ace;
			goto L1b60;

		L1ace:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.NE) goto L1ae0;
			goto L1af2;

		L1ae0:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
			if (this.oCPU.Flags.GE) goto L1af2;
			goto L1b60;

		L1af2:
			this.oParent.Var_b1e8 = 1;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x1b00, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x1b10, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " builds ");

			// Instruction address 0x1d12:0x1b2e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Name);

			// Instruction address 0x1d12:0x1b3e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_Unknown = 0x3;

			// Instruction address 0x1d12:0x1b58, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

		L1b60:
			goto L220f;

		L1b63:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)city.ShieldsCount);
			if (this.oCPU.Flags.LE) goto L1b89;
			goto L220f;

		L1b89:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x18);
			if (this.oCPU.Flags.G) goto L1ba6;
			goto L1beb;

		L1ba6:
			if (this.oParent.GameState.WonderCityID[Math.Abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) - 24] != -1)
				goto L1be2;

			this.oParent.GameState.WonderCityID[Math.Abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) - 24] = cityID;

			// Instruction address 0x1d12:0x1bd7, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(10, (byte)((sbyte)this.Var_6548_PlayerID),
				(byte)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) - 0x18));

			goto L1be8;

		L1be2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0xffff);

		L1be8:
			goto L1c1d;

		L1beb:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L1c17;
			goto L1c1d;

		L1c17:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0xffff);

		L1c1d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1c27;
			goto L220f;

		L1c27:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x29);
			if (this.oCPU.Flags.E) goto L1c31;
			goto L1c80;

		L1c31:
			// Instruction address 0x1d12:0x1c39, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Sensors report a\nNUCLEAR WEAPONS test\nnear ");

			// Instruction address 0x1d12:0x1c44, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x1c54, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			// Instruction address 0x1d12:0x1c60, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

			this.oParent.Overlay_21.F21_0000_0000(-1);
			
			// Instruction address 0x1d12:0x1c78, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L1c80:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x16);
			if (this.oCPU.Flags.L) goto L1c8a;
			goto L1caf;

		L1c8a:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			city.BuildingFlags0 |= this.oCPU.CX.Word;
			city.BuildingFlags1 |= this.oCPU.BX.Word;

		L1caf:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			city.ShieldsCount -= (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L1ce2;
			goto L1cec;

		L1ce2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x18);
			if (this.oCPU.Flags.G) goto L1cec;
			goto L1dfc;

		L1cec:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L1cfe;
			goto L1d07;

		L1cfe:
			this.oParent.Var_b1e8 = 1;
			goto L1d29;

		L1d07:
			short tempVal = -1;
			this.oParent.GameState.MapVisibility[city.Position.X, city.Position.Y] = (ushort)tempVal;

		L1d29:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x1d31, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x1d41, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " builds\n");

			// Instruction address 0x1d12:0x1d58, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Name);

			// Instruction address 0x1d12:0x1d68, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L1de0;

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.NE) goto L1d86;
			goto L1de0;

		L1d86:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x15);
			if (this.oCPU.Flags.G) goto L1d90;
			goto L1d9a;

		L1d90:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x18);
			if (this.oCPU.Flags.G) goto L1d9a;
			goto L1de0;

		L1d9a:
			this.oCPU.TESTByte(city.StatusFlag, 0x10);
			if (this.oCPU.Flags.E) goto L1dac;
			goto L1de0;

		L1dac:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1);
			if (this.oCPU.Flags.NE) goto L1db6;
			goto L1de0;

		L1db6:
			// Instruction address 0x1d12:0x1dbe, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 0);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L1dce;
			goto L1de0;

		L1dce:
			this.oParent.CityView.F19_0000_0000(cityID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));

			goto L1deb;

		L1de0:
			this.oParent.Overlay_21.F21_0000_0000(cityID);

		L1deb:
			city.ShieldsCount = 0;
			goto L1e60;

		L1dfc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1);
			if (this.oCPU.Flags.E) goto L1e06;
			goto L1e13;

		L1e06:
			city.CurrentProductionID = -2;

		L1e13:
			// Instruction address 0x1d12:0x1e1a, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);
			
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L1e42;
			goto L1e60;

		L1e42:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L1e60:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x16);
			if (this.oCPU.Flags.GE) goto L1e6a;
			goto L2010;

		L1e6a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x18);
			if (this.oCPU.Flags.LE) goto L1e74;
			goto L2010;

		L1e74:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L1e86;
			goto L2010;

		L1e86:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L1ea9;

			this.oParent.Overlay_18.F18_0000_0f83(
				this.Var_6548_PlayerID,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) - 22));
			
			goto L2010;

		L1ea9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x16);

			this.oParent.Overlay_18.F18_0000_0d4f(this.Var_6548_PlayerID, (short)this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), 0x0);
			if (this.oCPU.Flags.NE) goto L1ecb;
			goto L1f2f;

		L1ecb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x18);
			if (this.oCPU.Flags.L) goto L1ed5;
			goto L1f2f;

		L1ed5:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Price);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			city.ShieldsCount += (short)this.oCPU.CX.Word;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xea);
			if (this.oCPU.Flags.LE) goto L1f05;
			goto L1f2b;

		L1f05:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
			if (this.oCPU.Flags.GE) goto L1f17;
			goto L1f2b;

		L1f17:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			city.CurrentProductionID = (sbyte)this.oCPU.AX.Low;

		L1f2b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8))));

		L1f2f:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L1f41;
			goto L1ffa;

		L1f41:
			if (this.oParent.GameState.AISpaceshipSuccessRate >= 40) goto L1f4b;
			goto L1ffa;

		L1f4b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), 0x0);
			if (this.oCPU.Flags.E) goto L1f55;
			goto L1feb;

		L1f55:
			// Instruction address 0x1d12:0x1f5d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, (int)TechnologyEnum.SpaceFlight);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L1f6d;

			goto L1ff7;

		L1f6d:
			if (this.oParent.GameState.AISpaceshipSuccessRate <= 75) goto L1f77;
			goto L1feb;

		L1f77:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking >
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Ranking) goto L1feb;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L1fc5;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].SpaceshipETAYear;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Year);
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipETAYear;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, (ushort)this.oParent.GameState.Year);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.LE) goto L1feb;

		L1fc5:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L1ff7;
			if (this.oParent.GameState.Players[this.oParent.GameState.ActiveCivilizations].Coins <= 1000) goto L1ff7;

		L1feb:
			this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);

		L1ff7:
			goto L2010;

		L1ffa:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), 0x0);
			if (this.oCPU.Flags.NE) goto L2004;
			goto L2010;

		L2004:
			this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);

		L2010:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1);
			if (this.oCPU.Flags.E) goto L201a;
			goto L212c;

		L201a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);
			goto L2025;

		L2022:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

		L2025:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x80);
			if (this.oCPU.Flags.L) goto L202f;
			goto L205a;

		L202f:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID != this.Var_6548_PlayerID)
				goto L2057;

			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BuildingFlags0 &= 0xfffe;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BuildingFlags1 &= 0xffff;

		L2057:
			goto L2022;

		L205a:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L207e;

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.Var_6548_PlayerID] & 0x40) == 0)
				goto L212c;

		L207e:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L20a5;

			// Instruction address 0x1d12:0x2097, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Diplomats report:\n");

			this.oParent.Var_2f9e_Unknown = 0x1;

		L20a5:
			// Instruction address 0x1d12:0x20b3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[this.Var_6548_PlayerID].Nationality);

			// Instruction address 0x1d12:0x20c3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " capital\nmoved to ");

			// Instruction address 0x1d12:0x20ce, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x20de, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_Unknown = 0x5;

			// Instruction address 0x1d12:0x20f8, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oParent.GameState.Players[this.Var_6548_PlayerID].XStart = (short)city.Position.X;

			city.BuildingFlags0 |= 1;
			city.BuildingFlags1 |= 0;

		L212c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x26);
			if (this.oCPU.Flags.E) goto L2136;
			goto L2160;

		L2136:
			// Instruction address 0x1d12:0x2136, size: 5
			this.oParent.Segment_11a8.F0_11a8_0280();
			
			// Instruction address 0x1d12:0x2143, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);
			
			// Instruction address 0x1d12:0x2153, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);
			
			// Instruction address 0x1d12:0x215b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0294();

		L2160:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x2b);
			if (this.oCPU.Flags.E) goto L216a;
			goto L220f;

		L216a:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L220f;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);
			goto L2181;

		L217e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

		L2181:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x80);
			if (this.oCPU.Flags.L) goto L218b;
			goto L220f;

		L218b:
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L219d;
			goto L220c;

		L219d:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID == this.Var_6548_PlayerID)
				goto L220c;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].ActualSize;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].VisibleSize = (sbyte)this.oCPU.AX.Low;

			this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y] |= (ushort)(1 << this.Var_6548_PlayerID);

			// Instruction address 0x1d12:0x2204, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y);

		L220c:
			goto L217e;

		L220f:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L2307;

			this.oCPU.TESTByte(city.StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L222d;
			goto L2307;

		L222d:
			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.NE) goto L223f;
			goto L225b;

		L223f:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L2251;
			goto L2307;

		L2251:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xffff);
			if (this.oCPU.Flags.E) goto L225b;
			goto L2307;

		L225b:
			// Instruction address 0x1d12:0x2262, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x63);
			if (this.oCPU.Flags.NE) goto L2281;
			goto L22fa;

		L2281:
			this.oParent.Var_b1e8 = 0;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L2299;
			goto L22b7;

		L2299:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

		L22b7:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			city.CurrentProductionID = (sbyte)this.oCPU.AX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L22d9;
			goto L22f7;

		L22d9:						
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L22f7:
			goto L2307;

		L22fa:
			city.StatusFlag &= 0xef;

		L2307:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L2319;
			goto L2673;

		L2319:
			this.oCPU.TESTByte(city.StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L232b;
			goto L2336;

		L232b:
			// Instruction address 0x1d12:0x232e, size: 5
			this.oParent.Segment_25fb.F0_25fb_34b6(cityID);

		L2336:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), 0x0);

			// Instruction address 0x1d12:0x2344, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			// ??? Needs further investigation why this happens
			if (this.oCPU.AX.Word >= this.oParent.GameState.Players.Length)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.AX.Word].Continents[this.Var_6548_PlayerID].Strategy;
			}
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x1);
			if (this.oCPU.Flags.NE) goto L236a;
			goto L237e;

		L236a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x2);
			if (this.oCPU.Flags.NE) goto L2374;
			goto L237e;

		L2374:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x5);
			if (this.oCPU.Flags.E) goto L237e;
			goto L23d3;

		L237e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.NE) goto L2388;
			goto L23d3;

		L2388:
			if (city.CurrentProductionID >= 0)
			{
				if (this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].UnitCategory ==
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)))
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc),
						(ushort)((short)(this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 64)));
				}
			}

		L23d3:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L23e8;
			goto L2432;

		L23e8:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x16);
			if (this.oCPU.Flags.GE) goto L23ff;
			goto L2432;

		L23ff:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x18);
			if (this.oCPU.Flags.LE) goto L2416;
			goto L2432;

		L2416:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

		L2432:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L2444;
			goto L24b3;

		L2444:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L2456;
			goto L24b3;

		L2456:
			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.NE) goto L2468;
			goto L24b3;

		L2468:
			// Instruction address 0x1d12:0x24a7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price *
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))) -
					city.ShieldsCount,
				0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

		L24b3:
			// Instruction address 0x1d12:0x24bb, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L24c9;
			goto L24db;

		L24c9:
			this.oCPU.TESTByte(city.StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L24db;
			goto L253c;

		L24db:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L24ed;
			goto L253c;

		L24ed:
			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.NE) goto L24ff;
			goto L253c;

		L24ff:
			// Instruction address 0x1d12:0x2530, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))) -
					city.ShieldsCount,
				0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

		L253c:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xff);
			if (this.oCPU.Flags.E) goto L254e;
			goto L259d;

		L254e:
			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.NE) goto L2560;
			goto L259d;

		L2560:
			// Instruction address 0x1d12:0x2591, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))) -
					city.ShieldsCount,
				0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

		L259d:
			this.oCPU.CMPByte(city.StatusFlag, 0x19);
			if (this.oCPU.Flags.E) goto L25af;
			goto L2619;

		L25af:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ActiveUnits[25] != 0)
				goto L2619;

			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.NE) goto L25d4;
			goto L2619;

		L25d4:
			// Instruction address 0x1d12:0x260d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))) -
					city.ShieldsCount,
				0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

		L2619:
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, 0x7d0);
			if (this.oCPU.Flags.G) goto L262a;
			goto L2646;

		L262a:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x9;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc)), this.oCPU.AX.Word));

		L2646:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc));
			city.ShieldsCount += (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -= (short)this.oCPU.AX.Word;
			city.StatusFlag &= 0xef;

		L2673:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L267f;
			goto L277e;

		L267f:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2687;
			goto L277e;

		L2687:
			// Instruction address 0x1d12:0x2697, size: 5
			F0_1d12_70cb(2, 67, 124, 104);

			// Instruction address 0x1d12:0x26af, size: 5
			F0_1d12_70cb(95, 106, 227, 197);

			// Instruction address 0x1d12:0x26cf, size: 5
			F0_1d12_71bf(95, 106, 128, 114, 0x25ea, 9);

			// Instruction address 0x1d12:0x26ef, size: 5
			F0_1d12_71bf(129, 106, 160, 114, 0x25ef, 9);

			// Instruction address 0x1d12:0x270f, size: 5
			F0_1d12_71bf(161, 106, 193, 114, 0x25f5, 9);

			// Instruction address 0x1d12:0x272f, size: 5
			F0_1d12_71bf(194, 106, 226, 114, 0x25f9, 9);

			// Instruction address 0x1d12:0x275a, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 
				(33 * this.Var_2496) + 96, 107, 32, 7, 9, 15);

			this.oCPU.AX.Word = Var_2496;
			goto L2773;

		L2768:
			// Instruction address 0x1d12:0x2768, size: 5
			F0_1d12_72b7();
			goto L277e;

		L2773:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L277e;
			goto L2768;

		L277e:
			this.oCPU.AX.Word = (ushort)((short)city.Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)city.Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), this.oCPU.AX.Word);

			this.oParent.Var_d2e0 = 0;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 3)
			{
				this.Var_6b30 = 10;
			}

			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x50);
			this.oCPU.BX.Word = 0x3;
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[2];
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6b30);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oParent.Var_d2e0 = this.oCPU.AX.Word;

			this.oCPU.TESTWord(city.BuildingFlags0, 0x40);
			if (this.oCPU.Flags.E) goto L27f4;
			goto L2806;

		L27f4:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x1);
			if (this.oCPU.Flags.NE) goto L2806;
			goto L2812;

		L2806:
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oParent.Var_d2e0;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oParent.Var_d2e0 = this.oCPU.AX.Word;

		L2812:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
			{
				this.oParent.Var_d2e0 = 0x0;
			}

			this.oCPU.AX.Low = (byte)((sbyte)((short)this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0));
			city.BaseTrade = (sbyte)this.oCPU.AX.Low;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x0);
			goto L2848;

		L2844:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L2848:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x3);
			if (this.oCPU.Flags.L) goto L2852;
			goto L28d9;

		L2852:
			this.oCPU.AX.Low = (byte)city.TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0xff);
			if (this.oCPU.Flags.NE) goto L2871;
			goto L28d6;

		L2871:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID == this.Var_6548_PlayerID)
				goto L28b0;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oParent.Var_70da_Arr[2]);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			
			this.oParent.Var_70da_Arr[2] = (ushort)((short)this.oParent.Var_70da_Arr[2] + (short)this.oCPU.AX.Word);

			goto L28d6;

		L28b0:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oParent.Var_70da_Arr[2]);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			
			this.oParent.Var_70da_Arr[2] = (ushort)((short)this.oParent.Var_70da_Arr[2] + (short)this.oCPU.AX.Word);

		L28d6:
			goto L2844;

		L28d9:
			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x50);
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[2];
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6b30);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, 3);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oParent.Var_d2e0 = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
			{
				this.oParent.Var_d2e0 = 0;
			}

			if ((city.BuildingFlags0 & 0x40) != 0)
			{
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oParent.Var_d2e0;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oParent.Var_d2e0 = this.oCPU.AX.Word;
			}

			// Instruction address 0x1d12:0x2960, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				((-(this.oParent.GameState.Players[this.Var_6548_PlayerID].ScienceTaxRate +
					this.oParent.GameState.Players[this.Var_6548_PlayerID].TaxRate - 10) *
					((short)this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0)) + 5) / 10,
				0, (short)this.oParent.Var_70da_Arr[2]);

			this.oParent.Var_70da_Arr[3] = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x2999, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				((this.oParent.GameState.Players[this.Var_6548_PlayerID].TaxRate *
					((short)this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0)) + 5) / 10,
				0,
				(short)this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_70da_Arr[3] - (short)this.oParent.Var_d2e0);

			this.oParent.Var_e17a = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[2];
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70da_Arr[3]);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_e17a);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_d2e0);
			this.oParent.Var_70e6 = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x29ba, size: 5
			F0_1d12_6dcc(1);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_e17a += this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x29cc, size: 5
			F0_1d12_6dcc(2);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_70e6 += this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x29de, size: 5
			F0_1d12_6dcc(3);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_70da_Arr[3] = (ushort)((short)this.oParent.Var_70da_Arr[3] + (short)this.oCPU.AX.Word);

			this.oCPU.TESTWord(city.BuildingFlags0, 0x10);
			if (this.oCPU.Flags.NE) goto L29fe;
			goto L2a16;

		L29fe:
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[3];
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_70da_Arr[3] = (ushort)((short)this.oParent.Var_70da_Arr[3] + (short)this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oParent.Var_e17a;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_e17a += this.oCPU.AX.Word;

		L2a16:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x200);
			if (this.oCPU.Flags.NE) goto L2a29;
			goto L2a41;

		L2a29:
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[3];
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_70da_Arr[3] = (ushort)((short)this.oParent.Var_70da_Arr[3] + (short)this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oParent.Var_e17a;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_e17a += this.oCPU.AX.Word;

		L2a41:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oCPU.TESTWord(city.BuildingFlags0, 0x20);
			if (this.oCPU.Flags.NE) goto L2a5a;
			goto L2a8b;

		L2a5a:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

			// Instruction address 0x1d12:0x2a6e, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 0xc);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L2a7e;
			goto L2a8b;

		L2a7e:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

		L2a8b:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x800);
			if (this.oCPU.Flags.NE) goto L2a9e;
			goto L2acf;

		L2a9e:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

			// Instruction address 0x1d12:0x2ab2, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 0xc);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L2ac2;
			goto L2acf;

		L2ac2:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

		L2acf:
			// Instruction address 0x1d12:0x2ad3, size: 5
			F0_1d12_6cf3(10);

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)cityID);
			if (this.oCPU.Flags.E) goto L2ae3;
			goto L2aeb;

		L2ae3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), this.oCPU.AX.Word));

		L2aeb:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oParent.Var_70e6 = this.oCPU.AX.Word;
			this.oParent.Var_70e2 = 0;

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L2b79;

			this.oCPU.AX.Word = (ushort)oParent.GameState.DifficultyLevel;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xe);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word += (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].CityCount;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.DifficultyLevel);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
			this.oParent.Var_70e4 = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa8), this.oCPU.AX.Word);
			goto L2b90;

		L2b79:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x3);
			this.oParent.Var_70e4 = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa8), this.oCPU.AX.Word);

		L2b90:
			this.Var_6542 = 0;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			if (this.oCPU.Flags.L) goto L2bac;
			goto L2bd3;

		L2bac:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oParent.Var_70e4;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.Var_6542 = this.oCPU.CX.Word;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oParent.Var_70e4 = this.oCPU.AX.Word;

		L2bd3:
			// Instruction address 0x1d12:0x2bd9, size: 5
			F0_1d12_6dfe(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2bed;
			goto L2c3d;

		L2bed:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2bf5;
			goto L2c3d;

		L2bf5:
			if (this.Var_2496 != 1)
				goto L2c3d;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x74);

			// Instruction address 0x1d12:0x2c15, size: 5
			F0_1d12_6ed4(cityID, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 92);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x10));

			// Instruction address 0x1d12:0x2c35, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2,
				222, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2, 1);

		L2c3d:
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[3];
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_70e2 = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x2c4e, size: 5
			F0_1d12_6dfe(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2c62;
			goto L2cce;

		L2c62:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2c6a;
			goto L2cce;

		L2c6a:
			if (this.Var_2496 != 1)
				goto L2cce;

			this.oCPU.CMPWord(this.oParent.Var_70e2, 0x0);
			if (this.oCPU.Flags.NE) goto L2c7e;
			goto L2cce;

		L2c7e:
			// Instruction address 0x1d12:0x2c8f, size: 5
			F0_1d12_6ed4(cityID, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 92);

			// Instruction address 0x1d12:0x2ca6, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				208,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) + 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x10));
			
			// Instruction address 0x1d12:0x2cc6, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2,
				222, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2, 1);

		L2cce:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xd0);

			this.oCPU.TESTWord(city.BuildingFlags0, 0x2000);
			if (this.oCPU.Flags.NE) goto L2ce6;
			goto L2d1f;

		L2ce6:
			this.oParent.Var_70e4 -= 3;
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2cf7;
			goto L2d1f;

		L2cf7:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2cff;
			goto L2d1f;

		L2cff:
			if (this.Var_2496 != 1)
				goto L2d1f;

			// Instruction address 0x1d12:0x2d13, size: 5
			F0_1d12_7045(14, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10));

		L2d1f:
			// Instruction address 0x1d12:0x2d27, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Religion);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L2d37;

			goto L2dbc;

		L2d37:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x400);
			if (this.oCPU.Flags.NE) goto L2d4a;
			goto L2d6e;

		L2d4a:
			// Instruction address 0x1d12:0x2d52, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 9);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L2d62;
			goto L2d68;

		L2d62:
			this.oCPU.AX.Word = 0x6;
			goto L2d6b;

		L2d68:
			this.oCPU.AX.Word = 0x4;

		L2d6b:
			goto L2d71;

		L2d6e:
			this.oCPU.AX.Word = 0x0;

		L2d71:
			this.oParent.Var_70e4 -= this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2d81;
			goto L2dbc;

		L2d81:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2d89;
			goto L2dbc;

		L2d89:
			if (this.Var_2496 != 1)
				goto L2dbc;

			this.oCPU.TESTWord(city.BuildingFlags0, 0x400);
			if (this.oCPU.Flags.NE) goto L2da6;
			goto L2dbc;

		L2da6:
			// Instruction address 0x1d12:0x2db0, size: 5
			F0_1d12_7045(11, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10));

		L2dbc:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x8);
			if (this.oCPU.Flags.NE) goto L2dce;
			goto L2e7b;

		L2dce:
			// Instruction address 0x1d12:0x2dd6, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L2de6;

			goto L2dee;

		L2de6:
			this.oParent.Var_70e4 -= 2;
			goto L2e0a;

		L2dee:
			// Instruction address 0x1d12:0x2df6, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.CeremonialBurial);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L2e06;

			goto L2e0a;

		L2e06:
			this.oParent.Var_70e4--;

		L2e0a:
			// Instruction address 0x1d12:0x2e12, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 6);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L2e22;
			goto L2e47;

		L2e22:
			// Instruction address 0x1d12:0x2e2a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L2e3a;

			goto L2e40;

		L2e3a:
			this.oCPU.AX.Word = 0x2;
			goto L2e43;

		L2e40:
			this.oCPU.AX.Word = 0x1;

		L2e43:
			this.oParent.Var_70e4 -= this.oCPU.AX.Word;

		L2e47:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2e53;
			goto L2e7b;

		L2e53:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2e5b;
			goto L2e7b;

		L2e5b:
			if (this.Var_2496 != 1)
				goto L2e7b;

			// Instruction address 0x1d12:0x2e6f, size: 5
			F0_1d12_7045(4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10));

		L2e7b:
			// Instruction address 0x1d12:0x2e81, size: 5
			F0_1d12_6dfe(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2e95;
			goto L2ef3;

		L2e95:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2e9d;
			goto L2ef3;

		L2e9d:
			if (this.Var_2496 != 1)
				goto L2ef3;

			this.oCPU.TESTWord(city.BuildingFlags0, 0x2408);
			if (this.oCPU.Flags.NE) goto L2eba;
			goto L2ef3;

		L2eba:
			// Instruction address 0x1d12:0x2ecb, size: 5
			F0_1d12_6ed4(cityID, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 92);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x10));
			
			// Instruction address 0x1d12:0x2eeb, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2,
				222, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2, 1);

		L2ef3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xd0);
			
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType < 4) goto L2f08;
			goto L3088;

		L2f08:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6), 0);

			// Instruction address 0x1d12:0x2f1a, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), this.oCPU.AX.Word);

		L2f2a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2f34;
			goto L2ffa;

		L2f34:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x20);
			if (this.oCPU.Flags.L) goto L2f40;
			goto L2ffa;

		L2f40:
			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].TypeID].AttackStrength == 0)
				goto L2fc9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6))));
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2f74;
			goto L2fc9;

		L2f74:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L2f7c;
			goto L2fc9;

		L2f7c:
			if (this.Var_2496 != 1)
				goto L2fc9;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6)), 0x3);
			if (this.oCPU.Flags.LE) goto L2f90;
			goto L2fc9;

		L2f90:
			// Instruction address 0x1d12:0x2fbd, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].TypeID +
					(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));

		L2fc9:
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 
				(short)this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))].NextUnitID);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2ff1;
			goto L2ff7;

		L2ff1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 0xffff);

		L2ff7:
			goto L2f2a;

		L2ffa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 0x0);
			goto L3007;

		L3003:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))));

		L3007:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)), 0x2);
			if (this.oCPU.Flags.L) goto L3011;
			goto L305d;

		L3011:
			this.oCPU.CMPWord(this.oParent.Var_70e4, 0x0);
			if (this.oCPU.Flags.NE) goto L301b;
			goto L305a;

		L301b:
			this.oCPU.CMPByte((byte)city.Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))], 0xff);
			if (this.oCPU.Flags.NE) goto L3031;
			goto L305a;

		L3031:
			if (this.oParent.GameState.UnitDefinitions[city.Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))] & 0x3f].AttackStrength != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6),
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6))));
			}

		L305a:
			goto L3003;

		L305d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6)), 0x3);
			if (this.oCPU.Flags.G) goto L3067;
			goto L306d;

		L3067:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6), 0x3);

		L306d:
			// Instruction address 0x1d12:0x3079, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe6)),
				0, (short)this.oParent.Var_70e4);

			this.oParent.Var_70e4 -= this.oCPU.AX.Word;
			goto L3126;

		L3088:
			// Instruction address 0x1d12:0x3090, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 16);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.CX.Word);

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))));
			}

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.NE) goto L30c1;
			goto L3126;

		L30c1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
			this.oParent.Var_70e4 += this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L30d9;
			goto L3126;

		L30d9:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L30e1;
			goto L3126;

		L30e1:
			if (this.Var_2496 != 1)
				goto L3126;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 0x0);
			goto L30f8;

		L30f4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba))));

		L30f8:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xba)));
			if (this.oCPU.Flags.G) goto L3109;
			goto L3126;

		L3109:
			// Instruction address 0x1d12:0x3117, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) + 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L30f4;

		L3126:
			// Instruction address 0x1d12:0x312c, size: 5
			F0_1d12_6dfe(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L3140;
			goto L318b;

		L3140:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L3148;
			goto L318b;

		L3148:
			if (this.Var_2496 != 1)
				goto L318b;

			// Instruction address 0x1d12:0x3163, size: 5
			F0_1d12_6ed4(cityID, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 92);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x10));
			
			// Instruction address 0x1d12:0x3183, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2,
				222, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2, 1);

		L318b:
			this.oCPU.AX.Word = this.oParent.Var_70e2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x319e, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 2);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L31ae;
			goto L31b2;

		L31ae:
		this.oParent.Var_70e2++;

		L31b2:
			// Instruction address 0x1d12:0x31ba, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 0x15);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L31ca;
			goto L31ce;

		L31ca:
			this.oParent.Var_70e2++;

		L31ce:
			// Instruction address 0x1d12:0x31d2, size: 5
			F0_1d12_6cf3(11);

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)cityID);
			if (this.oCPU.Flags.E) goto L31e2;
			goto L31e8;

		L31e2:
			this.oParent.Var_70e4 = 0;

		L31e8:
			// Instruction address 0x1d12:0x31f0, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 0xd);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L3200;
			goto L323d;

		L3200:
			// Instruction address 0x1d12:0x3217, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[13]].Position.X,
				this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[13]].Position.Y);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x3229, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L3238;
			goto L323d;

		L3238:
			this.oParent.Var_70e4 -= 2;

		L323d:
			// Instruction address 0x1d12:0x3243, size: 5
			F0_1d12_6dfe(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L3257;
			goto L32cd;

		L3257:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L325f;
			goto L32cd;

		L325f:
			if (this.Var_2496 != 1)
				goto L32cd;

			this.oCPU.AX.Word = this.oParent.Var_70e2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			if (this.oCPU.Flags.NE) goto L3279;
			goto L32cd;

		L3279:
			// Instruction address 0x1d12:0x328a, size: 5
			F0_1d12_6ed4(cityID, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 92);

			// Instruction address 0x1d12:0x32a5, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("WONDERS", 190, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) + 5, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x10));

			// Instruction address 0x1d12:0x32c5, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2,
				222, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)) - 2, 1);

		L32cd:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.E) goto L32d7;
			goto L32e0;

		L32d7:
			this.oParent.Var_70e4 = 0;
			this.oParent.Var_70e2 = 0;

		L32e0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), 0);
			this.oParent.Var_deb8 = 0;
			this.oParent.Var_d2f6 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L32fc;

		L32f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L32fc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x2);
			if (this.oCPU.Flags.L) goto L3306;
			goto L3323;

		L3306:
			this.oCPU.CMPByte((byte)city.Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))], 0xff);
			if (this.oCPU.Flags.NE) goto L331c;
			goto L3320;

		L331c:
			this.oParent.Var_deb8++;

		L3320:
			goto L32f8;

		L3323:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
			if (this.oCPU.Flags.L) goto L3339;
			goto L3350;

		L3339:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oParent.Var_deb8;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oParent.Var_d2f6 = this.oCPU.CX.Word;

		L3350:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), 0x45);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa), 0x64);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100), 0x74);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L3375;

		L3371:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L3375:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x80);
			if (this.oCPU.Flags.L) goto L3380;
			goto L39ef;

		L3380:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID == -1)
				goto L38d4;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].HomeCityID != cityID)
				goto L38d4;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID >= 26)
				goto L340f;

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);

			this.oParent.Var_deb8++;

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
			if (this.oCPU.Flags.GE) goto L33f1;
			goto L340b;

		L33f1:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType > 1) goto L3401;
			goto L340f;

		L3401:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L340b;
			goto L340f;

		L340b:
			this.oParent.Var_d2f6++;

		L340f:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L341a;
			goto L3672;

		L341a:
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[1], this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L3426;
			goto L3463;

		L3426:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L3438;
			goto L3672;

		L3438:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.E) goto L3447;
			goto L3672;

		L3447:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L3672;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L3463;
			goto L3672;

		L3463:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x0);
			goto L347b;

		L3477:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));

		L347b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), 0x80);
			if (this.oCPU.Flags.GE)
				goto L353f;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))].TypeID == -1)
				goto L3477;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))].HomeCityID != cityID)
				goto L3477;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))].TypeID >= 26)
				goto L3477;

			// Instruction address 0x1d12:0x3513, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				city.Position.X,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))].Position.X,
				city.Position.Y,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE)
				goto L3477;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.AX.Word);

			goto L3477;

		L353f:
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[1], this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L354b;
			goto L35e1;

		L354b:
			this.oCPU.CMPWord(this.oParent.Var_8078, 0x0);
			if (this.oCPU.Flags.NE) goto L3555;
			goto L3577;

		L3555:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount < 
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].DiscoveredTechnologyCount)
				goto L356e;

			goto L3577;

		L356e:
			this.oParent.Var_db42 = 0xfc19;
			goto L35de;

		L3577:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc8)), 0x0);
			if (this.oCPU.Flags.G) goto L3581;
			goto L35de;

		L3581:
			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))].TypeID].TerrainCategory != 0)
				goto L35de;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))].TypeID == 0)
				goto L35de;

			// Instruction address 0x1d12:0x35c9, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
			
			city.StatusFlag &= 0xfe;

		L35de:
			goto L3672;

		L35e1:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L365f;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x35f5, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x3605, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " can't support\n");

			// Instruction address 0x1d12:0x362d, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))].TypeID].Name);

			// Instruction address 0x1d12:0x363d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n Unit Disbanded.\n");

			this.oParent.Var_2f9e_Unknown = 0x3;

			// Instruction address 0x1d12:0x3657, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L365f:
			// Instruction address 0x1d12:0x3667, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
			
			goto L32e0;

		L3672:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L367e;
			goto L38d4;

		L367e:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L3686;
			goto L38d4;

		L3686:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID >= 26)
				goto L384a;

			this.oCPU.CMPWord(this.oParent.Var_d2f6, 0x0);
			if (this.oCPU.Flags.NE) goto L36ac;
			goto L36c8;

		L36ac:
			// Instruction address 0x1d12:0x36c0, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 12,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));

		L36c8:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID != 0)
				goto L372a;

			// Instruction address 0x1d12:0x36f4, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 12,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 2)
			{
				// Instruction address 0x1d12:0x371f, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
					this.oParent.Var_aa_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)) + 2,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 12,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
			}
			goto L384a;

		L372a:
			// Instruction address 0x1d12:0x3732, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 16);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.CX.Word);

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))));
			}

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L3769;
			goto L384a;

		L3769:
			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID].AttackStrength == 0)
				goto L384a;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.NE) goto L3797;
			goto L384a;

		L3797:
			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID].TerrainCategory == 1)
				goto L380d;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.X != 
				city.Position.X)
				goto L380d;
			
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.Y ==
				city.Position.Y)
				goto L384a;

		L380d:
			// Instruction address 0x1d12:0x381d, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 12,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1);
			if (this.oCPU.Flags.G) goto L382f;
			goto L384a;

		L382f:
			// Instruction address 0x1d12:0x3842, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)) + 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 12,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

		L384a:
			// Instruction address 0x1d12:0x3877, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID +
						(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x1d12:0x38a3, size: 5
			F0_1d12_73ea(
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.X,
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.Y, 
				7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)), 0x10));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)), 0x70);
			if (this.oCPU.Flags.GE) goto L38ba;
			goto L38d4;

		L38ba:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x10));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x55);
			if (this.oCPU.Flags.G) goto L38cf;
			goto L38d4;

		L38cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x18));

		L38d4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x12);
			if (this.oCPU.Flags.GE)
				goto L3371;

			if (this.Var_2496 != 0)
				goto L3371;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].TypeID == -1)
				goto L3371;

			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE)
				goto L3371;

			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L3371;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.X != 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)))
				goto L3371;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Position.Y !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)))
				goto L3371;

			// Instruction address 0x1d12:0x3969, size: 5
			this.oParent.Segment_2aea.F0_2aea_0fb3(this.Var_6548_PlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x398e, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].HomeCityID);
			
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba09, 0x2e);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0a, 0x0);

			// Instruction address 0x1d12:0x39b4, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)) + 15,
				0);

			Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e))] =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e))));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa)), 0x12));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa), 0x64);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100),
					this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)), 0x10));
			}

			goto L3371;

		L39ef:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L39fa;
			goto L3a72;

		L39fa:
			this.oCPU.AX.Word = this.oParent.Var_deb8;
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[1], this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L3a06;
			goto L3a16;

		L3a06:
			this.oCPU.AX.Word = this.oParent.Var_deb8;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70da_Arr[1]);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oParent.Var_e3c2 += this.oCPU.AX.Word;

		L3a16:
			// Instruction address 0x1d12:0x3a2c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_deb8,
				0, city.ActualSize);

			this.oParent.Var_e3c2 += this.oCPU.AX.Word;

			this.oCPU.TESTWord(city.BuildingFlags0, 0x10);
			if (this.oCPU.Flags.NE) goto L3a4a;
			goto L3a50;

		L3a4a:
			this.oCPU.AX.Word = 0x5;
			goto L3a53;

		L3a50:
			this.oCPU.AX.Word = 0x7;

		L3a53:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word,
				(ushort)this.oParent.GameState.Nations[this.oParent.GameState.Players[this.Var_6548_PlayerID].NationalityID].Ideology);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
			this.oParent.Var_db42 -= this.oCPU.AX.Word;

		L3a72:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L3a7e;
			goto L5cd0;

		L3a7e:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L3a86;
			goto L5cd0;

		L3a86:
			this.oParent.Var_aa_Rectangle.FontID = 2;

			// Instruction address 0x1d12:0x3a9f, size: 5
			F0_1d12_70cb(211, 1, 317, 97);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb4), 0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda)), 0x0);
			if (this.oCPU.Flags.E) goto L3ac6;
			goto L3b80;

		L3ac6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x0);
			goto L3ad3;

		L3acf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L3ad3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x15);
			if (this.oCPU.Flags.L) goto L3add;
			goto L3b80;

		L3add:
			if (this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1] != cityID)
				goto L3b7d;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x3b09, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 
				this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) + 1].Name);

			// Instruction address 0x1d12:0x3b15, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x1d12:0x3b25, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 63);

			// Instruction address 0x1d12:0x3b40, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 253, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) + 2, 15);

			// Instruction address 0x1d12:0x3b69, size: 5
			F0_1d12_7045((short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) + 1),
				(short)(((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)) & 1) != 0) ? 213 : 233),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) - 2));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)), 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L3b7d:
			goto L3acf;

		L3b80:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfe), 0x0);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), this.oCPU.AX.Word);
			goto L3b95;

		L3b91:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L3b95:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x18);
			if (this.oCPU.Flags.L) goto L3b9f;
			goto L3c83;

		L3b9f:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L3bc9;
			goto L3c80;

		L3bc9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), 0x10);
			if (this.oCPU.Flags.GE) goto L3bd3;
			goto L3be9;

		L3bd3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca), 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca), 
				this.oCPU.ANDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0xfffe));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfe), this.oCPU.AX.Word);
			goto L3c83;

		L3be9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb4))));

			// Instruction address 0x1d12:0x3bfb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				309,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

			// Instruction address 0x1d12:0x3c12, size: 5
			this.oParent.MSCAPI.strcpy(0xba06,
				this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Name);

			// Instruction address 0x1d12:0x3c22, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 56);

			// Instruction address 0x1d12:0x3c3d, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x1d12:0x3c46, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 253, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) + 2, 15);

			// Instruction address 0x1d12:0x3c6f, size: 5
			F0_1d12_7045((short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1),
				(short)(((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)) & 1) != 0) ? 213 : 233),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) - 2));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)), 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));

		L3c80:
			goto L3b91;

		L3c83:
			// Instruction address 0x1d12:0x3c97, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				231, 0, 250, 0, 0);

			// Instruction address 0x1d12:0x3cb3, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				231, 1, 250, 1, 1);

			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x2);
			if (this.oCPU.Flags.NE) goto L3cc5;
			goto L3ce5;

		L3cc5:
			// Instruction address 0x1d12:0x3cdd, size: 5
			F0_1d12_71bf(287, 88, 315, 96, 0x262a, 9);

		L3ce5:
			// Instruction address 0x1d12:0x3d01, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 309, 2, 8, 96, 14, 12);

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L3d1b;
			goto L3d36;

		L3d1b:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xde), this.oCPU.AX.Word);

			goto L3d54;

		L3d36:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xde), this.oCPU.AX.Word);

		L3d54:
			// Instruction address 0x1d12:0x3d7a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xde)) - 1) / 10) + 1,
				((city.ShieldsCount - 1) / 100) + 1, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xde));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x3ded, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				230, 99,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)) + 3,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 19,
				1);

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L3e59;

			// Instruction address 0x1d12:0x3e31, size: 5
			F0_1d12_71bf(231, 106, 263, 114, (ushort)(((city.StatusFlag & 0x10) != 0) ? 0x262f : 0x2635), 9);

			// Instruction address 0x1d12:0x3e51, size: 5
			F0_1d12_71bf(294, 106, 311, 114, 0x263c, 9);

		L3e59:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L3e6b;
			goto L3e99;

		L3e6b:
			// Instruction address 0x1d12:0x3e8e, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				264, 100,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((byte)city.CurrentProductionID +
						(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));
			goto L3ee5;

		L3e99:
			// Instruction address 0x1d12:0x3eb5, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Name);

			// Instruction address 0x1d12:0x3ec5, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 0x56);

			// Instruction address 0x1d12:0x3edd, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 274, 100, 15);

		L3ee5:
			// Instruction address 0x1d12:0x3ef9, size: 5
			F0_1d12_710d_FillRectangleWithPattern(231, 116,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L3f0e;

		L3f0a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L3f0e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.CMPWord((ushort)city.ShieldsCount, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L3f23;
			goto L3f60;

		L3f23:
			// Instruction address 0x1d12:0x3f55, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				(((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) %
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)) *
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)))) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) /
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))) + 232,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) /
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)))) * 8) + 117,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
			goto L3f0a;

		L3f60:
			// Instruction address 0x1d12:0x3f7b, size: 5
			if (city.ActualSize != 0)
			{
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(80 / city.ActualSize, 1, 8);
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x3fb5, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				2, 106, 91,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc))) + 12,
				1);

			// Instruction address 0x1d12:0x3fcd, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Food Storage", 8, 108, 15);

			// Instruction address 0x1d12:0x3ffc, size: 5
			F0_1d12_710d_FillRectangleWithPattern(3, 115,
				(city.ActualSize * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 9,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)) * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc))) + 2);

			this.oCPU.TESTWord(city.BuildingFlags0, 0x4);
			if (this.oCPU.Flags.NE) goto L4016;
			goto L4043;

		L4016:
			// Instruction address 0x1d12:0x403b, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				5, 155, 
				(city.ActualSize * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 9, 155, 1);

		L4043:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L4050;

		L404c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L4050:
			// Instruction address 0x1d12:0x406a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				city.FoodCount,
				0, (city.ActualSize + 1) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));
			if (this.oCPU.Flags.G) goto L407b;
			goto L40ba;

		L407b:
			// Instruction address 0x1d12:0x40af, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) % (city.ActualSize + 1)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 4,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) / (city.ActualSize + 1)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc))) + 116,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
			goto L404c;

		L40ba:
			// Instruction address 0x1d12:0x40ca, size: 5
			F0_1d12_70cb(2, 23, 124, 65);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), 0x19);

			// Instruction address 0x1d12:0x40f0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 23, 122, 9, 1);

			// Instruction address 0x1d12:0x4108, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("City Resources", 8, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x0);
			goto L4122;

		L411e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L4122:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x3);
			if (this.oCPU.Flags.L) goto L412c;
			goto L427d;

		L412c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x0);
			if (this.oCPU.Flags.E) goto L413c;
			goto L4190;

		L413c:
			// Instruction address 0x1d12:0x416d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))],
				(city.ActualSize * 2) +
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)) * 
					(short)this.oParent.Var_e3c6), 999);

			// Instruction address 0x1d12:0x4181, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / ((short)this.oCPU.AX.Word + 1), 1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			goto L41b8;

		L4190:
			// Instruction address 0x1d12:0x41ac, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				116 / ((short)this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))] + 1),
				1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

		L41b8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L41c5;

		L41c1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L41c5:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[0], this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L41d8;
			goto L411e;

		L41d8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x0);
			if (this.oCPU.Flags.E) goto L41e2;
			goto L420a;

		L41e2:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));
			if (this.oCPU.Flags.E) goto L4205;
			goto L420a;

		L4205:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), 0x4));

		L420a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x1);
			if (this.oCPU.Flags.E) goto L4214;
			goto L422f;

		L4214:
			this.oCPU.CMPWord(this.oParent.Var_d2f6, 0x0);
			if (this.oCPU.Flags.NE) goto L421e;
			goto L422f;

		L421e:
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L422a;
			goto L422f;

		L422a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), 0x4));

		L422f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x2);
			if (this.oCPU.Flags.E) goto L4239;
			goto L424e;

		L4239:
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[2];
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_d2e0);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));
			if (this.oCPU.Flags.E) goto L4249;
			goto L424e;

		L4249:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), 0x2));

		L424e:
			// Instruction address 0x1d12:0x4267, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) * 8) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 8) << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), this.oCPU.AX.Word));
			goto L41c1;

		L427d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 0x8);

			// Instruction address 0x1d12:0x42a6, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				224 / ((short)this.oParent.Var_70da_Arr[3] + (short)this.oParent.Var_70e6 +
					(short)this.oParent.Var_e17a + (short)this.oParent.Var_d2e0 + 2),
				1, 16);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L42bf;

		L42bb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L42bf:
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[3];
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L42cb;
			goto L42f4;

		L42cb:
			// Instruction address 0x1d12:0x42e1, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)) / 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 24,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), this.oCPU.AX.Word));
			goto L42bb;

		L42f4:
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[3], 0x0);
			if (this.oCPU.Flags.NE) goto L42fe;
			goto L4303;

		L42fe:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), 0x8));

		L4303:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L4318;

		L4314:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L4318:
			this.oCPU.AX.Word = this.oParent.Var_e17a;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L4324;
			goto L434d;

		L4324:
			// Instruction address 0x1d12:0x433a, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)) / 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 24,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), this.oCPU.AX.Word));
			goto L4314;

		L434d:
			this.oCPU.CMPWord(this.oParent.Var_e17a, 0x0);
			if (this.oCPU.Flags.NE) goto L4357;
			goto L435c;

		L4357:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), 0x8));

		L435c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L4369;

		L4365:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L4369:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L4375;
			goto L439e;

		L4375:
			// Instruction address 0x1d12:0x438b, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)) / 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 24,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xc << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)), this.oCPU.AX.Word));
			goto L4365;

		L439e:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oParent.Var_70da_Arr[0]);
			if (this.oCPU.Flags.G) goto L43c1;
			goto L4497;

		L43c1:
			// Instruction address 0x1d12:0x43ed, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				116 / ((city.ActualSize * 2) +
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)) *
					(short)this.oParent.Var_e3c6) + 1),
				1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[0];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L4407;

		L4403:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L4407:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));
			if (this.oCPU.Flags.G) goto L442a;
			goto L4449;

		L442a:
			// Instruction address 0x1d12:0x443e, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
			goto L4403;

		L4449:
			// Instruction address 0x1d12:0x448f, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) * (short)this.oParent.Var_70da_Arr[0]) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)),
				(((city.ActualSize * 2) +
					(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)) * (short)this.oParent.Var_e3c6) -
					(short)this.oParent.Var_70da_Arr[0]) * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 4, 
				8, 15, 0);

		L4497:
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.CMPWord(this.oParent.Var_70da_Arr[1], this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L44a3;
			goto L453a;

		L44a3:
			// Instruction address 0x1d12:0x44b9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				116 / ((short)this.oParent.Var_70da_Arr[1] + 1),
				1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[1];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L44d3;

		L44cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L44d3:
			this.oCPU.AX.Word = this.oParent.Var_d2f6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L44df;
			goto L4502;

		L44df:
			// Instruction address 0x1d12:0x44f7, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
			goto L44cf;

		L4502:
			// Instruction address 0x1d12:0x4532, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				((short)this.oParent.Var_70da_Arr[1] * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 8,
				((short)this.oParent.Var_d2f6 - (short)this.oParent.Var_70da_Arr[1]) * 
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)),
				8, 15, 0);

		L453a:
			if (this.oParent.Var_d2e0 == 0)
				goto L45a0;

			// Instruction address 0x1d12:0x455a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				116 / ((short)this.oParent.Var_70da_Arr[2] + 1), 1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x4598, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				(((short)this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))) + 6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)) + 16,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) * (short)this.oParent.Var_d2e0) + 2,
				8, 15, 0);

		L45a0:
			// Instruction address 0x1d12:0x45b0, size: 5
			F0_1d12_710d_FillRectangleWithPattern(8, 8, 200, 13);

			// Instruction address 0x1d12:0x45ca, size: 5
			F0_1d12_6ed4(cityID, 8, 8, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 192);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x45f3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((city.ActualSize * 8) + 24, 0, 128);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x0);
			goto L460c;

		L4608:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L460c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x3);
			if (this.oCPU.Flags.L) goto L4616;
			goto L4770;

		L4616:
			this.oCPU.AX.Low = (byte)city.TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0xff);
			if (this.oCPU.Flags.NE) goto L4635;
			goto L476d;

		L4635:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x463d, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)));

			// Instruction address 0x1d12:0x464d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ":+");

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].PlayerID == this.Var_6548_PlayerID)
				goto L46bb;

			// Instruction address 0x1d12:0x46b0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(((short)city.BaseTrade +
					(short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
						(ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade + 4) >> 3),
					10));
			goto L4708;

		L46bb:
			// Instruction address 0x1d12:0x4700, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(((short)city.BaseTrade +
					(short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
						(ushort)(this.oCPU.BP.Word - 0x4c))].BaseTrade + 4) >> 4),
					10));

		L4708:
			// Instruction address 0x1d12:0x4710, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "} ");

			if (this.Var_2496 != 2)
				goto L4744;

			// Instruction address 0x1d12:0x473c, size: 5
			F0_1d12_73ea((ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.X),
				(ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))].Position.Y), 10);

		L4744:
			if (this.Var_2496 != 0)
				goto L476d;

			// Instruction address 0x1d12:0x4765, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 98,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) * 6) + 179, 10);

		L476d:
			goto L4608;

		L4770:
			if (this.Var_2496 != 2)
				goto L479d;

			// Instruction address 0x1d12:0x4795, size: 5
			F0_1d12_73ea((ushort)((short)this.oParent.GameState.Cities[this.Var_653e_CityID].Position.X),
				(ushort)((short)this.oParent.GameState.Cities[this.Var_653e_CityID].Position.Y), 15);

		L479d:
			if (this.Var_2496 != 0)
				goto L4852;

			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[1];
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oParent.Var_6c98;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x14);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.Var_b882);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), this.oCPU.AX.Word));

			// Instruction address 0x1d12:0x47ef, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 1, 99);

			// Instruction address 0x1d12:0x4802, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(100 / (short)this.oCPU.AX.Word, 1, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 0x0);
			goto L481b;

		L4817:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))));

		L481b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L4828;
			goto L4852;

		L4828:
			// Instruction address 0x1d12:0x4847, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc))) + 98,
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)) & 1) + 161,
				this.oParent.Var_b2ba);
			goto L4817;

		L4852:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L5cbd;

			// Instruction address 0x1d12:0x4876, size: 5
			F0_1d12_71bf(284, 190, 316, 198, 0x2662, 12);

			// Instruction address 0x1d12:0x4896, size: 5
			F0_1d12_71bf(231, 190, 272, 198, 0x2667, 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 0x0);

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L48b6;
			goto L48fb;

		L48b6:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xeb);
			if (this.oCPU.Flags.GE) goto L48c8;
			goto L48fb;

		L48c8:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, city.BuildingFlags0);
			this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, city.BuildingFlags1);

			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L48f5;
			goto L48fb;

		L48f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 0x1);

		L48fb:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xeb);
			if (this.oCPU.Flags.L) goto L490d;
			goto L4937;

		L490d:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
			if (this.oCPU.Flags.GE) goto L491f;
			goto L4937;

		L491f:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L4931;
			goto L4937;

		L4931:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 0x1);

		L4937:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
			if (this.oCPU.Flags.L) goto L4949;
			goto L496c;

		L4949:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if (this.oParent.GameState.WonderCityID[Math.Abs(city.CurrentProductionID) - 24] == -1)
				goto L496c;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 0x1);

		L496c:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L497e;
			goto L4994;

		L497e:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitCount >= 127)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 0x1);
			}

		L4994:
			// Instruction address 0x1d12:0x4994, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L4999:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L49a3;
			goto L49ab;

		L49a3:
			// Instruction address 0x1d12:0x49a3, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			goto L4999;

		L49ab:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.E) goto L49b5;
			goto L4a4e;

		L49b5:
			// Instruction address 0x1d12:0x49b5, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L49c2;
			goto L4a4e;

		L49c2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8)), 0x0);
			if (this.oCPU.Flags.E) goto L49cc;
			goto L4a4e;

		L49cc:
			// Instruction address 0x1d12:0x49cc, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0)), 0x0);
			if (this.oCPU.Flags.NE) goto L49db;
			goto L4a4b;

		L49db:
			// Instruction address 0x1d12:0x49db, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0))));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc0));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L49ef;
			goto L4a16;

		L49ef:
			// Instruction address 0x1d12:0x4a0b, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 14, 9);

			goto L4a3a;

		L4a16:
			// Instruction address 0x1d12:0x4a32, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 9, 14);

		L4a3a:
			// Instruction address 0x1d12:0x4a3a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1d12:0x4a43, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

		L4a4b:
			goto L49ab;

		L4a4e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0), 0xffff);

			// Instruction address 0x1d12:0x4a54, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L4a61;
			goto L4a76;

		L4a61:
			// Instruction address 0x1d12:0x4a61, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x0;
			this.oParent.Var_db3e = 0;
			this.oParent.Var_db3c = 0;
			goto L4a86;

		L4a76:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8)), 0x0);
			if (this.oCPU.Flags.NE) goto L4a80;
			goto L4a86;

		L4a80:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0), 0x70);

		L4a86:
			// Instruction address 0x1d12:0x4a86, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x2);
			if (this.oCPU.Flags.E) goto L4a95;
			goto L4abf;

		L4a95:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe6);
			if (this.oCPU.Flags.GE) goto L4aa0;
			goto L4abf;

		L4aa0:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
			if (this.oCPU.Flags.L) goto L4aab;
			goto L4abf;

		L4aab:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x6a);
			if (this.oCPU.Flags.GE) goto L4ab5;
			goto L4abf;

		L4ab5:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
			if (this.oCPU.Flags.G) goto L4abf;
			goto L4ac9;

		L4abf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x41);
			if (this.oCPU.Flags.E) goto L4ac9;
			goto L4bba;

		L4ac9:
			city.StatusFlag ^= 0x10;

			this.oCPU.TESTByte(city.StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L4ae8;
			goto L4baa;

		L4ae8:
			// Instruction address 0x1d12:0x4aef, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.AX.Word);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102)), 0x63);
			if (this.oCPU.Flags.NE) goto L4b0e;
			goto L4ba7;

		L4b0e:
			this.oParent.Var_b1e8 = 0;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4b26;
			goto L4b44;

		L4b26:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

		L4b44:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102));
			city.CurrentProductionID = (sbyte)this.oCPU.AX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4b66;
			goto L4b84;

		L4b66:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L4b84:
			// Instruction address 0x1d12:0x4b9c, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 230, 99, 90, 100, 0);

			goto L4baa;

		L4ba7:
			goto L045f;

		L4baa:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			goto L12c2;

		L4bba:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0xffff);
			if (this.oCPU.Flags.E) goto L4bc4;
			goto L4be2;

		L4bc4:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
			if (this.oCPU.Flags.E) goto L4bce;
			goto L4ff5;

		L4bce:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x6a);
			if (this.oCPU.Flags.GE) goto L4bd8;
			goto L4ff5;

		L4bd8:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
			if (this.oCPU.Flags.LE) goto L4be2;
			goto L4ff5;

		L4be2:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x128);
			if (this.oCPU.Flags.L) goto L4bed;
			goto L4bf7;

		L4bed:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x62);
			if (this.oCPU.Flags.E) goto L4bf7;
			goto L4e80;

		L4bf7:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4c09;
			goto L4c66;

		L4c09:
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106),
				(short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);

			// Instruction address 0x1d12:0x4c3d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(10 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))) -
					city.ShieldsCount,
				0, 999);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x14;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			goto L4cc9;

		L4c66:
			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x4ca0, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(10 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))) -
					city.ShieldsCount,
				0, 999);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)city.CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x15);
			if (this.oCPU.Flags.G) goto L4cc5;
			goto L4cc9;

		L4cc5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8),
				this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1));

		L4cc9:
			this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
			if (this.oCPU.Flags.E) goto L4cdb;
			goto L4cdf;

		L4cdb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8),
				this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1));

		L4cdf:
			// Instruction address 0x1d12:0x4ce7, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Cost to complete\n");

			if (city.CurrentProductionID >= 0)
			{
				// Instruction address 0x1d12:0x4d17, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Name);
			}
			else
			{
				// Instruction address 0x1d12:0x4d3e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Name);
			}

			// Instruction address 0x1d12:0x4d4e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": $");

			// Instruction address 0x1d12:0x4d6f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 10));

			// Instruction address 0x1d12:0x4d7f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\nTreasury: $");

			// Instruction address 0x1d12:0x4da6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, 10));

			// Instruction address 0x1d12:0x4db6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4dd0;
			goto L4df5;

		L4dd0:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L4de2;
			goto L4df5;

		L4de2:
			// Instruction address 0x1d12:0x4dea, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "CIVIL DISORDER\n");
			goto L4e18;

		L4df5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L4e08;
			goto L4e18;

		L4e08:
			// Instruction address 0x1d12:0x4e10, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Yes\n No\n");

		L4e18:
			// Instruction address 0x1d12:0x4e18, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x1d12:0x4e32, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 100, 80, 1);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L4e42;
			goto L4e78;

		L4e42:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L4e55;
			goto L4e78;

		L4e55:
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			city.ShieldsCount = (short)this.oCPU.CX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -= (short)this.oCPU.AX.Word;

		L4e78:
			// Instruction address 0x1d12:0x4e78, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			goto L045f;

		L4e80:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe6);
			if (this.oCPU.Flags.GE) goto L4e8b;
			goto L4e96;

		L4e8b:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
			if (this.oCPU.Flags.GE) goto L4e96;
			goto L4ea0;

		L4e96:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x63);
			if (this.oCPU.Flags.E) goto L4ea0;
			goto L4f37;

		L4ea0:
			city.StatusFlag &= 0xef;

			// Instruction address 0x1d12:0x4ead, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4ec4;
			goto L4ee2;

		L4ec4:			
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

		L4ee2:
			// Instruction address 0x1d12:0x4ee9, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);
			
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L4f11;
			goto L4f2f;

		L4f11:			
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L4f2f:
			// Instruction address 0x1d12:0x4f2f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			goto L045f;

		L4f37:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x69);
			if (this.oCPU.Flags.E) goto L4f41;
			goto L4f4a;

		L4f41:
			this.Var_2496 = 0;
			goto L4faf;

		L4f4a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x68);
			if (this.oCPU.Flags.E) goto L4f54;
			goto L4f5d;

		L4f54:
			this.Var_2496 = 1;
			goto L4faf;

		L4f5d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x6d);
			if (this.oCPU.Flags.E) goto L4f67;
			goto L4f70;

		L4f67:
			this.Var_2496 = 2;
			goto L4faf;

		L4f70:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x76);
			if (this.oCPU.Flags.E) goto L4f7a;
			goto L4f83;

		L4f7a:
			this.Var_2496 = 3;
			goto L4faf;

		L4f83:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x60);
			if (this.oCPU.Flags.GE) goto L4f8d;
			goto L4ff5;

		L4f8d:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe0);
			if (this.oCPU.Flags.L) goto L4f98;
			goto L4ff5;

		L4f98:
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x60);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

			this.Var_2496 = this.oCPU.AX.Word;

		L4faf:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			if (this.Var_2496 != 3)
				goto L4ff2;

			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oParent.CityView.F19_0000_0000(cityID, -1);

			this.oParent.Var_6b64 = 1;
			this.Var_2496 = 0;

			goto L045f;

		L4ff2:
			goto L12c2;

		L4ff5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x61);
			if (this.oCPU.Flags.E) goto L4fff;
			goto L520e;

		L4fff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x0);

		L5005:
			if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].Status & 0xcf) != 0)
				goto L5039;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L5032;
			goto L5039;

		L5032:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));
			goto L5005;

		L5039:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L5045;
			goto L504b;

		L5045:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x0);

		L504b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x12;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x64);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x74);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100), this.oCPU.AX.Word);

		L5078:
			// Instruction address 0x1d12:0x5088, size: 5
			F0_1d12_710d_FillRectangleWithPattern(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)), 16, 16);

			// Instruction address 0x1d12:0x5094, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x1d12:0x50b1, size: 5
			this.oParent.Segment_2aea.F0_2aea_0fb3(this.Var_6548_PlayerID,
				Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))],
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)));

			// Instruction address 0x1d12:0x50bd, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x1d12:0x50c5, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L50d2;
			goto L5078;

		L50d2:
			// Instruction address 0x1d12:0x50d2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc));
			goto L5121;

		L50e2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L5144;

		L50ee:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L5144;

		L50fa:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L5144;

		L5108:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L5144;

		L5116:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L5144;

		L5121:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L5129;
			goto L5108;

		L5129:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00);
			if (this.oCPU.Flags.NE) goto L5131;
			goto L50ee;

		L5131:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00);
			if (this.oCPU.Flags.NE) goto L5139;
			goto L50e2;

		L5139:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L5141;
			goto L50fa;

		L5141:
			goto L5116;

		L5144:
			// Instruction address 0x1d12:0x5151, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)),
				0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)) - 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0xd);
			if (this.oCPU.Flags.NE) goto L5167;
			goto L5171;

		L5167:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x20);
			if (this.oCPU.Flags.E) goto L5171;
			goto L51f4;

		L5171:
			if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].Status & 0x9) == 0)
				goto L51bc;

			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].RemainingMoves = 
				(short)(this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].TypeID].MoveCount * 3);

		L51bc:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].Status &= 0x30;
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].GoToPosition.X = -1;

		L51f4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x1b);
			if (this.oCPU.Flags.E) goto L51fe;
			goto L504b;

		L51fe:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;
			goto L12c2;

		L520e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x73);
			if (this.oCPU.Flags.E) goto L5218;
			goto L532e;

		L5218:
			this.oCPU.TESTByte(city.StatusFlag, 0x80);
			if (this.oCPU.Flags.E) goto L522a;
			goto L532e;

		L522a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x0);

		L5230:
			// Instruction address 0x1d12:0x5258, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				252,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))) * 6) + 3,
				56, 7, 9, 1);

			// Instruction address 0x1d12:0x5264, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x1d12:0x5294, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				252,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))) * 6) + 3,
				56, 7, 1, 9);

			// Instruction address 0x1d12:0x52a0, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x1d12:0x52a8, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L52b5;
			goto L5230;

		L52b5:
			// Instruction address 0x1d12:0x52b5, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc));
			goto L52e0;

		L52c5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L52f3;

		L52d1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			goto L52f3;

		L52e0:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L52e8;
			goto L52d1;

		L52e8:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L52f3;
			goto L52c5;

		L52f3:
			// Instruction address 0x1d12:0x5301, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)),
				0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb4)) - 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0xd);
			if (this.oCPU.Flags.NE) goto L5317;
			goto L5740;

		L5317:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x20);
			if (this.oCPU.Flags.E) goto L5740;
			goto L5324;

		L5324:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)), 0x1b);
			if (this.oCPU.Flags.E) goto L532e;
			goto L5230;

		L532e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x31);
			if (this.oCPU.Flags.GE) goto L5338;
			goto L53c8;

		L5338:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x39);
			if (this.oCPU.Flags.LE) goto L5342;
			goto L53c8;

		L5342:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x31);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L5359;
			goto L045f;

		L5359:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x5);
			if (this.oCPU.Flags.GE) goto L536b;
			goto L53ad;

		L536b:
			// Instruction address 0x1d12:0x536f, size: 5
			F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x3);
			if (this.oCPU.Flags.L) goto L5385;
			goto L539a;

		L5385:
			// Instruction address 0x1d12:0x538f, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) + 1));

			goto L53aa;

		L539a:
			// Instruction address 0x1d12:0x53a2, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 1);

		L53aa:
			goto L53b5;

		L53ad:
			this.oParent.MSCAPI.strcpy(0xba06, "A City must have five\npopulation units to support\ntaxmen or scientists.\n");
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 32, 32, 1);

			goto L045f;

		L53b5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;
			goto L12c2;

		L53c8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x70);
			if (this.oCPU.Flags.E) goto L53d2;
			goto L563f;

		L53d2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8)), 0x0);
			if (this.oCPU.Flags.E) goto L53dc;
			goto L53ed;

		L53dc:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8), 0x1);

		L53ed:
			// Instruction address 0x1d12:0x541d, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)) << 4) + 160,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)) << 4) + 56,
				16, 16, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x1d12:0x5449, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)) * 16 + 160,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)) * 16 + 56,
				15, 15, 15);

			// Instruction address 0x1d12:0x5455, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x1d12:0x548d, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 16, 16, this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)) << 4) + 160,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)) << 4) + 56);

			// Instruction address 0x1d12:0x5499, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			this.oParent.Var_6b64 = 1;

			// Instruction address 0x1d12:0x54a7, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L54b4;
			goto L53ed;

		L54b4:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x54c4, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			goto L551f;

		L54d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			goto L556a;

		L54db:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			goto L556a;

		L54e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			goto L556a;

		L54ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			goto L556a;

		L54f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			goto L556a;

		L54ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			goto L556a;

		L550a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			goto L556a;

		L5511:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe))));
			goto L556a;

		L551f:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00);
			if (this.oCPU.Flags.NE) goto L5527;
			goto L550a;

		L5527:
			if (this.oCPU.Flags.LE) goto L552c;
			goto L5547;

		L552c:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4700);
			if (this.oCPU.Flags.NE) goto L5534;
			goto L5511;

		L5534:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L553c;
			goto L54d4;

		L553c:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4900);
			if (this.oCPU.Flags.NE) goto L556a;
			goto L54db;

		L5547:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00);
			if (this.oCPU.Flags.NE) goto L554f;
			goto L54e6;

		L554f:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4f00);
			if (this.oCPU.Flags.NE) goto L5557;
			goto L54ff;

		L5557:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L555f;
			goto L54f8;

		L555f:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5100);
			if (this.oCPU.Flags.NE) goto L556a;
			goto L54ed;

		L556a:
			// Instruction address 0x1d12:0x556e, size: 5
			this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.LE) goto L557e;
			goto L55f5;

		L557e:
			// Instruction address 0x1d12:0x5582, size: 5
			this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.LE) goto L5592;
			goto L55f5;

		L5592:
			// Instruction address 0x1d12:0x5596, size: 5
			this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)));

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			// Instruction address 0x1d12:0x55a4, size: 5
			this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)));

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.L) goto L55b6;
			goto L55f5;

		L55b6:
			this.oCPU.AX.Word = (ushort)((short)city.Position.X);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6)));

			this.oCPU.BX.Word = (ushort)((short)city.Position.Y);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe)));

			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.AX.Word, this.oCPU.BX.Word];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L55f5;
			goto L5605;

		L55f5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe), this.oCPU.AX.Word);

		L5605:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0xd);
			if (this.oCPU.Flags.NE) goto L560f;
			goto L5619;

		L560f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x20);
			if (this.oCPU.Flags.E) goto L5619;
			goto L562c;

		L5619:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);
			goto L5aa6;

		L562c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x1b);
			if (this.oCPU.Flags.E) goto L5636;
			goto L53ed;

		L5636:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb8), 0x0);
			goto L045f;

		L563f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x4d);
			if (this.oCPU.Flags.E) goto L5649;
			goto L5671;

		L5649:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x2);
			if (this.oCPU.Flags.NE) goto L5653;
			goto L5671;

		L5653:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca), 
				this.oCPU.XORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x1));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			goto L12c2;

		L5671:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf0)), 0x72);
			if (this.oCPU.Flags.NE) goto L567b;
			goto L56a6;

		L567b:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
			if (this.oCPU.Flags.E) goto L5685;
			goto L56c8;

		L5685:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe7);
			if (this.oCPU.Flags.GE) goto L5690;
			goto L56c8;

		L5690:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0xbe);
			if (this.oCPU.Flags.G) goto L569b;
			goto L56c8;

		L569b:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
			if (this.oCPU.Flags.L) goto L56a6;
			goto L56c8;

		L56a6:
			// Instruction address 0x1d12:0x56a6, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oParent.Overlay_23.F23_0000_0000(cityID);

			this.oParent.Var_6b64 = 1;

			goto L045f;

		L56c8:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
			if (this.oCPU.Flags.E) goto L56d2;
			goto L5cc2;

		L56d2:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x120);
			if (this.oCPU.Flags.GE) goto L56dd;
			goto L5719;

		L56dd:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x60);
			if (this.oCPU.Flags.L) goto L56e7;
			goto L5719;

		L56e7:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x58);
			if (this.oCPU.Flags.G) goto L56f1;
			goto L5719;

		L56f1:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x2);
			if (this.oCPU.Flags.NE) goto L56fb;
			goto L5719;

		L56fb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca), 
				this.oCPU.XORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xca)), 0x1));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			goto L12c2;

		L5719:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x12c);
			if (this.oCPU.Flags.GE) goto L5724;
			goto L58ac;

		L5724:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x5e);
			if (this.oCPU.Flags.L) goto L572e;
			goto L58ac;

		L572e:
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.AX.Word);

		L5740:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xda));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), this.oCPU.AX.Word);
			goto L574f;

		L574b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L574f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x18);
			if (this.oCPU.Flags.L) goto L5759;
			goto L58ac;

		L5759:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L5783;
			goto L574b;

		L5783:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L5793;
			goto L574b;

		L5793:
			this.oCPU.TESTByte(city.StatusFlag, 0x80);
			if (this.oCPU.Flags.E) goto L57a5;
			goto L574b;

		L57a5:
			// Instruction address 0x1d12:0x57ad, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Do you want to sell\nyour ");

			// Instruction address 0x1d12:0x57c4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Name);

			// Instruction address 0x1d12:0x57d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " for ");

			// Instruction address 0x1d12:0x5802, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(10 *
					this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Price, 10));

			// Instruction address 0x1d12:0x5812, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "$?\n No.\n Yes.\n");

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x1d12:0x5823, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1d12:0x5834, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 128, 80, 1);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L5844;
			goto L58a1;

		L5844:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins += 
				(short)(10 * this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Price);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			uint uiTemp = (uint)((long)city.BuildingFlags0 | ((long)city.BuildingFlags1 << 16));
			uint uiTemp1 = (uint)((long)this.oCPU.CX.Word | ((long)this.oCPU.BX.Word << 16));
			uiTemp -= uiTemp1;
			city.BuildingFlags0 = (ushort)(uiTemp & 0xffff);
			city.BuildingFlags1 = (ushort)((uiTemp & 0xffff0000) >> 16);

			city.StatusFlag |= 0x80;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.E) goto L589b;
			goto L58a1;

		L589b:
			this.oParent.Var_6b64 = 1;

		L58a1:
			// Instruction address 0x1d12:0x58a1, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			goto L045f;

		L58ac:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xc8);
			if (this.oCPU.Flags.L) goto L58b7;
			goto L596b;

		L58b7:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x14);
			if (this.oCPU.Flags.L) goto L58c1;
			goto L596b;

		L58c1:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x5);
			if (this.oCPU.Flags.GE) goto L58d3;
			goto L5953;

		L58d3:
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x0);
			if (this.oCPU.Flags.GE) goto L5902;
			goto L045f;

		L5902:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L045f;
			goto L5911;

		L5911:
			// Instruction address 0x1d12:0x5915, size: 5
			F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x3);
			if (this.oCPU.Flags.L) goto L592b;
			goto L5940;

		L592b:
			// Instruction address 0x1d12:0x5935, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)) + 1));

			goto L5950;

		L5940:
			// Instruction address 0x1d12:0x5948, size: 5
			F0_1d12_6d6e(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 1);

		L5950:
			goto L595b;

		L5953:
			this.oParent.MSCAPI.strcpy(0xba06, "A City must have five\npopulation units to support\ntaxmen or scientists.\n");
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 32, 32, 1);

			goto L045f;

		L595b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;
			goto L12c2;

		L596b:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x64);
			if (this.oCPU.Flags.GE) goto L5975;
			goto L5a60;

		L5975:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x2580);
			if (this.oCPU.Flags.L) goto L5980;
			goto L5a60;

		L5980:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
			if (this.oCPU.Flags.GE) goto L598a;
			goto L5a60;

		L598a:
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x74);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x64);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L59cd;
			goto L5a60;

		L59cd:
			if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].Status & 0x9) == 0)
				goto L5a18;

			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].RemainingMoves =
				(short)(this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].TypeID].MoveCount * 3);

		L5a18:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].Status &= 0x30;
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))]].GoToPosition.X = -1;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			goto L12c2;

		L5a60:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x18);
			if (this.oCPU.Flags.GE) goto L5a6a;
			goto L5cc2;

		L5a6a:
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x68);
			if (this.oCPU.Flags.L) goto L5a74;
			goto L5cc2;

		L5a74:
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x18);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc), this.oCPU.AX.Word);

		L5aa6:
			// Instruction address 0x1d12:0x5aae, size: 5
			F0_1d12_000a(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xfc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea), this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0xffff);
			if (this.oCPU.Flags.NE) goto L5ac4;
			goto L045f;

		L5ac4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), 0x14);
			if (this.oCPU.Flags.L) goto L5ace;
			goto L045f;

		L5ace:
			this.oCPU.AX.Word = (ushort)((short)(city.Position.X +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X));

			this.oCPU.BX.Word = (ushort)((short)(city.Position.Y +
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y));

			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.AX.Word, this.oCPU.BX.Word];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L5b13;
			goto L045f;

		L5b13:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
			this.oParent.Var_70da_Arr[1] = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.Var_70da_Arr[2] = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word &= city.WorkerFlags0;
			this.oCPU.BX.Word &= city.WorkerFlags1;

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L5b4a;
			goto L5b6e;

		L5b4a:
			if (Arr_a6[this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X + 2,
				this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y + 2] != 0x0)
				goto L12c2;

		L5b6e:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			city.WorkerFlags0 ^= this.oCPU.CX.Word;
			city.WorkerFlags1 ^= this.oCPU.BX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word &= city.WorkerFlags0;
			this.oCPU.BX.Word &= city.WorkerFlags1;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L5bbb;
			goto L5be5;

		L5bbb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae))));

			// Instruction address 0x1d12:0x5bc9, size: 5
			F0_1d12_692d(cityID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea)), flag);

			this.oCPU.CMPWord(this.oParent.Var_e8b8, 0x0);
			if (this.oCPU.Flags.NE)
			{
				this.oParent.Var_e8b8--;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50),
					this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));
			}
			goto L5c78;

		L5be5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x0);
			goto L5bf6;

		L5bf2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L5bf6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x3);
			if (this.oCPU.Flags.L) goto L5c00;
			goto L5c45;

		L5c00:
			// Instruction address 0x1d12:0x5c28, size: 5
			F0_1d12_6abc(
				city.Position.X +
					this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X,
				city.Position.Y +
					this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc), this.oCPU.AX.Word);

			this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))] =
				(ushort)((short)this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))] -
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xcc)));

			goto L5bf2;

		L5c45:
			// Instruction address 0x1d12:0x5c69, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(
				city.Position.X +
					this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].X,
				city.Position.Y +
					this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xea))].Y);

			this.oParent.Var_e8b8++;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

		L5c78:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = 0x1a;
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = city.WorkerFlags0;
			this.oCPU.BX.Word = city.WorkerFlags1;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0xffff);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x3ff);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			city.WorkerFlags0 = this.oCPU.AX.Word;
			city.WorkerFlags1 = this.oCPU.DX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xae)), 0x0);
			if (this.oCPU.Flags.G) goto L045f;
			goto L12c2;

		L5cbd:
			// Instruction address 0x1d12:0x5cbd, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

		L5cc2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc2));
			this.oParent.Var_d4cc_XPos = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd0));
			this.oParent.Var_d75e_YPos = (short)this.oCPU.AX.Word;

		L5cd0:
			this.oCPU.AX.Word = (ushort)flag;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L5cdb;
			goto L68cc;

		L5cdb:
			if (this.Var_6548_PlayerID == 0)
				goto L62d8;

			this.oCPU.AX.Word = this.oParent.Var_70e2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.L) goto L5cfa;
			goto L5f3f;

		L5cfa:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L5d0c;
			goto L5df3;

		L5d0c:
			// Instruction address 0x1d12:0x5d14, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Civil Disorder in\n");

			// Instruction address 0x1d12:0x5d1f, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x5d2f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "! Mayor\nflees in panic.\n");

			// Instruction address 0x1d12:0x5d3b, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.NE) goto L5d4d;
			goto L5d9f;

		L5d4d:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L5d5f;
			goto L5d9f;

		L5d5f:
			this.oCPU.CMPWord(this.oParent.Var_6b92, 0x0);
			if (this.oCPU.Flags.E) goto L5d69;
			goto L5d9f;

		L5d69:
			this.oParent.CityView.F19_0000_0000(cityID, -2);
			
			this.oParent.CityView.F19_0000_18c1_CivilDisorderAnimation();

			// Instruction address 0x1d12:0x5d89, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x1d12:0x5d91, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oParent.Var_6b92 = 1;
			goto L5db9;

		L5d9f:
			this.oParent.Var_2f9e_Unknown = 0x4;

			// Instruction address 0x1d12:0x5db1, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L5db9:
			// Instruction address 0x1d12:0x5dbd, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L5dd7;
			goto L5df3;

		L5dd7:
			this.oParent.Var_b1e8 = 1;

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L5de7;
			goto L5df3;

		L5de7:
			this.oParent.Help.F4_0000_02d3(0x2708);

		L5df3:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L5e05;
			goto L5eb4;

		L5e05:
			city.StatusFlag |= 1;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L5e24;
			goto L5ea1;

		L5e24:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L5e36;
			goto L5e54;

		L5e36:			
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

		L5e54:
			// Instruction address 0x1d12:0x5e5b, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);
			
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L5e83;
			goto L5ea1;

		L5e83:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L5ea1:
			// Instruction address 0x1d12:0x5ea9, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			goto L5f3c;

		L5eb4:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5) goto L5ec4;
			goto L5f3c;

		L5ec4:
			// Instruction address 0x1d12:0x5ec8, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

			// Instruction address 0x1d12:0x5ed8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Discontented citizens of\n");

			// Instruction address 0x1d12:0x5ee3, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x5ef3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " revolt:\nGovernment Collapses!\n");

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L5f20;

			this.oParent.Overlay_21.F21_0000_0000(cityID);

			this.oParent.GameState.Players[this.Var_6548_PlayerID].Diplomacy[0] |= 4;

		L5f20:
			// Instruction address 0x1d12:0x5f28, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(this.Var_6548_PlayerID, 0);
			
			// Instruction address 0x1d12:0x5f34, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L5f3c:
			goto L606c;

		L5f3f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.GE) goto L5f49;
			goto L604f;

		L5f49:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L5f5b;
			goto L604f;

		L5f5b:
			city.StatusFlag &= 0xfe;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L5f7a;
			goto L5fc2;

		L5f7a:
			this.oParent.Var_2f9e_Unknown = 0x4;

			// Instruction address 0x1d12:0x5f88, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Order restored\nin ");

			// Instruction address 0x1d12:0x5f93, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x5fa3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x1d12:0x5fb7, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			goto L603f;

		L5fc2:
			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L5fd4;
			goto L5ff2;

		L5fd4:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

		L5ff2:
			// Instruction address 0x1d12:0x5ff9, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

			this.oCPU.CX.Word = this.oCPU.AX.Word;

			city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

			this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L6021;
			goto L603f;

		L6021:			
			this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

		L603f:
			// Instruction address 0x1d12:0x6047, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

		L604f:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L605f;
			goto L606c;

		L605f:
			this.oCPU.AX.Word = this.oParent.Var_e17a;
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins += (short)this.oCPU.AX.Word;

		L606c:
			this.oCPU.CMPWord(this.oParent.Var_70e4, 0x0);
			if (this.oCPU.Flags.E) goto L6076;
			goto L6213;

		L6076:
			this.oCPU.CMPByte((byte)city.ActualSize, 0x2);
			if (this.oCPU.Flags.G) goto L6088;
			goto L6213;

		L6088:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_70e2);
			if (this.oCPU.Flags.LE) goto L60a4;
			goto L6213;

		L60a4:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60b4;
			goto L6213;

		L60b4:
			this.oCPU.TESTByte(city.StatusFlag, 0x40);
			if (this.oCPU.Flags.E) goto L60c6;
			goto L61ac;

		L60c6:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L60d8;
			goto L619c;

		L60d8:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60e8;
			goto L619c;

		L60e8:
			// Instruction address 0x1d12:0x60f0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1d12:0x610c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x1d12:0x611c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "'\nday celebrated in\n");

			// Instruction address 0x1d12:0x6127, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x6137, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			// Instruction address 0x1d12:0x6143, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x22, 0);

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.NE) goto L6155;
			goto L6185;

		L6155:
			this.oParent.CityView.F19_0000_0000(cityID, -2);
			
			this.oParent.CityView.F19_0000_1ae1();

			// Instruction address 0x1d12:0x6175, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x1d12:0x617d, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L6190;

		L6185:
			this.oParent.Overlay_21.F21_0000_0000(cityID);

		L6190:
			// Instruction address 0x1d12:0x6194, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L619c:
			city.StatusFlag |= 0x40;
			goto L6210;

		L61ac:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L61bc;
			goto L6210;

		L61bc:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oParent.Var_70da_Arr[0]);
			if (this.oCPU.Flags.L) goto L61df;
			goto L6210;

		L61df:
			this.oCPU.CMPByte((byte)city.ActualSize, 0xa);
			if (this.oCPU.Flags.GE) goto L61f1;
			goto L6204;

		L61f1:
			this.oCPU.TESTWord(city.BuildingFlags0, 0x100);
			if (this.oCPU.Flags.NE) goto L6204;
			goto L6210;

		L6204:
			city.ActualSize++;

		L6210:
			goto L62d8;

		L6213:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8)), 0x0);
			if (this.oCPU.Flags.GE) goto L621d;
			goto L62d8;

		L621d:
			this.oCPU.TESTByte(city.StatusFlag, 0x40);
			if (this.oCPU.Flags.NE) goto L622f;
			goto L62d8;

		L622f:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L6241;
			goto L62cb;

		L6241:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L6251;
			goto L62cb;

		L6251:
			// Instruction address 0x1d12:0x6255, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x23, 0);

			// Instruction address 0x1d12:0x6265, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1d12:0x6281, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x1d12:0x6291, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "'\ncelebration canceled\nin ");

			// Instruction address 0x1d12:0x629c, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x62ac, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oParent.Overlay_21.F21_0000_0000(cityID);
			
			// Instruction address 0x1d12:0x62c3, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L62cb:
			city.StatusFlag &= 0xbf;

		L62d8:
			this.oCPU.AX.Word = this.oParent.Var_70e6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L635d;

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID != -1) goto L62f5;
			goto L630d;

		L62f5:
			// Instruction address 0x1d12:0x62fd, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID,
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
				goto L630d;

			goto L6327;

		L630d:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID == -1) goto L6317;
			goto L635d;

		L6317:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress != 0) goto L6327;
			goto L635d;

		L6327:
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID = -1;
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x8);
			if (this.oCPU.Flags.NE) goto L6337;
			goto L6351;

		L6337:
			// Instruction address 0x1d12:0x6337, size: 5
			this.oParent.Segment_11a8.F0_11a8_0280();
			
			// Instruction address 0x1d12:0x6344, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);
			
			// Instruction address 0x1d12:0x634c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0294();

		L6351:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;

		L635d:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), 0x0);
			}

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)this.oCPU.AX.Word;

			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID && this.oParent.GameState.DifficultyLevel == 0)
			{
				if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID >= 0 &&
					(this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID] & 7) != 0)
				{
					this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress +=
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
				}
			}

			// Instruction address 0x1d12:0x63c2, size: 5
			F0_1d12_6c97(this.Var_6548_PlayerID, 0x14);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L63d2;
			goto L63e5;

		L63d2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)this.oCPU.AX.Word;

		L63e5:
			if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				goto L63fb;

			this.oCPU.AX.Word = 0xe;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.DifficultyLevel);
			goto L6403;

		L63fb:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);

		L6403:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_d2de;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4)), this.oCPU.AX.Word));

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L6441;

			this.oCPU.AX.Word = 0xb;
			this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4)));
			if (this.oCPU.Flags.G) goto L6430;
			goto L6441;

		L6430:
			this.oCPU.AX.Word = 0xb;
			this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4), this.oCPU.AX.Word);

		L6441:
			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L6457;

			this.oCPU.CMPWord(this.oParent.Var_b1e8, 0x0);
			if (this.oCPU.Flags.E) goto L6457;
			goto L64b8;

		L6457:
			if (this.oParent.GameState.Year < 0)
			{
				this.oCPU.CX.Word = 0x1;
			}
			else
			{
				this.oCPU.CX.Word = 0x2;
			}

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xf4)));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L6488;
			goto L64b8;

		L6488:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x8);
			if (this.oCPU.Flags.NE) goto L649e;
			goto L64b8;

		L649e:
			// Instruction address 0x1d12:0x649e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0280();

			// Instruction address 0x1d12:0x64ab, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);
			
			// Instruction address 0x1d12:0x64b3, size: 5
			this.oParent.Segment_11a8.F0_11a8_0294();

		L64b8:
			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oParent.Var_70e2);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Score += (short)this.oCPU.AX.Word;

			if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L68cc;

			this.oCPU.AX.Word = this.oParent.Var_70da_Arr[1];
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oParent.Var_6c98;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x14);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)city.ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.Var_b882);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.DifficultyLevel);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x100);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6530, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.AX.Word));

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L6545;
			goto L6640;

		L6545:
			// Instruction address 0x1d12:0x6549, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(20));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].X +
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe8))].Y +
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6581, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x40);
			if (this.oCPU.Flags.E) goto L6590;
			goto L6640;

		L6590:
			// Instruction address 0x1d12:0x6598, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L65a8;
			goto L6640;

		L65a8:
			// Instruction address 0x1d12:0x65b0, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L65bf;
			goto L6640;

		L65bf:
			// Instruction address 0x1d12:0x65c7, size: 5
			F0_1d12_6d33(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			// Instruction address 0x1d12:0x65e3, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)) - 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)) - 6);

			// Instruction address 0x1d12:0x65f3, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd2)));

			this.oParent.Var_2f9e_Unknown = 0x6;

			// Instruction address 0x1d12:0x6609, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Pollution near ");

			// Instruction address 0x1d12:0x6614, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x6624, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x1d12:0x6638, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

		L6640:
			this.oCPU.TESTByte(city.StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L6652;
			goto L672d;

		L6652:
			this.oCPU.TESTWord(city.BuildingFlags1, 0x10);
			if (this.oCPU.Flags.NE) goto L6665;
			goto L672d;

		L6665:
			// Instruction address 0x1d12:0x6669, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L6679;
			goto L672d;

		L6679:
			// Instruction address 0x1d12:0x6681, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.FusionPower);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
				goto L6691;

			goto L672d;

		L6691:
			// Instruction address 0x1d12:0x66a5, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)) - 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)) - 6);

			this.oParent.Overlay_22.F22_0000_0967(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));

			// Instruction address 0x1d12:0x66c5, size: 5
			this.oParent.Segment_29f3.F0_29f3_0ec3(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe4)));
			
			city.BuildingFlags0 &= 0xffff;
			city.BuildingFlags1 &= 0xffef;

			// Instruction address 0x1d12:0x66e3, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

			// Instruction address 0x1d12:0x66f3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Nuclear Catastrophe\nin ");

			// Instruction address 0x1d12:0x66fe, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x670e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\nContamination feared!\n");

			this.oParent.Overlay_21.F21_0000_0000(cityID);
			
			// Instruction address 0x1d12:0x6725, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L672d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 0x1);
			goto L673a;

		L6736:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc))));

		L673a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x18);
			if (this.oCPU.Flags.L) goto L6744;
			goto L68cc;

		L6744:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L676e;
			goto L6736;

		L676e:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L677e;
			goto L6736;

		L677e:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -=
				(short)this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Maintenance;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)), 0x1);
			if (this.oCPU.Flags.E) goto L679f;
			goto L680b;

		L679f:
			if (this.oParent.GameState.DifficultyLevel >= 2) goto L67a9;
			goto L67b3;

		L67a9:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

		L67b3:
			if (this.oParent.GameState.DifficultyLevel >= 4) goto L67bd;
			goto L67c7;

		L67bd:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

		L67c7:
			// Instruction address 0x1d12:0x67cf, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Gunpowder);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L67df;

			goto L67e9;

		L67df:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

		L67e9:
			// Instruction address 0x1d12:0x67f1, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Combustion);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L6801;

			goto L680b;

		L6801:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

		L680b:
			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins < 0) goto L681b;
			goto L6736;

		L681b:
			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins = 0;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

			city.BuildingFlags0 &= this.oCPU.CX.Word;
			city.BuildingFlags1 &= this.oCPU.BX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1d12:0x6856, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1d12:0x6866, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\ncan't maintain\n");

			// Instruction address 0x1d12:0x687d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Name);

			// Instruction address 0x1d12:0x688d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_Unknown = 0x4;

			// Instruction address 0x1d12:0x68a7, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins +=
				(short)(10 * this.oParent.GameState.BuildingDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xbc)) + 1].Price);

			goto L6736;

		L68cc:
			this.oCPU.TESTByte(city.StatusFlag, 0x4);
			if (this.oCPU.Flags.NE) goto L68de;
			goto L690f;

		L68de:
			// ??? this playerID reference needs to be checked!
			// Instruction address 0x1d12:0x68f4, size: 5
			this.oParent.Segment_1866.F0_1866_18d0(city.PlayerID,
				city.Position.X,
				city.Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L6904;
			goto L690f;

		L6904:
			// Instruction address 0x1d12:0x6907, size: 5
			this.oParent.Segment_1866.F0_1866_00c6(cityID);

		L690f:
			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x1d12:0x6918, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = this.oParent.Var_70e2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);

		L6927:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_0045");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="cityOffset"></param>
		/// <param name="flag"></param>
		public void F0_1d12_692d(short cityID, ushort cityOffset, short flag)
		{

			this.oCPU.Log.EnterBlock($"F0_1d12_692d({cityID}, {cityOffset}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[cityID].Position.X + this.oParent.CityOffsets[cityOffset].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[cityID].Position.Y + this.oParent.CityOffsets[cityOffset].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			if (flag != 1 || flag < 0)
				goto L69bb;

			// Instruction address 0x1d12:0x696f, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L6981:
			// Instruction address 0x1d12:0x698b, size: 3
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L6981;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x4);
			if (this.oCPU.Flags.G) goto L69a8;
			this.oCPU.AX.Word = 0x8;
			goto L69b6;

		L69a8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x6);
			if (this.oCPU.Flags.G) goto L69b3;
			this.oCPU.AX.Word = 0x5;
			goto L69b6;

		L69b3:
			this.oCPU.AX.Word = 0x3;

		L69b6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			goto L69e5;

		L69bb:
			this.Var_2494 = 1;

			// Instruction address 0x1d12:0x69dd, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				(ushort)this.oParent.GameState.Cities[cityID].PlayerID);

		L69e5:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			goto L6a00;

		L69f2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L69f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			goto L6a22;

		L69fd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6a00:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.GE) goto L6a76;

			// Instruction address 0x1d12:0x6a10, size: 3
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] = 
				(ushort)((short)this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] + (short)this.oCPU.AX.Word);

		L6a22:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.LE) goto L69fd;

			if (flag != 1 || flag < 0)
				goto L69fd;

			// Instruction address 0x1d12:0x6a5d, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				161 + (this.oParent.CityOffsets[cityOffset].X * 16) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				57 + (this.oParent.CityOffsets[cityOffset].Y * 16) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x8) << 1) + 0xd4ce)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L69f2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8));
			goto L69f8;

		L6a76:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L6ab0;

			if (flag != 1 || flag < 0)
				goto L6ab0;

			// Instruction address 0x1d12:0x6aa8, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				165 + (this.oParent.CityOffsets[cityOffset].X * 16),
				61 + (this.oParent.CityOffsets[cityOffset].Y * 16),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

		L6ab0:
			this.Var_2494 = 0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_692d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_1d12_6abc(int xPos, int yPos, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6abc({xPos}, {yPos}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1d12:0x6ac9, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L6ad8;
			goto L6c90;

		L6ad8:
			// Instruction address 0x1d12:0x6ade, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6af0, size: 5
			this.oParent.Segment_2aea.F0_2aea_1836(xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L6b0d;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = param3;

			switch (param3)
			{
				case 0:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Food;
					break;

				case 1:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Production;
					break;

				case 2:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Trade;
					break;

				default:
					throw new Exception("Unknown terrain field");
			}

			goto L6b1c;

		L6b0d:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = param3;

			switch (param3)
			{
				case 0:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Food;
					break;

				case 1:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Production;
					break;

				case 2:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Trade;
					break;

				default:
					throw new Exception("Unknown terrain field");
			}

		L6b1c:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6b26, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L6b53;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.G) goto L6b43;
			this.oCPU.AX.Word = 0x2;
			goto L6b46;

		L6b43:
			this.oCPU.AX.Word = 0x4;

		L6b46:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1);
			if (this.oCPU.Flags.E) goto L6b53;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L6b53:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xa);
			if (this.oCPU.Flags.E) goto L6baa;
			this.oCPU.CMPWord(param3, 0x0);
			if (this.oCPU.Flags.NE) goto L6b77;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x2);
			if (this.oCPU.Flags.E) goto L6b77;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xffff;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.TerrainMultipliers[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Multi1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6b77:
			this.oCPU.CMPWord(param3, 0x1);
			if (this.oCPU.Flags.NE) goto L6b95;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.E) goto L6b95;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xffff;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 
				(ushort)this.oParent.GameState.TerrainMultipliers[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Multi3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6b95:
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6baa;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.E) goto L6baa;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.G) goto L6baa;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6baa:
			this.oCPU.CMPWord(param3, 0x1);
			if (this.oCPU.Flags.NE) goto L6bd6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.E) goto L6bbc;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xb);
			if (this.oCPU.Flags.NE) goto L6bd6;

		L6bbc:
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)xPos);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xb;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)yPos);
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.TESTByte(this.oCPU.CX.Low, 0x2);
			if (this.oCPU.Flags.E) goto L6bd6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L6bd6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6bf6;
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6bf6;

			// Instruction address 0x1d12:0x6be7, size: 3
			F0_1d12_6cf3(3);

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.Var_653e_CityID);
			if (this.oCPU.Flags.NE) goto L6bf6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6bf6:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.E) goto L6c07;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6c07:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x2);
			if (this.oCPU.Flags.LE) goto L6c39;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.Var_653e_CityID].StatusFlag, 0x40);
			if (this.oCPU.Flags.NE) goto L6c39;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType <= 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			}

			this.oCPU.CMPWord(this.Var_2494, 0x0);
			if (this.oCPU.Flags.E) goto L6c39;

			this.oParent.Var_e3c2 -= 2;

		L6c39:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6c77;
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6c77;
			this.oCPU.CMPWord(this.Var_2494, 0x0);
			if (this.oCPU.Flags.E) goto L6c50;
			
			this.oParent.Var_db42++;

		L6c50:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.Var_653e_CityID].StatusFlag, 0x40);
			if (this.oCPU.Flags.E) goto L6c65;
			this.oCPU.AX.Word = 0x2;
			goto L6c68;

		L6c65:
			this.oCPU.AX.Word = 0x4;

		L6c68:
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
			if (this.oCPU.Flags.G) goto L6c77;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6c77:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x40);
			if (this.oCPU.Flags.E) goto L6c89;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L6c89:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L6c92;

		L6c90:
			this.oCPU.AX.Word = 0;

		L6c92:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6abc");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		public ushort F0_1d12_6c97(short playerID, short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6c97({playerID}, {wonderID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L6ca7;

		L6ca4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6ca7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L6cc9;

			this.oCPU.BX.Word = (ushort)wonderID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1d12:0x6cb9, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10fe)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L6ca4;

		L6cc5:
			this.oCPU.AX.Word = 0;
			goto L6cef;

		L6cc9:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.WonderCityID[wonderID];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L6cc5;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].PlayerID != playerID) goto L6cc5;

			this.oCPU.AX.Word = 0x1;

		L6cef:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6c97");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Returns a CityID that has a Wonder
		/// </summary>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		public ushort F0_1d12_6cf3(short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6cf3({wonderID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L6d03;

		L6d00:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6d03:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L6d26;

			this.oCPU.BX.Word = (ushort)wonderID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1d12:0x6d15, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10fe)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L6d00;

			this.oCPU.AX.Word = 0xffff;
			goto L6d2f;

		L6d26:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.WonderCityID[wonderID];

		L6d2f:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6cf3");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1d12_6d33(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6d33({xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1d12:0x6d3c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x40);
			if (this.oCPU.Flags.NE) goto L6d6c;

			// Instruction address 0x1d12:0x6d52, size: 5
			this.oParent.Segment_2aea.F0_2aea_1653(0x40, xPos, yPos);

			// Instruction address 0x1d12:0x6d60, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(xPos, yPos);
			
			oParent.GameState.PollutedSquareCount++;

		L6d6c:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6d33");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F0_1d12_6d6e(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6d6e({param1}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.CMPWord(param1, 0x8);
			if (this.oCPU.Flags.GE) goto L6d9e;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.CX.Low = (byte)(param1 * 2);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oParent.GameState.Cities[this.Var_653e_CityID].WorkerFlags2 &= this.oCPU.AX.Word;
			
			this.oCPU.AX.Word = param2;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oParent.GameState.Cities[this.Var_653e_CityID].WorkerFlags2 |= this.oCPU.AX.Word;

		L6d9e:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6d6e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F0_1d12_6da1(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6da1({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CMPWord(param1, 0x8);
			if (this.oCPU.Flags.L) goto L6daf;
			this.oCPU.AX.Word = 0x1;
			goto L6dca;

		L6daf:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oParent.GameState.Cities[this.Var_653e_CityID].WorkerFlags2;
			this.oCPU.CX.Low = (byte)(param1 * 2);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x3);

		L6dca:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6da1");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F0_1d12_6dcc(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dcc({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L6ddc:
			// Instruction address 0x1d12:0x6de0, size: 3
			F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, param1);
			if (this.oCPU.Flags.NE) goto L6dee;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6dee:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L6ddc;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6dcc");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="param2"></param>
		public void F0_1d12_6dfe(short cityID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dfe({cityID}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1d12:0x6e16, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70e2, 0, this.oParent.GameState.Cities[cityID].ActualSize);

			this.oParent.Var_70e2 = this.oCPU.AX.Word;
			goto L6e34;

		L6e23:
			this.oCPU.AX.Word = this.Var_6542;
			this.oCPU.CMPWord(this.oParent.Var_70e4, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L6e3b;
			this.Var_6542--;
			this.oParent.Var_70e4++;

		L6e34:
			this.oCPU.CMPWord(this.Var_6542, 0x0);
			if (this.oCPU.Flags.NE) goto L6e23;

		L6e3b:
			// Instruction address 0x1d12:0x6e98, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70e4,
				0, this.oParent.GameState.Cities[cityID].ActualSize);

			goto L6e94;

		L6e4e:
			this.oCPU.CMPWord(this.Var_6542, 0x0);
			if (this.oCPU.Flags.E) goto L6e5b;
			this.Var_6542--;
			goto L6e7f;

		L6e5b:
			this.oParent.Var_70e2--;
			
			// Instruction address 0x1d12:0x6e74, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70e2,
				0, this.oParent.GameState.Cities[cityID].ActualSize);

			this.oParent.Var_70e2 = this.oCPU.AX.Word;

		L6e7f:
			this.oParent.Var_70e4--;

			// Instruction address 0x1d12:0x6e98, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oParent.Var_70e4,
				0, this.oParent.GameState.Cities[cityID].ActualSize);

		L6e94:
			this.oParent.Var_70e4 = this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x6ebb, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.GameState.Cities[cityID].ActualSize - (short)param2, 0, 99);

			this.oCPU.CX.Word = this.oParent.Var_70e2;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oParent.Var_70e4);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L6ed2;
			goto L6e4e;

		L6ed2:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6dfe");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param4"></param>
		/// <param name="param5"></param>
		/// <returns></returns>
		public ushort F0_1d12_6ed4(short cityID, short xPos, short yPos, ushort param4, ushort param5)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6ed4({cityID}, {xPos}, {yPos}, {param4}, {param5})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x7;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, param5);
			if (this.oCPU.Flags.LE) goto L6f04;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = param5;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			goto L6f09;

		L6f04:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x7);

		L6f09:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6f37;

		L6f10:
			// Instruction address 0x1d12:0x6f26, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e96)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6f37:
			this.oCPU.AX.Word = this.oParent.Var_70e2;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L6f10;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6f49;
			xPos += 2;

		L6f49:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6f77;

		L6f50:
			// Instruction address 0x1d12:0x6f66, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e9a)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6f77:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e2);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_70e4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.G) goto L6f50;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L6f9e;
			xPos += 2;

		L6f9e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6ff6;

		L6fa5:
			// Instruction address 0x1d12:0x6fbb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e9e)));

			this.oCPU.AX.Word = this.Var_6542;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L6fed;

			// Instruction address 0x1d12:0x6fe5, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 12, 14, 5, 12);

		L6fed:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6ff6:
			this.oCPU.AX.Word = this.oParent.Var_70e4;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L6fa5;
			xPos += 4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L7036;

		L7009:
			// Instruction address 0x1d12:0x700d, size: 3
			F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x1d12:0x7025, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.AX.Word << 1) + 0x6ea0)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L7036:
			this.oCPU.AX.Word = param4;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L7009;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6ed4");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPosSrc"></param>
		/// <param name="xPosDst"></param>
		/// <param name="yPosDst"></param>
		public void F0_1d12_7045(short xPosSrc, short xPosDst, short yPosDst)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_7045({xPosSrc}, {xPosDst}, {yPosDst})");

			// function body
			if (xPosSrc < 22 || xPosSrc > 24)
			{
				xPosSrc--;

				if (xPosSrc >= 24)
				{
					xPosSrc -= 3;
				}

				if (xPosSrc >= 40)
				{
					// Instruction address 0x1d12:0x70c1, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, ((xPosSrc & 1) * 19) + 161, 100, 18, 10,
						this.oParent.Var_aa_Rectangle, xPosDst, yPosDst);
				}
				else
				{
					// Instruction address 0x1d12:0x70c1, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, ((xPosSrc / 5) * 19) + 161, ((xPosSrc % 5) * 10) + 50, 18, 10,
						this.oParent.Var_aa_Rectangle, xPosDst, yPosDst);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_7045");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		public void F0_1d12_70cb(int xPos, int yPos, int xPos1, int yPos1)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_70cb({xPos}, {yPos}, {xPos1}, {yPos1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			
			int iWidth = xPos1 - xPos;
			int iHeight = yPos1 - yPos;

			// Instruction address 0x1d12:0x70ee, size: 3
			F0_1d12_710d_FillRectangleWithPattern(xPos, yPos, iWidth, iHeight);

			// Instruction address 0x1d12:0x7104, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos, yPos, iWidth, iHeight, 1);

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_70cb");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public void F0_1d12_710d_FillRectangleWithPattern(int xPos, int yPos, int width, int height)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_710d_FillRectangleWithPattern({xPos}, {yPos}, {width}, {height})");

			// function body
			if (this.oParent.Var_d762 == 0)
			{
				// Instruction address 0x1d12:0x712e, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos, yPos, width, height, 9);
			}
			else
			{
				int iRectYPos = yPos;
				int iRectHeight = height;

				while (iRectHeight > 0)
				{
					int iCellHeight = Math.Min(iRectHeight, 16);
					int iRectXPos = xPos;
					int iRectWidth = width;

					while (iRectWidth > 0)
					{
						int iCellWidth = Math.Min(iRectWidth, 16);

						// Instruction address 0x1d12:0x7195, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
							208, 100, iCellWidth, iCellHeight, this.oParent.Var_aa_Rectangle, iRectXPos, iRectYPos);

						iRectXPos += iCellWidth;
						iRectWidth -= iCellWidth;
					}

					iRectYPos += iCellHeight;
					iRectHeight -= iCellHeight;
				}
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_710d_FillRectangleWithPattern");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="stringPtr"></param>
		/// <param name="mode"></param>
		public void F0_1d12_71bf(int xPos, int yPos, int xPos1, int yPos1, ushort stringPtr, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_71bf({xPos}, {yPos}, {xPos1}, {yPos1}, 0x{stringPtr:x4}, {mode})");

			// function body
			// Instruction address 0x1d12:0x71e8, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos1 - xPos, yPos1 - yPos, mode);
		
			// Instruction address 0x1d12:0x720e, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos1, yPos, (ushort)((mode < 8) ? (mode + 8) : 7));
		
			// Instruction address 0x1d12:0x7234, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos, yPos1, (ushort)((mode < 8) ? (mode + 8) : 7));
		
			// Instruction address 0x1d12:0x725c, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos + 1, yPos1, xPos1, yPos1, (ushort)((mode < 8) ? 8 : (mode - 8)));

			// Instruction address 0x1d12:0x7282, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos1, yPos, xPos1, yPos1, (ushort)((mode < 0x8) ? 8 : (mode - 8)));

			// Instruction address 0x1d12:0x72ae, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(stringPtr,
				((xPos + xPos1) / 2) + 1, ((yPos + yPos1) / 2) - 2, (byte)(mode ^ 8));

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_71bf");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1d12_72b7()
		{
			this.oCPU.Log.EnterBlock("F0_1d12_72b7()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			// Instruction address 0x1d12:0x72d4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 101, 117, 120, 75, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L73bf;

		L72e4:
			// Instruction address 0x1d12:0x72f7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				2, 2, 2);

		L72ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L7302:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.L) goto L730b;
			goto L73bc;

		L730b:
			// Instruction address 0x1d12:0x731c, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].XStart +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 40);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L72ff;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x280c));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x65);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2810));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x76);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.CX.Word);

			// Instruction address 0x1d12:0x73a3, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L73b6;
			goto L72e4;

		L73b6:
			// Instruction address 0x1d12:0x72f7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				2, 2, 1);

			goto L72ff;

		L73bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L73bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x32);
			if (this.oCPU.Flags.GE) goto L73cd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L7302;

		L73cd:
			// Instruction address 0x1d12:0x73e1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(100, 117, 121, 75, 9);

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_72b7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1d12_73ea(int xPos, int yPos, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_73ea({xPos}, {yPos}, {mode})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			if (this.Var_2496 == 2)
			{
				// Instruction address 0x1d12:0x7405, size: 5
				xPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
					xPos - this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].XStart + 40);

				// Instruction address 0x1d12:0x7444, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					((xPos * 3) / 2) + 101, ((yPos * 3) / 2) + 118, 2, 2, mode);
			}

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_73ea");
		}
	}
}
