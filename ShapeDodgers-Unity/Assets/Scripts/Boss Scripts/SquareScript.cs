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
      if (b.loaded){ // ensure all bullet gameobjects have spawned in
        StartCoroutine( StartPatterns() ); // start patterns
      } // end if loaded
    } // end start

      IEnumerator StartPatterns() {
        StartCoroutine( RepeatFireRandomSpeed4() );
        yield return new WaitForSeconds(8f);
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(0.5f);
        movespeed = 2; newpos = new Vector3(2, 0, 0);
        StartCoroutine( RepeatFireRandomSpeed4() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( RepeatFireRandomSpeed6() );
        movespeed = 2; newpos = new Vector3(-2, 0, 0);
        yield return new WaitForSeconds(2f);
        movespeed = 2; newpos = new Vector3(0, 0, 0);
        StartCoroutine( RepeatFireRandomSpeed6() );
        movespeed = 4; newpos = new Vector3(4, 0, 0);
        yield return new WaitForSeconds(2f);
        movespeed = 4; newpos = new Vector3(-4, 0, 0);
        yield return new WaitForSeconds(2f);
      }

    /************** FOR PATTERNS: **************
      yield return new WaitForSeconds(0.5f); // waits 0.5 seconds

      b.ShootOne(angle, speed);
          * For angle: Q1 == 0 to 45 ; Q2 == 45 to 90; Q3 == 90 to 135; Q4 == 135 to 180/0
          * 8 seems like a reasonable speed.


    */

    /*IEnumerator PatternOne() {
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
    } // end patternTwo*/

    IEnumerator PatternCircleBurstSpeed8() { // Makes a circular burst at speed 8
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(0, 8); b.ShootOne(12, 8); b.ShootOne(24, 8); b.ShootOne(36, 8); b.ShootOne(48, 8);
        b.ShootOne(60, 8); b.ShootOne(72, 8); b.ShootOne(84, 8); b.ShootOne(96, 8); b.ShootOne(108, 8);
        b.ShootOne(120, 8); b.ShootOne(132, 8); b.ShootOne(144, 8); b.ShootOne(156, 8); b.ShootOne(168, 8);
        yield return new WaitForSeconds(0.5f);
    } // end patternThree

    IEnumerator RepeatFireRandomSpeed4() { // sets FireRandom() on repeat for 10 seconds at speed 4
        InvokeRepeating("FireRandomSpeed4", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour

    IEnumerator RepeatFireRandomSpeed6() { // sets FireRandom() on repeat for 10 seconds at speed 6
        InvokeRepeating("FireRandomSpeed6", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour

    IEnumerator RepeatFireRandomSpeed8() { // sets FireRandom() on repeat for 10 seconds at speed 8
        InvokeRepeating("FireRandomSpeed8", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour

    void FireRandomSpeed4() { // Fires a bullet at speed 4 in each quadrant
        b.ShootOne(Random.Range(0f, 45f), 4); b.ShootOne(Random.Range(45f, 90f), 4); b.ShootOne(Random.Range(90f, 135f), 4); b.ShootOne(Random.Range(135f, 180f), 4);
    } // end fireRandom
    void FireRandomSpeed6() { // Fires a bullet at speed 6 in each quadrant
        b.ShootOne(Random.Range(0f, 45f), 4); b.ShootOne(Random.Range(45f, 90f), 4); b.ShootOne(Random.Range(90f, 135f), 4); b.ShootOne(Random.Range(135f, 180f), 4);
    } // end fireRandom
    void FireRandomSpeed8() { // Fires a bullet at speed 8 in each quadrant
        b.ShootOne(Random.Range(0f, 45f), 4); b.ShootOne(Random.Range(45f, 90f), 4); b.ShootOne(Random.Range(90f, 135f), 4); b.ShootOne(Random.Range(135f, 180f), 4);
    } // end fireRandom


  }
