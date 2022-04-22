/****
 * Created by: Haley Kelly
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 20, 2022
 *
 * Description: Spawns bullets
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
      public bool loaded = false;
      public GameObject boss;
      public Queue<GameObject> projectilesRound = new Queue<GameObject>(); // round prefabs
      public Queue<GameObject> projectilesLong = new Queue<GameObject>();  // long prefabs

      public GameObject projectilesRoundContainer; // round prefabs
      public GameObject projectilesLongContainer;  // long prefabs
      BossScript bossScript;

      [Header("Pool Settings")]
      public GameObject projectilePrefab1;
      public GameObject projectilePrefab2;
      public int poolSize1 = 3;
      public int poolSize2 = 3;

    // Start is called before the first frame update
    void Start()
    {
      bossScript = boss.GetComponent<BossScript>();
      for (int i = 0; i < poolSize1; i++){
        GameObject projectileGO = Instantiate(projectilePrefab1);
        projectileGO.transform.parent = projectilesRoundContainer.transform;
        projectilesRound.Enqueue(projectileGO);
        projectileGO.GetComponent<BulletScript>().location = i;
        projectileGO.GetComponent<BulletScript>().round = true;
      } // end for
      for (int i = 0; i < poolSize2; i++){
        GameObject projectileGO = Instantiate(projectilePrefab2);
        projectileGO.transform.parent = projectilesLongContainer.transform;
        projectilesLong.Enqueue(projectileGO);
        projectileGO.GetComponent<BulletScript>().location = i;
        projectileGO.GetComponent<BulletScript>().round = false;
      } // end for
      loaded = true;
    }

    public void ShootOne(bool round, float angle, float speed){
      //bossScript.preAttack = true;
      if (round){ // shoot a round bullet
        if(projectilesRound.Count > 0){ // there is a round bullet to shoot
          GameObject shootme = projectilesRound.Dequeue();
            Debug.Log("Round bullet shot, " + projectilesRound.Count + " remaining in pool!");
          shootme.GetComponent<BulletScript>().shot = true;
          shootme.GetComponent<BulletScript>().angle = angle;
          shootme.GetComponent<BulletScript>().speed = speed;
          shootme.GetComponent<BulletScript>().curve = 0f;
          shootme.GetComponent<BulletScript>().moveOutSpeedx = 0f;
          shootme.GetComponent<BulletScript>().moveOutSpeedy = 0f;
          shootme.GetComponent<BulletScript>().expansion = 0f;
        } // if
        else {
          Debug.Log(projectilesRound.Count + " round bullets in pool! Increase pool size! ");
        }
      } // if round
      else if (!round){ // shoot a long bullet
        if(projectilesLong.Count > 0){ // there is a round bullet to shoot
          GameObject shootme = projectilesLong.Dequeue();
            Debug.Log("Long bullet shot, " + projectilesLong.Count + " remaining in pool!");
          shootme.GetComponent<BulletScript>().shot = true;
          shootme.GetComponent<BulletScript>().angle = angle;
          shootme.GetComponent<BulletScript>().speed = speed;
          shootme.GetComponent<BulletScript>().curve = 0f;
          shootme.GetComponent<BulletScript>().moveOutSpeedx = 0f;
          shootme.GetComponent<BulletScript>().moveOutSpeedy = 0f;
          shootme.GetComponent<BulletScript>().expansion = 0f;
        } // if
        else {
          Debug.Log(projectilesLong.Count + " long bullets in pool! Increase pool size! ");
        }
      } // if not round
    //bossScript.preAttack = false;
  } // end shootone

  public void ShootOneSpin(bool round, float angle, float speed, float curve, float moveOutSpeedx, float moveOutSpeedy,
                            float expansion){
    //bossScript.preAttack = true;
    if (round){ // shoot a round bullet
      if(projectilesRound.Count > 0){ // there is a round bullet to shoot
        GameObject shootme = projectilesRound.Dequeue();
          Debug.Log("Round bullet shot, " + projectilesRound.Count + " remaining in pool!");
        shootme.GetComponent<BulletScript>().shot = true;
        shootme.GetComponent<BulletScript>().angle = angle;
        shootme.GetComponent<BulletScript>().speed = speed;
        shootme.GetComponent<BulletScript>().curve = curve;
        shootme.GetComponent<BulletScript>().moveOutSpeedx = moveOutSpeedx;
        shootme.GetComponent<BulletScript>().moveOutSpeedy = moveOutSpeedy;
        shootme.GetComponent<BulletScript>().expansion = expansion;
      } // if
      else {
        Debug.Log(projectilesRound.Count + " round bullets in pool! Increase pool size! ");
      }
    } // if round
    else if (!round){ // shoot a long bullet
      if(projectilesLong.Count > 0){ // there is a round bullet to shoot
        GameObject shootme = projectilesLong.Dequeue();
          Debug.Log("Long bullet shot, " + projectilesLong.Count + " remaining in pool!");
        shootme.GetComponent<BulletScript>().shot = true;
        shootme.GetComponent<BulletScript>().angle = angle;
        shootme.GetComponent<BulletScript>().speed = speed;
        shootme.GetComponent<BulletScript>().curve = curve;
        shootme.GetComponent<BulletScript>().moveOutSpeedx = moveOutSpeedx;
        shootme.GetComponent<BulletScript>().moveOutSpeedy = moveOutSpeedy;
        shootme.GetComponent<BulletScript>().expansion = expansion;
      } // if
      else {
        Debug.Log(projectilesLong.Count + " long bullets in pool! Increase pool size! ");
      }
    } // if not round
  //bossScript.preAttack = false;
} // end shootone



    public void ResetPosition(int location, bool round){
      Transform bullet;
      if (round)
        {
          bullet = projectilesRoundContainer.transform.GetChild(location);
          projectilesRound.Enqueue(bullet.gameObject);
          bullet.position = new Vector3(0,0,0);
          Debug.Log("Enqueued round bullet " + projectilesRound.Count);
        }
      else if (!round)
        {
          bullet = projectilesLongContainer.transform.GetChild(location);
          projectilesLong.Enqueue(bullet.gameObject);
          bullet.position = new Vector3(0,0,0);
          Debug.Log("Enqueued long bullet " + projectilesLong.Count);
        }
    } // reset position

    public void LostLifeReset(){
      Transform bullet;

      projectilesRound.Clear();
      projectilesLong.Clear();

      for (int i = 0; i < poolSize1; i++){
        bullet = projectilesLongContainer.transform.GetChild(i);
        bullet.gameObject.GetComponent<BulletScript>().shot = false;
        bullet.position = new Vector3(0,0,0);
        if (bullet.transform.tag == "ProjectileLong") {
            projectilesLong.Enqueue(bullet.gameObject);
            Debug.Log("Lost life. Enqueued long bullets " + projectilesLong.Count);
          }
      } // end for
      for (int i = 0; i < poolSize2; i++){
        bullet = projectilesRoundContainer.transform.GetChild(i);
        bullet.gameObject.GetComponent<BulletScript>().shot = false;
        bullet.position = new Vector3(0,0,0);
        if (bullet.transform.tag == "ProjectileRound") {
            projectilesRound.Enqueue(bullet.gameObject);
            Debug.Log("Lost life. Enqueued round bullets " + projectilesRound.Count);
          }
      } // end for
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      this.transform.position = boss.transform.position; // center on boss gameobject

      Transform bullet;
      for (int i = 0; i < poolSize1; i++){
        bullet = projectilesLongContainer.transform.GetChild(i);
        if (bullet.gameObject.GetComponent<BulletScript>().shot){
          if ((bullet.transform.position.x > 17)||(bullet.transform.position.x < -13)||(bullet.transform.position.y > 8)||(bullet.transform.position.y < -7)){
            bullet.gameObject.GetComponent<BulletScript>().angle = 0f;
            bullet.gameObject.GetComponent<BulletScript>().speed = 0f;
            bullet.gameObject.GetComponent<BulletScript>().shot = false;
            bullet.transform.position = new Vector3(0,0,0);
            if (bullet.transform.tag == "ProjectileLong") {
                projectilesLong.Enqueue(bullet.gameObject);
                Debug.Log("Enqueued long bullet " + projectilesLong.Count);
              } // long
          } // off screen; reset position
        } // bullet was shot
      } // end for
      for (int i = 0; i < poolSize2; i++){
        bullet = projectilesRoundContainer.transform.GetChild(i);
        if (bullet.gameObject.GetComponent<BulletScript>().shot){
          if ((bullet.transform.position.x > 17)||(bullet.transform.position.x < -13)||(bullet.transform.position.y > 8)||(bullet.transform.position.y < -7)){
            bullet.gameObject.GetComponent<BulletScript>().angle = 0f;
            bullet.gameObject.GetComponent<BulletScript>().speed = 0f;
            bullet.gameObject.GetComponent<BulletScript>().shot = false;
            bullet.transform.position = new Vector3(0,0,0);
            if (bullet.transform.tag == "ProjectileRound") {
                projectilesRound.Enqueue(bullet.gameObject);
                Debug.Log("Enqueued round bullet " + projectilesRound.Count);
              } // round
          } // off screen; reset position
        } // bullet was shot
      } // end for

    }
}
