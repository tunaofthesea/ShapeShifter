using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive
{
    public Shell[] objs;
    private Material material; 

    private int left_off;
    public int arrived_ones = 0;
    public bool[] arrived;


    Vector3 position;
    Metrics metrics;

    public Hive(int num, Metrics m = null) {
        objs = new Shell[num];
        arrived = new bool[num];
        for (int i=0; i < arrived.Length; i++) arrived[i] = false;
        material = Resources.Load("Materials/Violet", typeof(Material)) as Material;

        if (m == null){
            m = new Metrics();
        }
        metrics = m;
        left_off = 0;
    }


    public void generate_random(Vector3 d){
        for (int i = 0; i < objs.Length; i++){
            // position = new Vector3(Random.Range(0.0f, 25.0f), Random.Range(0.0f, 25.0f), Random.Range(0.0f, 25.0f));
            position = new Vector3(Random.Range(10.0f, 19.0f), 0, Random.Range(10.0f, 19.0f));
            objs[i] = CubeShell.CubeShellCreator(i, metrics, 
                                        Shell.with_position(position),
                                        Shell.with_destination(d),
                                        Shell.with_material(material)
                                        );
        }
    }

    public void generate_at(Vector3 pos, Vector3 d){
        if (left_off < objs.Length){
            objs[left_off] = CubeShell.CubeShellCreator(left_off, metrics, 
                                        Shell.with_position(pos),
                                        Shell.with_destination(d),
                                        CubeShell.with_material(material)
                                        );

        left_off += 1;
        }
    }

    public void generate_ordered_on_y_equals(Vector3 d, int y=0 ){
        int num_rows = 16;
        int num_cols = objs.Length/(num_rows*4);
        int i = 0;
        for (int x=-num_rows; x <num_rows; x++ ){
            for (int z = -num_cols; z <num_cols; z++ ){
                objs[i] = CubeShell.CubeShellCreator(i, metrics, 
                                        Shell.with_position(new Vector3(x, y, z)),
                                        Shell.with_destination(d),
                                        CubeShell.with_material(material)
                                        );
                i++;
            }
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
                if (!arrived[i]){
                    if (objs[i].arrived){
                    arrived_ones ++;
                    arrived[i] = true;
                    }
                }
        }
    }

}


