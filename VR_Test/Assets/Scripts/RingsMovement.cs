using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsMovement : MonoBehaviour
{
    public Transform Position;
    public Vector3 actualPosition;
    public float speed;
    public Transform[] posicionObjetivos;
    private int index = 0;
    private float lerp,f;

    // Start is called before the first frame update
    void Start()
    {
        lerp = 0;
        index = 0;
        Position = this.transform;
        Position.position = actualPosition;
        // posicionObjetivos = new Transform[m];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, posicionObjetivos[index].position, lerp);
        lerp += Time.deltaTime;

        if (lerp >= 1)
        {
            index++;

            if (index >= posicionObjetivos.Length)
            {
                index = 0;
            }
            lerp = 0;
        }

    }
}
