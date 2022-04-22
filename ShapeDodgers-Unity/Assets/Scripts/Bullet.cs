using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script started: 4/20/22 9:41 PM

// LAST UPDATED BY: Kyunghoon Han
// LAST UPDATED DATE: 4/20/22

public class Bullet : MonoBehaviour
{

    private Vector3 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void setMoveDirection(Vector3 direct)
    {
        moveDirection = direct;
    }

    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}


// https://www.youtube.com/watch?v=Mq2zYk5tW_E (with modifications for 3D)