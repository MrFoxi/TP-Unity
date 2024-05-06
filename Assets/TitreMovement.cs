using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitreMovement : MonoBehaviour
{

    public Transform posA, posB;

    public int Speed;

    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .01f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .01f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }
}
