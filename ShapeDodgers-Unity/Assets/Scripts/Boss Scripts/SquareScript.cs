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

        StartCoroutine( PatternFour() );

        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternOne() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternTwo() );
        yield return new WaitForSeconds(0.5f);
        StartCoroutine( PatternOne() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternTwo() );
        yield return new WaitForSeconds(0.5f);
        StartCoroutine( PatternThree() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternThree() );
        yield return new WaitForSeconds(0.5f);
      }

    /************** FOR PATTERNS: **************
      yield return new WaitForSeconds(0.5f); // waits 0.5 seconds

      b.ShootOne(angle, speed);
          * For angle: Q1 == 0 to 45 ; Q2 == 45 to 90; Q3 == 90 to 135; Q4 == 135 to 180/0
          * 8 seems like a reasonable speed.


    */

    void FireRandom() { // fires a bullet in each direction
        b.ShootOne(Random.Range(0f, 45f), 4); b.ShootOne(Random.Range(45f, 90f), 4); b.ShootOne(Random.Range(90f, 135f), 4); b.ShootOne(Random.Range(135f, 180f), 4);
    } // end fireRandom

    IEnumerator PatternOne() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(0, 4); b.ShootOne(30, 4); b.ShootOne(60, 4); b.ShootOne(90, 4);
        yield return new WaitForSeconds(0.5f);
        b.ShootOne(90, 4); b.ShootOne(120, 4); b.ShootOne(150, 4); b.ShootOne(180, 4);
        yield return new WaitForSeconds(0.5f);
    } // end patternOne

    IEnumerator PatternTwo() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(90, 4); b.ShootOne(120, 4); b.ShootOne(150, 4); b.ShootOne(180, 4);
        yield return new WaitForSeconds(0.5f);
        b.ShootOne(0, 4); b.ShootOne(30, 4); b.ShootOne(60, 4); b.ShootOne(90, 4);
        yield return new WaitForSeconds(0.5f);
    } // end patternTwo

    IEnumerator PatternThree() {
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(0, 8); b.ShootOne(12, 8); b.ShootOne(24, 8); b.ShootOne(36, 8); b.ShootOne(48, 8);
        b.ShootOne(60, 8); b.ShootOne(72, 8); b.ShootOne(84, 8); b.ShootOne(96, 8); b.ShootOne(108, 8);
        b.ShootOne(112, 8); b.ShootOne(124, 8); b.ShootOne(136, 8); b.ShootOne(148, 8); b.ShootOne(152, 8);
        b.ShootOne(164, 8); b.ShootOne(176, 8);
        yield return new WaitForSeconds(0.5f);
    } // end patternThree

    IEnumerator PatternFour() {
        InvokeRepeating("FireRandom", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour

  }
