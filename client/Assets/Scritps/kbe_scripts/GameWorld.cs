using KBEngine;
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class GameWorld : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        installEvents();
    }

    void installEvents()
    {
        // in world
        KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
        KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");


    }

    void OnDestroy()
    {
        KBEngine.Event.deregisterOut(this);
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void onEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("WorldEvent:entity." + entity.id + ",claseName:" + entity.className);

        if (entity.className == "Avatar")
        {
            SpaceData.Instance.SpacePlayers.Add(((KBEngine.Avatar)entity).component1);

            SpaceData.Instance.SpacePlayers = SpaceData.Instance.SpacePlayers.OrderBy(s => s.seatNo).ToList();

            KBEngine.Event.fireOut("onAvatarEnterWorld");
        }

    }
    public void onLeaveWorld(KBEngine.Entity entity)
    {
        if (entity.renderObj == null)
            return;

        KBEngine.Event.fireOut("onAvatarLeaveWorld");

        UnityEngine.GameObject.Destroy((UnityEngine.GameObject)entity.renderObj);
        entity.renderObj = null;
    }




}
