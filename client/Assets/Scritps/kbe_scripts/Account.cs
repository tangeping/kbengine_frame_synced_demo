namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	using System.Linq;
	
    public class Account : AccountBase 
    {	
		public Account() : base()
		{
		}
		
		public override void __init__()
		{
			// 触发登陆成功事件
			Event.fireOut("onLoginSuccessfully", new object[]{KBEngineApp.app.entity_uuid, id, this});
			
		}

		public override void onDestroy ()
		{
			KBEngine.Event.deregisterIn(this);
		}
				

    }
} 
