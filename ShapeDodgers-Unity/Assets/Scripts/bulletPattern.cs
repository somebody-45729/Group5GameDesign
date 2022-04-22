using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script started: 4/20/22 9:41 PM

// LAST UPDATED BY: Kyunghoon Han
// LAST UPDATED DATE: 4/20/22


public class bulletPattern : MonoBehaviour
{
    public static bulletPattern bulletInstance;

    [SerializeField]
    private GameObject aBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletInstance = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {

    }
}





// https://www.youtube.com/watch?v=Mq2zYk5tW_E (with modifications for 3D)