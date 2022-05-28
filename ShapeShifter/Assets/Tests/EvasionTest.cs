using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasionTest : MonoBehaviour
{
    Generator generator;
    GameObject plane;

    public int num = 2;
    public float period = 5.0f;
    public float timer = 0.0f;

    Vector3 pos_1, pos_2, d; 

    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        int p_scale = 20;
        plane.transform.localScale = new Vector3(p_scale,p_scale,p_scale);
        plane.transform.position = new Vector3(0,-0.5f,0);

        generator = new Generator(num);

        float coor_range = 10.0f;
        pos_1 = new Vector3(Random.Range(-coor_range, coor_range), 0, Random.Range(-coor_range, coor_range));
        pos_2 = new Vector3(Random.Range(-coor_range, coor_range), 0, Random.Range(-coor_range, coor_range));
        d = Vector3.Lerp(pos_1, pos_2, 0.5f);

        generator.generate_at(pos_1, d);
        generator.generate_at(pos_2, d);
        
        Debug.Log("D: (" + d.x + "," + d.y + "," + d.z +  ")" );
    }

    void Update()
    {
        generator.chase();
    }
}
