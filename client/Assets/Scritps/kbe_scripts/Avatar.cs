namespace KBEngine
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;


    public class Avatar : AvatarBase
    {
        public Avatar()
        {
            
        }

        public override void __init__()
        {

           
        }

        public override void onDestroy()
        {

        }

        public override void onNameChanged(string old)
        {
            //Debug.Log(className + "::set_name: " + old + " => " + v); 
            Event.fireOut("set_name", new object[] { this, this.name });
        }

    }
}
