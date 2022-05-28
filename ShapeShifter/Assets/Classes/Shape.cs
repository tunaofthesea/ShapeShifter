using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    protected int ID;
    protected GameObject game_object;
    protected Collider collider;

    protected Vector3 destination;

    protected float speed;
    protected float range;
    protected float accepted_error;


    public Shape(int _id, Vector3 pos, Metrics ms, GameObject _game_object = null){
        ID = _id;
        if (_game_object == null) {
            _game_object = new GameObject();
        }
        game_object = _game_object;
        game_object.name = ID.ToString();
        game_object.AddComponent<Rigidbody>();
        game_object.GetComponent<Collider>().attachedRigidbody.useGravity = false;

        set_metrics(ms);

    }

    public static ShapeCreator(params Action<Vector3, Action<Shape>>[] configs){
        Shape s = new Shape();
        foreach(Action a in configs){
            a(s);
        }
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
    public virtual void add_collider( ){}

    static Action<Shape> with_position(Vector3 p){
        return (s) => s.game_object.transform.position = p;
    }

    static Action<Shape> with_destination(Vector3 d){
        return (s) => s.destination = d;
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
        }

        game_object.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }



}


