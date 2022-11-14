using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapeController : MonoBehaviour
{

    public float speed = 10f;
    private float dirrection = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.transform.Translate(new Vector3(speed* Time.deltaTime,0,0));
        if (speed > 10 || speed < -10){
            dirrection = -dirrection;
        }
        speed += 1f * dirrection * Time.deltaTime;

        transform.Rotate(new Vector3(0,0,360*speed * Time.deltaTime));

    }
}
