using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTest : MonoBehaviour
{
    Generator generator;
    GameObject plane;

    public int num = 20;

    Vector3 d;
    Vector3 position; 

    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        int p_scale = 20;
        plane.transform.localScale = new Vector3(p_scale,p_scale,p_scale);
        plane.transform.position = new Vector3(0,-0.5f,0);
        generator = new Generator(num);
        d = new Vector3(0, 5, 0);
        generator.generate_random(d);
        Debug.Log("D: (" + d.x + "," + d.y + "," + d.z +  ")" );
    }

    void Update()
    {
        generator.stay_in_range();

    }
}
