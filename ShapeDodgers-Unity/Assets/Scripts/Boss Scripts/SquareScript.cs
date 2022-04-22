/****
 * Created by: Haley Kelly
 * Date Created: April 16, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 16, 2022
 *
 * Description: attach to square boss! forms square attack patterns!
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  // Move(1, new Vector3(0, 2, 0));

public class SquareScript : BossScript
{
    public GameObject BulletSpawner;
    BulletSpawner b;

    void Start()
    {
      b = BulletSpawner.GetComponent<BulletSpawner>();

      if (b.loaded){ // bullet gameobjects have spawned in

        // PLACE BULLET PATTERNS IN HERE; RUN THEM AS COROUTINES!
        StartCoroutine( StartPatterns() );




      } // end if loaded
    } // end start

      IEnumerator StartPatterns() {
        /*StartCoroutine( PatternOne() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternTwo() );*/
        yield return new WaitForSeconds(0.5f);
        StartCoroutine( PatternThree() );
      }

    /************** FOR PATTERNS: **************
      yield return new WaitForSeconds(0.5f); // waits 0.5 seconds

      b.ShootOne(round, angle, speed);
          * when round == true, a round bullet will be shot
          * when round == false, a long bullet will be shot
          * For angle: Q1 == 0 to 45 ; Q2 == 45 to 90; Q3 == 90 to 120; Q4 == 120 to 180/0
          * 8 seems like a reasonable speed.


    */

    IEnumerator PatternOne() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(true, 0, 8); b.ShootOne(true, 30, 8); b.ShootOne(true, 60, 8); b.ShootOne(true, 90, 8);
        yield return new WaitForSeconds(0.5f);
        b.ShootOne(true, 90, 8); b.ShootOne(true, 120, 8); b.ShootOne(true, 150, 8); b.ShootOne(true, 180, 8);
        yield return new WaitForSeconds(0.5f);
    } // end patternOne

    IEnumerator PatternTwo() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(true, 90, 8); b.ShootOne(true, 120, 8); b.ShootOne(true, 150, 8); b.ShootOne(true, 180, 8);
        yield return new WaitForSeconds(0.5f);
        b.ShootOne(true, 0, 8); b.ShootOne(true, 30, 8); b.ShootOne(true, 60, 8); b.ShootOne(true, 90, 8);
        yield return new WaitForSeconds(0.5f);
    } // end patternTwo

    IEnumerator PatternThree() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOneSpin(true, 0 , 2, 4, 0.05f, 0.05f, 0.02f); b.ShootOneSpin(true, 0 , 2, 4, 0.05f, 0.05f, 0.02f);
    } // end patternTwo

  }
