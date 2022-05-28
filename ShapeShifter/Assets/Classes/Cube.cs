using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : Shape
{
    public Cube(int _id, Vector3 pos) : base(_id, pos, GameObject.CreatePrimitive(PrimitiveType.Cube)) {

        add_collider();

        // game_object.AddComponent(Type.GetType("EvasionByRotation"));

    }

    public override void follow_path(){}       
    public override void add_collider(){
        collider = game_object.AddComponent<BoxCollider>();        
    }       





}


