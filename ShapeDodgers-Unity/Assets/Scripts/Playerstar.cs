using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstar : MonoBehaviour
{
    GameManager gm; //reference to game manager
    public GameObject bulletSpawner;

    public float speed = 1f;
    public float dashLength = 1f;
    private bool disableNextFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager
        this.GetComponent<TrailRenderer>().emitting = false;

    }

    void OnCollisionEnter2D(Collision2D hitBy)
    {
        if (hitBy.transform.tag == "Boss")
        {
            Debug.Log("Boss hit player!");
            this.GetComponent<TrailRenderer>().emitting = false; //stop dash animation before move starts
            this.transform.position = new Vector3(-10, -3.5f, 0);
            gm.LostLife();
            bulletSpawner.GetComponent<BulletSpawner>().LostLifeReset();
        }
        else if ((hitBy.transform.tag == "ProjectileLong")||(hitBy.transform.tag == "ProjectileRound"))
        {
            Debug.Log("Projectile hit player!");
            this.GetComponent<TrailRenderer>().emitting = false; //stop dash animation before move starts
            gm.LostLife();
            bulletSpawner.GetComponent<BulletSpawner>().LostLifeReset();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(disableNextFrame)
        {
            this.GetComponent<TrailRenderer>().emitting = false;
            disableNextFrame = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<TrailRenderer>().emitting = true;
            if (Vector3.Magnitude(targetPos - transform.position) > dashLength)
            {
                var directionVector = Vector3.Normalize(targetPos - transform.position);
                transform.position = transform.position + dashLength * directionVector;
            }
            else
            {
                transform.position = targetPos;
            }
            disableNextFrame = true;
        }
    }
}
