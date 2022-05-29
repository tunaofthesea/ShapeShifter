using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Shell {
    protected int ID;

    protected float speed;
    protected float range;
    protected float accepted_error;
    
    protected Vector3 destination;

    public GameObject game_object;

    public bool arrived;

    public Shell(int _id, Vector3 pos, Metrics ms, GameObject go = null){
        ID = _id;
        if (go == null){
            go = new GameObject();
        }
        game_object = go;
        game_object.name = ID.ToString();
        game_object.AddComponent<Rigidbody>();
        game_object.GetComponent<Collider>().attachedRigidbody.useGravity = false;

        set_metrics(ms);
        arrived=false;

    }

    public int get_id(){
        return ID;
    }

    public void set_metrics(Metrics m){
        speed = m.speed;
        range = m.range;
        accepted_error = m.accepted_error;
    }

    public virtual void follow_path(){}
    public virtual void add_collider(){}

    public static Action<Shell> with_position(Vector3 p){
        return (s) => s.game_object.transform.position = p;
    }

    public static Action<Shell> with_destination(Vector3 d){
        return (s) => s.destination = d;
    }

    public void set_destination(Vector3 d){
        destination = d;
    }

    public static Action<Shell> with_material(Material m){
        return (c) => c.game_object.GetComponent<MeshRenderer>().material = m;
    }

	public void scale(Vector3 _scale){
        game_object.transform.localScale += _scale;
    }
	public void rotate(Vector3 _rotation){
        game_object.transform.Rotate(_rotation, Space.Self);
    }


    public void moveToDestination(){
        if(game_object.transform.position != destination){
            game_object.transform.position = Vector3.MoveTowards(
                game_object.transform.position, 
                destination, 
                speed * Time.deltaTime);
		}
    }

    public void stay_in_range(){
        float d = Vector3.Distance(game_object.transform.position, destination) - range;


        if( d > accepted_error ){ // farther
            game_object.transform.position = Vector3.MoveTowards(
                game_object.transform.position, 
                destination, 
                speed * Time.deltaTime);
		}else if (Mathf.Abs(d) > accepted_error){ // closer

            Vector3 new_aim = -destination;
            game_object.transform.position = Vector3.MoveTowards(
                game_object.transform.position, 
                new_aim, 
                speed * Time.deltaTime);
        }else{
        arrived = Mathf.Abs(d) < accepted_error;
        }
        game_object.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }



}


