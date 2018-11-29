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

	// defined in */scripts/entity_defs/FrameSync.def
	public class EntityBaseEntityCall_FrameSyncBase : EntityCall
	{
		public UInt16 entityComponentPropertyID = 0;

		public EntityBaseEntityCall_FrameSyncBase(UInt16 ecpID, Int32 eid) : base(eid, "FrameSync")
		{
			entityComponentPropertyID = ecpID;
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_BASE;
		}

	}

	public class EntityCellEntityCall_FrameSyncBase : EntityCall
	{
		public UInt16 entityComponentPropertyID = 0;

		public EntityCellEntityCall_FrameSyncBase(UInt16 ecpID, Int32 eid) : base(eid, "FrameSync")
		{
			entityComponentPropertyID = ecpID;
			className = "FrameSync";
			type = ENTITYCALL_TYPE.ENTITYCALL_TYPE_CELL;
		}

	}
	}