/****
 * Created by: J.P. Tucker
 * Date Created: April 15, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 23, 2022
 *
 * Description: controls player movement
****/

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
        else if (hitBy.transform.tag == "Projectile")
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
        if ((targetPos.x < 9.5)&&(targetPos.x > -9.5)&&(targetPos.y < 6)&&(targetPos.y > -4)){
          transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

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
