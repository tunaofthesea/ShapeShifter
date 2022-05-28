using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public Shape[] objs;

    int left_off;
    int x;
    int y;
    int z;

    Vector3 position;
    public Generator(int num) {
        objs = new Shape[num];
        left_off = 0;
        x = 0;
        y = 0;
        z = 0;
    }

    public void generate(){
        for (int i = 0; i < objs.Length; i++){
            objs[i] = new Cube(i, new Vector3(x,y,z));
            x += 1;
        }
    }

    public void generate_random(Vector3 d){
        for (int i = 0; i < objs.Length; i++){
            // position = new Vector3(Random.Range(0.0f, 25.0f), Random.Range(0.0f, 25.0f), Random.Range(0.0f, 25.0f));
            position = new Vector3(Random.Range(10.0f, 19.0f), 0, Random.Range(10.0f, 19.0f));
            objs[i] = new Cube(i, position);
            objs[i].set_destination(d);
        }
    }

    public void generate_at(Vector3 pos, Metrics m){
        if (left_off < objs.Length){
        objs[left_off] = new Cube(left_off, pos);
        left_off += 1;
        }
    }

    public void chase(){
        for (int i = 0; i < objs.Length; i++){
            if (i < left_off) {
                objs[i].moveToDestination();
            }
        }
    }

    public void stay_in_range(){
        for (int i = 0; i < objs.Length; i++){
                objs[i].stay_in_range();
        }
    }

}


