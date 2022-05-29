using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationTest : MonoBehaviour
{
    Hive generator;
    GameObject plane;

    public int num = 10;
    public float period = 5.0f;
    public float timer = 0.0f;

    Vector3 d;
    Vector3 position; 

    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        int p_scale = 20;
        plane.transform.localScale = new Vector3(p_scale,p_scale,p_scale);
        plane.transform.position = new Vector3(0,-0.5f,0);
        generator = new Hive(num);

        d = new Vector3(0,Random.Range(8.0f, 12.0f), 0);

        Debug.Log("D: (" + d.x + "," + d.y + "," + d.z +  ")" );
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > period) {
            position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
            generator.generate_at(position, d);
            timer = 0.0f;
        }

        generator.chase();

    }
}
