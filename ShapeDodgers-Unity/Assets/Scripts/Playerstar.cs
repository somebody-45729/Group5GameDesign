using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstar : MonoBehaviour
{
    public float speed = 1f;
    public float dashLength = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector3.Magnitude(targetPos - transform.position) > dashLength)
            {
                var directionVector = Vector3.Normalize(targetPos - transform.position);
                transform.position = transform.position + dashLength * directionVector;
            }
            else
            {
                transform.position = targetPos;
            }
        }
    }
}
