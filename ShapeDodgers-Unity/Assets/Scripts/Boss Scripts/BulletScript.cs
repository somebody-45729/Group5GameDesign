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
    public bool shotSin = false;
    public bool shotCircle = false;
    public float angle;
    public float speed;
    public float amplitude;
    public int location;

    // FOR SINWAVE
    private float theta = 0;
    private float thetaStep = Mathf.PI / 32f;

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
        transform.eulerAngles = new Vector3(0, 0, (angle));
        transform.Translate(transform.right * speed * Time.deltaTime);
      } // shot == true
      if (shotSin == true){
        theta += thetaStep;
        transform.eulerAngles = new Vector3(0, 0, (angle + amplitude * Mathf.Sin(theta)));
        transform.Translate(transform.right * speed * Time.deltaTime);
      } // shot == true
      if (shotCircle == true){
        theta += thetaStep;
        transform.eulerAngles = new Vector3(0, 0, (angle + amplitude * theta));
        transform.Translate(transform.right * speed * Time.deltaTime);
      } // shot == true

    } // fixedupdate
}
