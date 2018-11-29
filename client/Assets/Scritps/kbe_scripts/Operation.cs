namespace KBEngine
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Operation : OperationBase
    {
        public Operation() : base()
        {

        }

        public override void onAttached(Entity ownerEntity)
        {
            if (ownerEntity.isPlayer())
            {
                KBEngine.Event.registerIn("reqReady", this, "reqReady");
            }
        }

        public override void readyResult(byte result)
        {
            KBEngine.Event.fireOut("readyResult", result);
        }

        public void reqReady(Byte ready)
        {
            cellEntityCall.reqReady(ready);

        }
    }
}
