using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTest : MonoBehaviour{
    Hive generator;
    GameObject plane;

    public int num = 320;

    Hashtable destinations = new Hashtable();
    int round = 0;

    Vector3 position; 

    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        int p_scale = 20;
        plane.transform.localScale = new Vector3(p_scale,p_scale,p_scale);
        plane.transform.position = new Vector3(0,-0.5f,0);
        generator = new Hive(num);

        Vector3[] d = new []{new Vector3(0, 5, 0)};
        int new_x = 5;
        float d_y = d[0].y;

        destinations.Add(0, d);
        destinations.Add(1, new []{ 
                                new Vector3(-new_x, d_y, 0), 
                                new Vector3(new_x, d_y, 0) 
                                });

        destinations.Add(2, new [] { 
                                new Vector3(-new_x, d_y, -new_x),  
                                new Vector3(-new_x, d_y, new_x),  
                                new Vector3(new_x, d_y, -new_x), 
                                new Vector3(new_x, d_y, new_x) 
                                });
        // generator.generate_random(d, mat);
        generator.generate_ordered_on_y_equals(d[0]);

        // generator.give_material(mat);
    }

    void Update()
    {
        if (generator.arrived_ones == num) {
            round = (round+1)%3;
            if (round == 0) round++;
            Debug.Log("round : " + round);
            Vector3[] new_targets = (Vector3[])destinations[round];
            // Debug.Log("new_targets : " + new_targets);
            for (int x=0; x <num; x++ ){
                generator.objs[x].set_destination( new_targets[x % new_targets.Length] );
                generator.arrived[x] = false;
            }
            generator.arrived_ones = 0;

        }

        generator.stay_in_range();
    }

}
