/*
	Generated by KBEngine!
	Please do not modify this file!
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class EntityDef
	{
		public static Dictionary<string, UInt16> datatype2id = new Dictionary<string, UInt16>();
		public static Dictionary<string, DATATYPE_BASE> datatypes = new Dictionary<string, DATATYPE_BASE>();
		public static Dictionary<UInt16, DATATYPE_BASE> id2datatypes = new Dictionary<UInt16, DATATYPE_BASE>();
		public static Dictionary<string, Int32> entityclass = new Dictionary<string, Int32>();
		public static Dictionary<string, ScriptModule> moduledefs = new Dictionary<string, ScriptModule>();
		public static Dictionary<UInt16, ScriptModule> idmoduledefs = new Dictionary<UInt16, ScriptModule>();

		public static bool init()
		{
			initDataTypes();
			initDefTypes();
			initScriptModules();
			return true;
		}

		public static bool reset()
		{
			clear();
			return init();
		}

		public static void clear()
		{
			datatype2id.Clear();
			datatypes.Clear();
			id2datatypes.Clear();
			entityclass.Clear();
			moduledefs.Clear();
			idmoduledefs.Clear();
		}

		public static void initDataTypes()
		{
			datatypes["UINT8"] = new DATATYPE_UINT8();
			datatypes["UINT16"] = new DATATYPE_UINT16();
			datatypes["UINT32"] = new DATATYPE_UINT32();
			datatypes["UINT64"] = new DATATYPE_UINT64();

			datatypes["INT8"] = new DATATYPE_INT8();
			datatypes["INT16"] = new DATATYPE_INT16();
			datatypes["INT32"] = new DATATYPE_INT32();
			datatypes["INT64"] = new DATATYPE_INT64();

			datatypes["FLOAT"] = new DATATYPE_FLOAT();
			datatypes["DOUBLE"] = new DATATYPE_DOUBLE();

			datatypes["STRING"] = new DATATYPE_STRING();
			datatypes["VECTOR2"] = new DATATYPE_VECTOR2();

			datatypes["VECTOR3"] = new DATATYPE_VECTOR3();

			datatypes["VECTOR4"] = new DATATYPE_VECTOR4();
			datatypes["PYTHON"] = new DATATYPE_PYTHON();

			datatypes["UNICODE"] = new DATATYPE_UNICODE();
			datatypes["ENTITYCALL"] = new DATATYPE_ENTITYCALL();

			datatypes["BLOB"] = new DATATYPE_BLOB();
		}

		public static void initScriptModules()
		{
			ScriptModule pAccountModule = new ScriptModule("Account");
			EntityDef.moduledefs["Account"] = pAccountModule;
			EntityDef.idmoduledefs[1] = pAccountModule;

			Property pAccount_position = new Property();
			pAccount_position.name = "position";
			pAccount_position.properUtype = 40000;
			pAccount_position.properFlags = 4;
			pAccount_position.aliasID = 1;
			Vector3 Account_position_defval = new Vector3();
			pAccount_position.defaultVal = Account_position_defval;
			pAccountModule.propertys["position"] = pAccount_position; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_position.aliasID] = pAccount_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(position / 40000).");

			Property pAccount_direction = new Property();
			pAccount_direction.name = "direction";
			pAccount_direction.properUtype = 40001;
			pAccount_direction.properFlags = 4;
			pAccount_direction.aliasID = 2;
			Vector3 Account_direction_defval = new Vector3();
			pAccount_direction.defaultVal = Account_direction_defval;
			pAccountModule.propertys["direction"] = pAccount_direction; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_direction.aliasID] = pAccount_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(direction / 40001).");

			Property pAccount_spaceID = new Property();
			pAccount_spaceID.name = "spaceID";
			pAccount_spaceID.properUtype = 40002;
			pAccount_spaceID.properFlags = 16;
			pAccount_spaceID.aliasID = 3;
			UInt32 Account_spaceID_defval;
			UInt32.TryParse("", out Account_spaceID_defval);
			pAccount_spaceID.defaultVal = Account_spaceID_defval;
			pAccountModule.propertys["spaceID"] = pAccount_spaceID; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_spaceID.aliasID] = pAccount_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(spaceID / 40002).");

			Property pAccount_lastSelCharacter = new Property();
			pAccount_lastSelCharacter.name = "lastSelCharacter";
			pAccount_lastSelCharacter.properUtype = 2;
			pAccount_lastSelCharacter.properFlags = 32;
			pAccount_lastSelCharacter.aliasID = 4;
			UInt64 Account_lastSelCharacter_defval;
			UInt64.TryParse("0", out Account_lastSelCharacter_defval);
			pAccount_lastSelCharacter.defaultVal = Account_lastSelCharacter_defval;
			pAccountModule.propertys["lastSelCharacter"] = pAccount_lastSelCharacter; 

			pAccountModule.usePropertyDescrAlias = true;
			pAccountModule.idpropertys[(UInt16)pAccount_lastSelCharacter.aliasID] = pAccount_lastSelCharacter;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Account), property(lastSelCharacter / 2).");

			pAccountModule.useMethodDescrAlias = true;
			ScriptModule pAvatarModule = new ScriptModule("Avatar");
			EntityDef.moduledefs["Avatar"] = pAvatarModule;
			EntityDef.idmoduledefs[2] = pAvatarModule;

			Property pAvatar_position = new Property();
			pAvatar_position.name = "position";
			pAvatar_position.properUtype = 40000;
			pAvatar_position.properFlags = 4;
			pAvatar_position.aliasID = 1;
			Vector3 Avatar_position_defval = new Vector3();
			pAvatar_position.defaultVal = Avatar_position_defval;
			pAvatarModule.propertys["position"] = pAvatar_position; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_position.aliasID] = pAvatar_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(position / 40000).");

			Property pAvatar_direction = new Property();
			pAvatar_direction.name = "direction";
			pAvatar_direction.properUtype = 40001;
			pAvatar_direction.properFlags = 4;
			pAvatar_direction.aliasID = 2;
			Vector3 Avatar_direction_defval = new Vector3();
			pAvatar_direction.defaultVal = Avatar_direction_defval;
			pAvatarModule.propertys["direction"] = pAvatar_direction; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_direction.aliasID] = pAvatar_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(direction / 40001).");

			Property pAvatar_spaceID = new Property();
			pAvatar_spaceID.name = "spaceID";
			pAvatar_spaceID.properUtype = 40002;
			pAvatar_spaceID.properFlags = 16;
			pAvatar_spaceID.aliasID = 3;
			UInt32 Avatar_spaceID_defval;
			UInt32.TryParse("", out Avatar_spaceID_defval);
			pAvatar_spaceID.defaultVal = Avatar_spaceID_defval;
			pAvatarModule.propertys["spaceID"] = pAvatar_spaceID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceID.aliasID] = pAvatar_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceID / 40002).");

			Property pAvatar_component1 = new Property();
			pAvatar_component1.name = "component1";
			pAvatar_component1.properUtype = 6;
			pAvatar_component1.properFlags = 157;
			pAvatar_component1.aliasID = 4;
			pAvatarModule.propertys["component1"] = pAvatar_component1; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_component1.aliasID] = pAvatar_component1;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(component1 / 6).");

			Property pAvatar_component2 = new Property();
			pAvatar_component2.name = "component2";
			pAvatar_component2.properUtype = 9;
			pAvatar_component2.properFlags = 157;
			pAvatar_component2.aliasID = 5;
			pAvatarModule.propertys["component2"] = pAvatar_component2; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_component2.aliasID] = pAvatar_component2;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(component2 / 9).");

			Property pAvatar_name = new Property();
			pAvatar_name.name = "name";
			pAvatar_name.properUtype = 4;
			pAvatar_name.properFlags = 4;
			pAvatar_name.aliasID = 6;
			string Avatar_name_defval = "";
			pAvatar_name.defaultVal = Avatar_name_defval;
			pAvatarModule.propertys["name"] = pAvatar_name; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_name.aliasID] = pAvatar_name;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(name / 4).");

			pAvatarModule.useMethodDescrAlias = true;
			ScriptModule pFrameSyncReportModule = new ScriptModule("FrameSyncReport");
			EntityDef.moduledefs["FrameSyncReport"] = pFrameSyncReportModule;
			EntityDef.idmoduledefs[3] = pFrameSyncReportModule;

			Property pFrameSyncReport_position = new Property();
			pFrameSyncReport_position.name = "position";
			pFrameSyncReport_position.properUtype = 40000;
			pFrameSyncReport_position.properFlags = 4;
			pFrameSyncReport_position.aliasID = 1;
			Vector3 FrameSyncReport_position_defval = new Vector3();
			pFrameSyncReport_position.defaultVal = FrameSyncReport_position_defval;
			pFrameSyncReportModule.propertys["position"] = pFrameSyncReport_position; 

			pFrameSyncReportModule.usePropertyDescrAlias = true;
			pFrameSyncReportModule.idpropertys[(UInt16)pFrameSyncReport_position.aliasID] = pFrameSyncReport_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), property(position / 40000).");

			Property pFrameSyncReport_direction = new Property();
			pFrameSyncReport_direction.name = "direction";
			pFrameSyncReport_direction.properUtype = 40001;
			pFrameSyncReport_direction.properFlags = 4;
			pFrameSyncReport_direction.aliasID = 2;
			Vector3 FrameSyncReport_direction_defval = new Vector3();
			pFrameSyncReport_direction.defaultVal = FrameSyncReport_direction_defval;
			pFrameSyncReportModule.propertys["direction"] = pFrameSyncReport_direction; 

			pFrameSyncReportModule.usePropertyDescrAlias = true;
			pFrameSyncReportModule.idpropertys[(UInt16)pFrameSyncReport_direction.aliasID] = pFrameSyncReport_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), property(direction / 40001).");

			Property pFrameSyncReport_spaceID = new Property();
			pFrameSyncReport_spaceID.name = "spaceID";
			pFrameSyncReport_spaceID.properUtype = 40002;
			pFrameSyncReport_spaceID.properFlags = 16;
			pFrameSyncReport_spaceID.aliasID = 3;
			UInt32 FrameSyncReport_spaceID_defval;
			UInt32.TryParse("", out FrameSyncReport_spaceID_defval);
			pFrameSyncReport_spaceID.defaultVal = FrameSyncReport_spaceID_defval;
			pFrameSyncReportModule.propertys["spaceID"] = pFrameSyncReport_spaceID; 

			pFrameSyncReportModule.usePropertyDescrAlias = true;
			pFrameSyncReportModule.idpropertys[(UInt16)pFrameSyncReport_spaceID.aliasID] = pFrameSyncReport_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), property(spaceID / 40002).");

			Property pFrameSyncReport_seatNo = new Property();
			pFrameSyncReport_seatNo.name = "seatNo";
			pFrameSyncReport_seatNo.properUtype = 8;
			pFrameSyncReport_seatNo.properFlags = 16;
			pFrameSyncReport_seatNo.aliasID = 4;
			SByte FrameSyncReport_seatNo_defval;
			SByte.TryParse("0", out FrameSyncReport_seatNo_defval);
			pFrameSyncReport_seatNo.defaultVal = FrameSyncReport_seatNo_defval;
			pFrameSyncReportModule.propertys["seatNo"] = pFrameSyncReport_seatNo; 

			pFrameSyncReportModule.usePropertyDescrAlias = true;
			pFrameSyncReportModule.idpropertys[(UInt16)pFrameSyncReport_seatNo.aliasID] = pFrameSyncReport_seatNo;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), property(seatNo / 8).");

			List<DATATYPE_BASE> pFrameSyncReport_onFrameMessage_args = new List<DATATYPE_BASE>();
			pFrameSyncReport_onFrameMessage_args.Add(EntityDef.id2datatypes[27]);

			Method pFrameSyncReport_onFrameMessage = new Method();
			pFrameSyncReport_onFrameMessage.name = "onFrameMessage";
			pFrameSyncReport_onFrameMessage.methodUtype = 4;
			pFrameSyncReport_onFrameMessage.aliasID = 1;
			pFrameSyncReport_onFrameMessage.args = pFrameSyncReport_onFrameMessage_args;

			pFrameSyncReportModule.methods["onFrameMessage"] = pFrameSyncReport_onFrameMessage; 
			pFrameSyncReportModule.useMethodDescrAlias = true;
			pFrameSyncReportModule.idmethods[(UInt16)pFrameSyncReport_onFrameMessage.aliasID] = pFrameSyncReport_onFrameMessage;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), method(onFrameMessage / 4).");

			List<DATATYPE_BASE> pFrameSyncReport_reportFrame_args = new List<DATATYPE_BASE>();
			pFrameSyncReport_reportFrame_args.Add(EntityDef.id2datatypes[26]);

			Method pFrameSyncReport_reportFrame = new Method();
			pFrameSyncReport_reportFrame.name = "reportFrame";
			pFrameSyncReport_reportFrame.methodUtype = 2;
			pFrameSyncReport_reportFrame.aliasID = -1;
			pFrameSyncReport_reportFrame.args = pFrameSyncReport_reportFrame_args;

			pFrameSyncReportModule.methods["reportFrame"] = pFrameSyncReport_reportFrame; 
			pFrameSyncReportModule.cell_methods["reportFrame"] = pFrameSyncReport_reportFrame;

			pFrameSyncReportModule.idcell_methods[pFrameSyncReport_reportFrame.methodUtype] = pFrameSyncReport_reportFrame;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(FrameSyncReport), method(reportFrame / 2).");

			ScriptModule pOperationModule = new ScriptModule("Operation");
			EntityDef.moduledefs["Operation"] = pOperationModule;
			EntityDef.idmoduledefs[4] = pOperationModule;

			Property pOperation_position = new Property();
			pOperation_position.name = "position";
			pOperation_position.properUtype = 40000;
			pOperation_position.properFlags = 4;
			pOperation_position.aliasID = 1;
			Vector3 Operation_position_defval = new Vector3();
			pOperation_position.defaultVal = Operation_position_defval;
			pOperationModule.propertys["position"] = pOperation_position; 

			pOperationModule.usePropertyDescrAlias = true;
			pOperationModule.idpropertys[(UInt16)pOperation_position.aliasID] = pOperation_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Operation), property(position / 40000).");

			Property pOperation_direction = new Property();
			pOperation_direction.name = "direction";
			pOperation_direction.properUtype = 40001;
			pOperation_direction.properFlags = 4;
			pOperation_direction.aliasID = 2;
			Vector3 Operation_direction_defval = new Vector3();
			pOperation_direction.defaultVal = Operation_direction_defval;
			pOperationModule.propertys["direction"] = pOperation_direction; 

			pOperationModule.usePropertyDescrAlias = true;
			pOperationModule.idpropertys[(UInt16)pOperation_direction.aliasID] = pOperation_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Operation), property(direction / 40001).");

			Property pOperation_spaceID = new Property();
			pOperation_spaceID.name = "spaceID";
			pOperation_spaceID.properUtype = 40002;
			pOperation_spaceID.properFlags = 16;
			pOperation_spaceID.aliasID = 3;
			UInt32 Operation_spaceID_defval;
			UInt32.TryParse("", out Operation_spaceID_defval);
			pOperation_spaceID.defaultVal = Operation_spaceID_defval;
			pOperationModule.propertys["spaceID"] = pOperation_spaceID; 

			pOperationModule.usePropertyDescrAlias = true;
			pOperationModule.idpropertys[(UInt16)pOperation_spaceID.aliasID] = pOperation_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Operation), property(spaceID / 40002).");

			List<DATATYPE_BASE> pOperation_readyResult_args = new List<DATATYPE_BASE>();
			pOperation_readyResult_args.Add(EntityDef.id2datatypes[2]);

			Method pOperation_readyResult = new Method();
			pOperation_readyResult.name = "readyResult";
			pOperation_readyResult.methodUtype = 6;
			pOperation_readyResult.aliasID = 1;
			pOperation_readyResult.args = pOperation_readyResult_args;

			pOperationModule.methods["readyResult"] = pOperation_readyResult; 
			pOperationModule.useMethodDescrAlias = true;
			pOperationModule.idmethods[(UInt16)pOperation_readyResult.aliasID] = pOperation_readyResult;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Operation), method(readyResult / 6).");

			List<DATATYPE_BASE> pOperation_reqReady_args = new List<DATATYPE_BASE>();
			pOperation_reqReady_args.Add(EntityDef.id2datatypes[2]);

			Method pOperation_reqReady = new Method();
			pOperation_reqReady.name = "reqReady";
			pOperation_reqReady.methodUtype = 5;
			pOperation_reqReady.aliasID = -1;
			pOperation_reqReady.args = pOperation_reqReady_args;

			pOperationModule.methods["reqReady"] = pOperation_reqReady; 
			pOperationModule.cell_methods["reqReady"] = pOperation_reqReady;

			pOperationModule.idcell_methods[pOperation_reqReady.methodUtype] = pOperation_reqReady;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Operation), method(reqReady / 5).");

		}

		public static void initDefTypes()
		{
			{
				UInt16 utype = 2;
				string typeName = "CMD_TYPE";
				string name = "UINT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 3;
				string typeName = "UINT16";
				string name = "UINT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 5;
				string typeName = "SPACE_KEY";
				string name = "UINT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 4;
				string typeName = "FRAMEID";
				string name = "UINT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 6;
				string typeName = "INT8";
				string name = "INT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 7;
				string typeName = "INT16";
				string name = "INT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 8;
				string typeName = "ENTITY_ID";
				string name = "INT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 9;
				string typeName = "INT64";
				string name = "INT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 1;
				string typeName = "STRING";
				string name = "STRING";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 12;
				string typeName = "UNICODE";
				string name = "UNICODE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 13;
				string typeName = "FLOAT";
				string name = "FLOAT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 14;
				string typeName = "DOUBLE";
				string name = "DOUBLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "UID1";
				string name = "PYTHON";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_DICT";
				string name = "PY_DICT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_TUPLE";
				string name = "PY_TUPLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_LIST";
				string name = "PY_LIST";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 20;
				string typeName = "ENTITYCALL";
				string name = "ENTITYCALL";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 11;
				string typeName = "BLOB";
				string name = "BLOB";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 15;
				string typeName = "VECTOR2";
				string name = "VECTOR2";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 16;
				string typeName = "DIRECTION3D";
				string name = "VECTOR3";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 17;
				string typeName = "VECTOR4";
				string name = "VECTOR4";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 22;
				string typeName = "AVATAR_DATA";
				DATATYPE_AVATAR_DATA datatype = new DATATYPE_AVATAR_DATA();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 23;
				string typeName = "AVATAR_INFOS";
				DATATYPE_AVATAR_INFOS datatype = new DATATYPE_AVATAR_INFOS();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 24;
				string typeName = "AVATAR_INFOS_LIST";
				DATATYPE_AVATAR_INFOS_LIST datatype = new DATATYPE_AVATAR_INFOS_LIST();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 26;
				string typeName = "FS_ENTITY_DATA";
				DATATYPE_FS_ENTITY_DATA datatype = new DATATYPE_FS_ENTITY_DATA();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 27;
				string typeName = "FS_FRAME_DATA";
				DATATYPE_FS_FRAME_DATA datatype = new DATATYPE_FS_FRAME_DATA();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 29;
				string typeName = "FS_FRAME_LIST";
				DATATYPE_FS_FRAME_LIST datatype = new DATATYPE_FS_FRAME_LIST();
				EntityDef.datatypes[typeName] = datatype;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 31;
				string typeName = "AnonymousArray_31";
				string name = "ENTITY_COMPONENT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 32;
				string typeName = "AnonymousArray_32";
				string name = "ENTITY_COMPONENT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 33;
				string typeName = "AnonymousArray_33";
				string name = "ENTITY_COMPONENT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			foreach(string datatypeStr in EntityDef.datatypes.Keys)
			{
				DATATYPE_BASE dataType = EntityDef.datatypes[datatypeStr];
				if(dataType != null)
				{
					dataType.bind();
				}
			}
		}

	}


}