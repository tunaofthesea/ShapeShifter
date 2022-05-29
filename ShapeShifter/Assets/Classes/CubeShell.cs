using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeShell : Shell {
    public Collider collider;
    
    public CubeShell(int _id, Vector3 pos, Metrics ms) : base(_id, pos, ms, GameObject.CreatePrimitive(PrimitiveType.Cube)) {

        add_collider();
        // game_object.AddComponent(Type.GetType("EvasionByRotation"));

    }

    public override void follow_path(){}       
    public override void add_collider(){
        collider = game_object.AddComponent<BoxCollider>();        
    }       

    public static CubeShell CubeShellCreator(int id, Metrics ms, params Action<Shell>[] configs){
        CubeShell s = new CubeShell(id, Vector3.zero, ms);
        foreach(Action<Shell> a in configs){
            a(s);
        }
        return s;
    }

}



