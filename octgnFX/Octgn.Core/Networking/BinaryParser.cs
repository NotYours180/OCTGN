﻿








/* 
 * This file was automatically generated!
 * Do not modify, changes will get lost when the file is regenerated!
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using Octgn.Play;
using Octgn.Core;
using Octgn.Core.Play;

namespace Octgn.Networking
{
	sealed class BinaryParser
	{
		Handler handler;
		
		public BinaryParser(Handler handler)
		{ this.handler = handler; }
		
		public void Parse(byte[] data)
		{
			MemoryStream stream = new MemoryStream(data);
			BinaryReader reader = new BinaryReader(stream);
			short length;
			K.C.Get<Client>().Muted = reader.ReadInt32();
			byte method = reader.ReadByte();
			switch (method)
			{
case 0:
				{
					handler.Binary();
					break;
				}
				case 1:
				{
					string arg0 = reader.ReadString();
					handler.Error(arg0);
					break;
				}
				case 3:
				{
					byte arg0 = reader.ReadByte();
					handler.Welcome(arg0);
					break;
				}
				case 4:
				{
					bool arg0 = reader.ReadBoolean();
					handler.Settings(arg0);
					break;
				}
				case 5:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[PlayerSettings] Player not found."); return; }
					bool arg1 = reader.ReadBoolean();
					handler.PlayerSettings(arg0, arg1);
					break;
				}
				case 6:
				{
					byte arg0 = reader.ReadByte();
					string arg1 = reader.ReadString();
					ulong arg2 = reader.ReadUInt64();
					handler.NewPlayer(arg0, arg1, arg2);
					break;
				}
				case 7:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Leave] Player not found."); return; }
					handler.Leave(arg0);
					break;
				}
				case 9:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Nick] Player not found."); return; }
					string arg1 = reader.ReadString();
					handler.Nick(arg0, arg1);
					break;
				}
				case 10:
				{
					handler.Start();
					break;
				}
				case 12:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Reset] Player not found."); return; }
					handler.Reset(arg0);
					break;
				}
				case 13:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[NextTurn] Player not found."); return; }
					handler.NextTurn(arg0);
					break;
				}
				case 15:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[StopTurn] Player not found."); return; }
					handler.StopTurn(arg0);
					break;
				}
				case 17:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Chat] Player not found."); return; }
					string arg1 = reader.ReadString();
					handler.Chat(arg0, arg1);
					break;
				}
				case 19:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Print] Player not found."); return; }
					string arg1 = reader.ReadString();
					handler.Print(arg0, arg1);
					break;
				}
				case 21:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Random] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					int arg2 = reader.ReadInt32();
					int arg3 = reader.ReadInt32();
					handler.Random(arg0, arg1, arg2, arg3);
					break;
				}
				case 23:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[RandomAnswer1] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					ulong arg2 = reader.ReadUInt64();
					handler.RandomAnswer1(arg0, arg1, arg2);
					break;
				}
				case 25:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[RandomAnswer2] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					ulong arg2 = reader.ReadUInt64();
					handler.RandomAnswer2(arg0, arg1, arg2);
					break;
				}
				case 27:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Counter] Player not found."); return; }
					IPlayCounter arg1 = K.C.Get<GameStateMachine>().Find<IPlayCounter>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Counter] Counter not found."); return; }
					int arg2 = reader.ReadInt32();
					handler.Counter(arg0, arg1, arg2);
					break;
				}
				case 28:
				{
					length = reader.ReadInt16();
int[] arg0 = new int[length];
for (int i = 0; i < length; ++i)
	arg0[i] = reader.ReadInt32();
					length = reader.ReadInt16();
ulong[] arg1 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadUInt64();
					length = reader.ReadInt16();
IPlayGroup[] arg2 = new IPlayGroup[length];
for (int i = 0; i < length; ++i)
{
  arg2[i] = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
  if (arg2[i] == null) 
    Debug.WriteLine("[LoadDeck] Group not found.");
}
					handler.LoadDeck(arg0, arg1, arg2);
					break;
				}
				case 29:
				{
					length = reader.ReadInt16();
int[] arg0 = new int[length];
for (int i = 0; i < length; ++i)
	arg0[i] = reader.ReadInt32();
					length = reader.ReadInt16();
ulong[] arg1 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadUInt64();
					IPlayGroup arg2 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[CreateCard] Group not found."); return; }
					handler.CreateCard(arg0, arg1, arg2);
					break;
				}
				case 30:
				{
					length = reader.ReadInt16();
int[] arg0 = new int[length];
for (int i = 0; i < length; ++i)
	arg0[i] = reader.ReadInt32();
					length = reader.ReadInt16();
ulong[] arg1 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadUInt64();
					length = reader.ReadInt16();
Guid[] arg2 = new Guid[length];
for (int i = 0; i < length; ++i)
	arg2[i] = new Guid(reader.ReadBytes(16));
					length = reader.ReadInt16();
int[] arg3 = new int[length];
for (int i = 0; i < length; ++i)
	arg3[i] = reader.ReadInt32();
					length = reader.ReadInt16();
int[] arg4 = new int[length];
for (int i = 0; i < length; ++i)
	arg4[i] = reader.ReadInt32();
					bool arg5 = reader.ReadBoolean();
					bool arg6 = reader.ReadBoolean();
					handler.CreateCardAt(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
					break;
				}
				case 31:
				{
					length = reader.ReadInt16();
int[] arg0 = new int[length];
for (int i = 0; i < length; ++i)
	arg0[i] = reader.ReadInt32();
					length = reader.ReadInt16();
ulong[] arg1 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadUInt64();
					handler.CreateAlias(arg0, arg1);
					break;
				}
				case 33:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[MoveCard] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[MoveCard] Card not found."); return; }
					IPlayGroup arg2 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[MoveCard] Group not found."); return; }
					int arg3 = reader.ReadInt32();
					bool arg4 = reader.ReadBoolean();
					handler.MoveCard(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 35:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[MoveCardAt] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[MoveCardAt] Card not found."); return; }
					int arg2 = reader.ReadInt32();
					int arg3 = reader.ReadInt32();
					int arg4 = reader.ReadInt32();
					bool arg5 = reader.ReadBoolean();
					handler.MoveCardAt(arg0, arg1, arg2, arg3, arg4, arg5);
					break;
				}
				case 36:
				{
					IPlayCard arg0 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[Reveal] Card not found."); return; }
					ulong arg1 = reader.ReadUInt64();
					Guid arg2 = new Guid(reader.ReadBytes(16));
					handler.Reveal(arg0, arg1, arg2);
					break;
				}
				case 38:
				{
					length = reader.ReadInt16();
IPlayPlayer[] arg0 = new IPlayPlayer[length];
for (int i = 0; i < length; ++i)
{
  arg0[i] = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
  if (arg0[i] == null) 
    Debug.WriteLine("[RevealTo] Player not found.");
}
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[RevealTo] Card not found."); return; }
					length = reader.ReadInt16();
ulong[] arg2 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg2[i] = reader.ReadUInt64();
					handler.RevealTo(arg0, arg1, arg2);
					break;
				}
				case 40:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Peek] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Peek] Card not found."); return; }
					handler.Peek(arg0, arg1);
					break;
				}
				case 42:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Untarget] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Untarget] Card not found."); return; }
					handler.Untarget(arg0, arg1);
					break;
				}
				case 44:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Target] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Target] Card not found."); return; }
					handler.Target(arg0, arg1);
					break;
				}
				case 46:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[TargetArrow] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[TargetArrow] Card not found."); return; }
					IPlayCard arg2 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[TargetArrow] Card not found."); return; }
					handler.TargetArrow(arg0, arg1, arg2);
					break;
				}
				case 47:
				{
					IPlayCard arg0 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[Highlight] Card not found."); return; }
					string temp1 = reader.ReadString();					
Color? arg1 = temp1 == "" ? (Color?)null : (Color?)ColorConverter.ConvertFromString(temp1);
					handler.Highlight(arg0, arg1);
					break;
				}
				case 49:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Turn] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Turn] Card not found."); return; }
					bool arg2 = reader.ReadBoolean();
					handler.Turn(arg0, arg1, arg2);
					break;
				}
				case 51:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[Rotate] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[Rotate] Card not found."); return; }
					CardOrientation arg2 = (CardOrientation)reader.ReadByte();
					handler.Rotate(arg0, arg1, arg2);
					break;
				}
				case 52:
				{
					IPlayGroup arg0 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[Shuffle] Group not found."); return; }
					length = reader.ReadInt16();
int[] arg1 = new int[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadInt32();
					handler.Shuffle(arg0, arg1);
					break;
				}
				case 53:
				{
					IPlayGroup arg0 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[Shuffled] Group not found."); return; }
					length = reader.ReadInt16();
int[] arg1 = new int[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadInt32();
					length = reader.ReadInt16();
short[] arg2 = new short[length];
for (int i = 0; i < length; ++i)
	arg2[i] = reader.ReadInt16();
					handler.Shuffled(arg0, arg1, arg2);
					break;
				}
				case 54:
				{
					IPlayGroup arg0 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[UnaliasGrp] Group not found."); return; }
					handler.UnaliasGrp(arg0);
					break;
				}
				case 55:
				{
					length = reader.ReadInt16();
int[] arg0 = new int[length];
for (int i = 0; i < length; ++i)
	arg0[i] = reader.ReadInt32();
					length = reader.ReadInt16();
ulong[] arg1 = new ulong[length];
for (int i = 0; i < length; ++i)
	arg1[i] = reader.ReadUInt64();
					handler.Unalias(arg0, arg1);
					break;
				}
				case 57:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[AddMarker] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[AddMarker] Card not found."); return; }
					Guid arg2 = new Guid(reader.ReadBytes(16));
					string arg3 = reader.ReadString();
					ushort arg4 = reader.ReadUInt16();
					handler.AddMarker(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 59:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[RemoveMarker] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[RemoveMarker] Card not found."); return; }
					Guid arg2 = new Guid(reader.ReadBytes(16));
					string arg3 = reader.ReadString();
					ushort arg4 = reader.ReadUInt16();
					handler.RemoveMarker(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 61:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[SetMarker] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[SetMarker] Card not found."); return; }
					Guid arg2 = new Guid(reader.ReadBytes(16));
					string arg3 = reader.ReadString();
					ushort arg4 = reader.ReadUInt16();
					handler.SetMarker(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 63:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[TransferMarker] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[TransferMarker] Card not found."); return; }
					IPlayCard arg2 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[TransferMarker] Card not found."); return; }
					Guid arg3 = new Guid(reader.ReadBytes(16));
					string arg4 = reader.ReadString();
					ushort arg5 = reader.ReadUInt16();
					handler.TransferMarker(arg0, arg1, arg2, arg3, arg4, arg5);
					break;
				}
				case 65:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[PassTo] Player not found."); return; }
					IPlayControllableObject arg1 = K.C.Get<GameStateMachine>().Find<IPlayControllableObject>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[PassTo] ControllableObject not found."); return; }
					IPlayPlayer arg2 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg2 == null)
{ Debug.WriteLine("[PassTo] Player not found."); return; }
					bool arg3 = reader.ReadBoolean();
					handler.PassTo(arg0, arg1, arg2, arg3);
					break;
				}
				case 67:
				{
					IPlayControllableObject arg0 = K.C.Get<GameStateMachine>().Find<IPlayControllableObject>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[TakeFrom] ControllableObject not found."); return; }
					IPlayPlayer arg1 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg1 == null)
{ Debug.WriteLine("[TakeFrom] Player not found."); return; }
					handler.TakeFrom(arg0, arg1);
					break;
				}
				case 69:
				{
					IPlayControllableObject arg0 = K.C.Get<GameStateMachine>().Find<IPlayControllableObject>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[DontTake] ControllableObject not found."); return; }
					handler.DontTake(arg0);
					break;
				}
				case 70:
				{
					IPlayGroup arg0 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg0 == null)
{ Debug.WriteLine("[FreezeCardsVisibility] Group not found."); return; }
					handler.FreezeCardsVisibility(arg0);
					break;
				}
				case 72:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[GroupVis] Player not found."); return; }
					IPlayGroup arg1 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[GroupVis] Group not found."); return; }
					bool arg2 = reader.ReadBoolean();
					bool arg3 = reader.ReadBoolean();
					handler.GroupVis(arg0, arg1, arg2, arg3);
					break;
				}
				case 74:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[GroupVisAdd] Player not found."); return; }
					IPlayGroup arg1 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[GroupVisAdd] Group not found."); return; }
					IPlayPlayer arg2 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg2 == null)
{ Debug.WriteLine("[GroupVisAdd] Player not found."); return; }
					handler.GroupVisAdd(arg0, arg1, arg2);
					break;
				}
				case 76:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[GroupVisRemove] Player not found."); return; }
					IPlayGroup arg1 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[GroupVisRemove] Group not found."); return; }
					IPlayPlayer arg2 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg2 == null)
{ Debug.WriteLine("[GroupVisRemove] Player not found."); return; }
					handler.GroupVisRemove(arg0, arg1, arg2);
					break;
				}
				case 78:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[LookAt] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					IPlayGroup arg2 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[LookAt] Group not found."); return; }
					bool arg3 = reader.ReadBoolean();
					handler.LookAt(arg0, arg1, arg2, arg3);
					break;
				}
				case 80:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[LookAtTop] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					IPlayGroup arg2 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[LookAtTop] Group not found."); return; }
					int arg3 = reader.ReadInt32();
					bool arg4 = reader.ReadBoolean();
					handler.LookAtTop(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 82:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[LookAtBottom] Player not found."); return; }
					int arg1 = reader.ReadInt32();
					IPlayGroup arg2 = K.C.Get<GameStateMachine>().Find<IPlayGroup>(reader.ReadInt32());
if (arg2 == null)
{ Debug.WriteLine("[LookAtBottom] Group not found."); return; }
					int arg3 = reader.ReadInt32();
					bool arg4 = reader.ReadBoolean();
					handler.LookAtBottom(arg0, arg1, arg2, arg3, arg4);
					break;
				}
				case 84:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[StartLimited] Player not found."); return; }
					length = reader.ReadInt16();
Guid[] arg1 = new Guid[length];
for (int i = 0; i < length; ++i)
	arg1[i] = new Guid(reader.ReadBytes(16));
					handler.StartLimited(arg0, arg1);
					break;
				}
				case 86:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[CancelLimited] Player not found."); return; }
					handler.CancelLimited(arg0);
					break;
				}
				case 87:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[CardSwitchTo] Player not found."); return; }
					IPlayCard arg1 = K.C.Get<GameStateMachine>().Find<IPlayCard>(reader.ReadInt32());
if (arg1 == null)
{ Debug.WriteLine("[CardSwitchTo] Card not found."); return; }
					string arg2 = reader.ReadString();
					handler.CardSwitchTo(arg0, arg1, arg2);
					break;
				}
				case 88:
				{
					IPlayPlayer arg0 = K.C.Get<GameStateMachine>().Find<IPlayPlayer>(reader.ReadByte());
if (arg0 == null)
{ Debug.WriteLine("[PlayerSetGlobalVariable] Player not found."); return; }
					string arg1 = reader.ReadString();
					string arg2 = reader.ReadString();
					handler.PlayerSetGlobalVariable(arg0, arg1, arg2);
					break;
				}
				case 89:
				{
					string arg0 = reader.ReadString();
					string arg1 = reader.ReadString();
					handler.SetGlobalVariable(arg0, arg1);
					break;
				}
				case 91:
				{
					handler.Ping();
					break;
				}
				case 92:
				{
					bool arg0 = reader.ReadBoolean();
					handler.IsTableBackgroundFlipped(arg0);
					break;
				}

		  default:
			  Debug.WriteLine("[Client Parser] Unknown message (id =" + method + ")");
				break;
			}
			reader.Close();
		}
	}
}
