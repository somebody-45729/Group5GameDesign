/****
 * Created by: Kyunghoon Han
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 22, 2022
 *
 * Description: Spawns bullets; reference: // https://www.youtube.com/watch?v=Mq2zYk5tW_E //
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
      public bool loaded = false;
      public GameObject boss;
      public Queue<GameObject> projectiles = new Queue<GameObject>(); // round prefabs

      public GameObject projectilesContainer; // round prefabs
      BossScript bossScript;

      [Header("Pool Settings")]
      public GameObject projectilePrefab1;
      public int poolSize1 = 3;

    // Start is called before the first frame update
    void Start()
    {
      bossScript = boss.GetComponent<BossScript>();
      for (int i = 0; i < poolSize1; i++){
        GameObject projectileGO = Instantiate(projectilePrefab1);
        projectileGO.transform.parent = projectilesContainer.transform;
        projectiles.Enqueue(projectileGO);
        projectileGO.GetComponent<BulletScript>().location = i;
      } // end for
      loaded = true;
    }

    public void ShootOne(float angle, float speed){
      //bossScript.preAttack = true;
        if(projectiles.Count > 0){ // there is a bullet to shoot
          GameObject shootme = projectiles.Dequeue();
            Debug.Log("Bullet shot, " + projectiles.Count + " remaining in pool!");
          shootme.GetComponent<BulletScript>().shot = true;
          shootme.GetComponent<BulletScript>().angle = angle;
          shootme.GetComponent<BulletScript>().speed = speed;
        } // if
        else {
          Debug.Log(projectiles.Count + " bullets in pool! Increase pool size! ");
        }
    //bossScript.preAttack = false;
  } // end shootone

  public void ShootOneSin(float angle, float speed, float amplitude){
    //bossScript.preAttack = true;
      if(projectiles.Count > 0){ // there is a bullet to shoot
        GameObject shootme = projectiles.Dequeue();
          Debug.Log("Round bullet shot, " + projectiles.Count + " remaining in pool!");
        shootme.GetComponent<BulletScript>().shotSin = true;
        shootme.GetComponent<BulletScript>().angle = angle;
        shootme.GetComponent<BulletScript>().speed = speed;
        shootme.GetComponent<BulletScript>().amplitude = amplitude;
      } // if
      else {
        Debug.Log(projectiles.Count + " bullets in pool! Increase pool size! ");
      }
  //bossScript.preAttack = false;
} // end shootone

public void ShootOneCircle(float angle, float speed, float amplitude){
  //bossScript.preAttack = true;
    if(projectiles.Count > 0){ // there is a bullet to shoot
      GameObject shootme = projectiles.Dequeue();
        Debug.Log("Round bullet shot, " + projectiles.Count + " remaining in pool!");
      shootme.GetComponent<BulletScript>().shotCircle = true;
      shootme.GetComponent<BulletScript>().angle = angle;
      shootme.GetComponent<BulletScript>().speed = speed;
      shootme.GetComponent<BulletScript>().amplitude = amplitude;
    } // if
    else {
      Debug.Log(projectiles.Count + " bullets in pool! Increase pool size! ");
    }
//bossScript.preAttack = false;
} // end shootone


    public void LostLifeReset(){
      Transform bullet;

      projectiles.Clear();

      for (int i = 0; i < poolSize1; i++){
        bullet = projectilesContainer.transform.GetChild(i);
        bullet.gameObject.GetComponent<BulletScript>().shot = false;
        bullet.gameObject.GetComponent<BulletScript>().shotSin = false;
        bullet.gameObject.GetComponent<BulletScript>().shotCircle = false;
        bullet.position = boss.transform.position;
        if (bullet.transform.tag == "Projectile") {
            projectiles.Enqueue(bullet.gameObject);
            Debug.Log("Lost life. Enqueued bullets " + projectiles.Count);
          }
      } // end for
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      this.transform.position = boss.transform.position; // center on boss gameobject

      Transform bullet;
      for (int i = 0; i < poolSize1; i++){
        bullet = projectilesContainer.transform.GetChild(i);
        if ((bullet.gameObject.GetComponent<BulletScript>().shot)||(bullet.gameObject.GetComponent<BulletScript>().shotSin)||(bullet.gameObject.GetComponent<BulletScript>().shotCircle)){
          if ((bullet.transform.position.x > 17)||(bullet.transform.position.x < -13)||(bullet.transform.position.y > 8)||(bullet.transform.position.y < -7)){
            bullet.gameObject.GetComponent<BulletScript>().angle = 0f;
            bullet.gameObject.GetComponent<BulletScript>().speed = 0f;
            bullet.gameObject.GetComponent<BulletScript>().amplitude = 0f;
            bullet.gameObject.GetComponent<BulletScript>().shot = false;
            bullet.gameObject.GetComponent<BulletScript>().shotSin = false;
            bullet.gameObject.GetComponent<BulletScript>().shotCircle = false;
            bullet.transform.position = boss.transform.position;
            if (bullet.transform.tag == "Projectile") {
                projectiles.Enqueue(bullet.gameObject);
                Debug.Log("Enqueued bullet " + projectiles.Count);
              } // if
          } // off screen; reset position
        } // bullet was shot
      } // end for

    } // end fixedupdate
}
