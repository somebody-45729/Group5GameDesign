/****
 * Created by: Kyunghoon Han
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 22, 2022
 *
 * Description: contains bullet motion properties ; reference: // https://www.youtube.com/watch?v=Mq2zYk5tW_E //
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject BulletSpawner;
    BulletSpawner b;
    Rigidbody2D rb;
    public bool shot = false;
    public float angle;
    public float speed;
    public int location;
    public float curve = 0f;
    public float moveOutSpeedx = 0f;
    public float moveOutSpeedy = 0f;
    public float expansion = 0f;

    float currCurve = 0f;
    float currExpansion = 1f;

    // Start is called before the first frame update
    void Start()
    {
      b = BulletSpawner.GetComponent<BulletSpawner>();
      rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (shot == true){
        currCurve += curve;
        currExpansion += expansion;
        transform.eulerAngles = new Vector3(0, 0, (currCurve + angle));
        transform.Translate(currExpansion *(transform.right * speed * Time.deltaTime + new Vector3(moveOutSpeedx, moveOutSpeedy, 0)));
      } // shot == true

    } // fixedupdate
}
