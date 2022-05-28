using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    protected int ID;
    protected GameObject game_object;
    protected Vector3 destination;
    protected float speed;

    public Shape(int _id, Vector3 pos, GameObject _game_object = null){
        ID = _id;
        if (_game_object == null) {
            _game_object = new GameObject();
        }
        game_object = _game_object;
        game_object.transform.position = pos;
        game_object.name = ID.ToString();
        game_object.AddComponent<Rigidbody>();
        game_object.GetComponent<Collider>().attachedRigidbody.useGravity = false;

        speed = 0.4f;

        Debug.Log("<color=green>Shape object with id " 
                    + ID + " at position (" 
                    + game_object.transform.position.x + "," 
                    + game_object.transform.position.y + "," 
                    + game_object.transform.position.z + " ) created</color>");

    }

    public virtual void follow_path(){}
	public void scale(Vector3 _scale){
        // scl_amt = self.behavior.scale_amount
        game_object.transform.localScale += _scale;
    }
	public void rotate(Vector3 _rotation){
        game_object.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);

    }
    public virtual void add_collider( ){}

    public void set_destination(Vector3 _d){
        destination = _d;
    }

    public void moveToDestination(){
        if(game_object.transform.position != destination){
            game_object.transform.position = Vector3.MoveTowards(game_object.transform.position, destination, speed * Time.deltaTime);
		}
    }


}


