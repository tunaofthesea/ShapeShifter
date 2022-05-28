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

    public void generate_by(){
        if (left_off < objs.Length){
        objs[left_off] = new Cube(left_off, new Vector3(x,y,z));
        x += 1 ;
        left_off += 1;
        }
    }
    public void generate_at(Vector3 pos, Vector3 d){
        if (left_off < objs.Length){
        objs[left_off] = new Cube(left_off, pos);
        objs[left_off].set_destination(d);
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

}


