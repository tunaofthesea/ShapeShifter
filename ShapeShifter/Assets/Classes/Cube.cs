using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    public Cube(int _id, Vector3 pos) : base(_id, pos, GameObject.CreatePrimitive(PrimitiveType.Cube)) {

        add_collider();

        Debug.Log("<color=green>Cube object with id " 
                    + ID + " at position (" 
                    + game_object.transform.position.x + "," 
                    + game_object.transform.position.y + "," 
                    + game_object.transform.position.z + " ) created</color>");

    }

    public override void follow_path(){}       
    public override void add_collider(){
     game_object.AddComponent<BoxCollider>();        
    }       

    

}


