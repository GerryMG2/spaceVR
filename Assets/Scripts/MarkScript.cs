using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform mark;
    public float degreesPerSecond;
    void Start()
    {
        mark = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mark.Rotate(Vector3.up* degreesPerSecond * Time.deltaTime,Space.Self);
    }
}
