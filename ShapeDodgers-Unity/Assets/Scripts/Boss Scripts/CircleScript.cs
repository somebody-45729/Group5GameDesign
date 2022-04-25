/****
 * Created by: Haley Kelly
 * Date Created: April 16, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 23, 2022
 *
 * Description: attach to circle boss! forms circle attack patterns!
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  // Move(1, new Vector3(0, 2, 0));

public class CircleScript : BossScript
{
    public GameObject BulletSpawner;
    BulletSpawner b;

    void Start()
    {
      b = BulletSpawner.GetComponent<BulletSpawner>();
        StartCoroutine( StartPatterns() ); // start patterns
    } // end start

    void FixedUpdate(){
    }

      IEnumerator StartPatterns() {
        movespeed = 2; newpos = new Vector3(2, 0, 0);
        StartCoroutine( GenerateConstantCircles() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstDancingSpeed4() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstDancingSpeed4() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( RepeatFireRandom() );
        StartCoroutine( GenerateConstantCircles2() );
        yield return new WaitForSeconds(10f);
        StartCoroutine( GenerateConstantCircles3() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern1() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePattern2() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( CurvePatternRepeat() );
        yield return new WaitForSeconds(1f);
        StartCoroutine( RepeatFireRandom() );
        yield return new WaitForSeconds(10f);
        StartCoroutine( CurvePatternRepeat() );
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstDancingSpeed4() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstSpeed8() );
        yield return new WaitForSeconds(2f);
        StartCoroutine( PatternCircleBurstDancingSpeed4() );
        yield return new WaitForSeconds(2f);


      }

    /************** FOR PATTERNS: **************
      yield return new WaitForSeconds(0.5f); // waits 0.5 seconds

      b.ShootOne(angle, speed);
          * For angle: Q1 == 0 to 45 ; Q2 == 45 to 90; Q3 == 90 to 135; Q4 == 135 to 180/0
          * 4 - 8 seem like reasonable speeds.

      b.ShootOneSin(angle, speed, amplitude);
          * For angle: Q1 == 0 to 45 ; Q2 == 45 to 90; Q3 == 90 to 135; Q4 == 135 to 180/0
          * 4 - 8 seem like reasonable speeds.
          * Amplitude determines the intensity of the wave. 8 seemms noticable.


    */

    IEnumerator CurvePattern1() {
        b.ShootOneCircle(0, 5, 1f); b.ShootOneCircle(45, 5, 1f);
        b.ShootOneCircle(90, 5, 1f); b.ShootOneCircle(135, 5, 1f);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOneCircle(0, 5, 1f); b.ShootOneCircle(45, 5, 1f);
        b.ShootOneCircle(90, 5, 1f); b.ShootOneCircle(135, 5, 1f);
        b.ShootOneCircle(22.5f, 5, 1f); b.ShootOneCircle(67.5f, 5, 1f);
        b.ShootOneCircle(112.5f, 5, 1f); b.ShootOneCircle(157.5f, 5, 1f);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
    } // end

    IEnumerator CurvePattern2() {
        b.ShootOneCircle(15, 5, 1f); b.ShootOneCircle(60, 5, 1f);
        b.ShootOneCircle(105, 5, 1f); b.ShootOneCircle(150, 5, 1f);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOneCircle(37.5f, 5, 1f); b.ShootOneCircle(82.5f, 5, 1f);
        b.ShootOneCircle(127.5f, 5, 1f); b.ShootOneCircle(172.5f, 5, 1f);
        b.ShootOneCircle(15, 5, 1f); b.ShootOneCircle(60, 5, 1f);
        b.ShootOneCircle(105, 5, 1f); b.ShootOneCircle(150, 5, 1f);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
    } // end

    IEnumerator GenerateConstantCircles() {
        b.ShootOneCircle(0, 2, 4); b.ShootOneCircle(45, 2, 4);
        b.ShootOneCircle(90, 2, 4); b.ShootOneCircle(135, 2, 4);
        yield return new WaitForSeconds(2f); // waits 0.5 seconds
    } // end

      IEnumerator GenerateConstantCircles2() {
          b.ShootOneCircle(0, 3, 8); b.ShootOneCircle(45, 3, 8);
          b.ShootOneCircle(90, 3, 8); b.ShootOneCircle(135, 3, 8);
          yield return new WaitForSeconds(2f); // waits 0.5 seconds
          b.ShootOneCircle(0, 4, 12); b.ShootOneCircle(45, 4, 12);
          b.ShootOneCircle(90, 4, 12); b.ShootOneCircle(135, 4, 12);
      }

      IEnumerator GenerateConstantCircles3() {
          b.ShootOneCircle(0, 4, 12); b.ShootOneCircle(45, 4, 12);
          b.ShootOneCircle(90, 4, 12); b.ShootOneCircle(135, 4, 12);
          yield return new WaitForSeconds(2f); // waits 0.5 seconds
      }

    IEnumerator PatternHugeSin() {
        b.ShootOneSin(0, 2, 40); b.ShootOneSin(90, 2, 40);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOneSin(45, 2, 60); b.ShootOneSin(135, 2, 60);
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        InvokeRepeating("FireSinBarrierLines", 0f, 4f);
        yield return new WaitForSeconds(20f);
        CancelInvoke();
    } // end patternTwo

    IEnumerator PatternCircleBurstSpeed8() { // Makes a circular burst at speed 8
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOne(0, 8); b.ShootOne(12, 8); b.ShootOne(24, 8); b.ShootOne(36, 8); b.ShootOne(48, 8);
        b.ShootOne(60, 8); b.ShootOne(72, 8); b.ShootOne(84, 8); b.ShootOne(96, 8); b.ShootOne(108, 8);
        b.ShootOne(120, 8); b.ShootOne(132, 8); b.ShootOne(144, 8); b.ShootOne(156, 8); b.ShootOne(168, 8);
        yield return new WaitForSeconds(0.5f);
    } // end patternThree

    IEnumerator PatternCircleBurstDancingSpeed4() { // Makes a circular burst at speed 8
        yield return new WaitForSeconds(0.5f); // waits 0.5 seconds
        b.ShootOneSin(0, 4, 30); b.ShootOneSin(12, 4, 30); b.ShootOneSin(24, 4, 30); b.ShootOneSin(36, 4, 30); b.ShootOneSin(48, 4, 30);
        b.ShootOneSin(60, 4, 30); b.ShootOneSin(72, 4, 30); b.ShootOneSin(84, 4, 30); b.ShootOneSin(96, 4, 30); b.ShootOneSin(108, 4, 30);
        b.ShootOneSin(120, 4, 30); b.ShootOneSin(132, 4, 30); b.ShootOneSin(144, 4, 30); b.ShootOneSin(156, 4, 30); b.ShootOneSin(168, 4, 30);
        yield return new WaitForSeconds(0.5f);
    } // end patternThree

    void Curve1() { // Fires a bullet at speed 4 in each quadrant
      b.ShootOneCircle(0, 5, 1f); b.ShootOneCircle(45, 5, 1f);
      b.ShootOneCircle(90, 5, 1f); b.ShootOneCircle(135, 5, 1f);
      b.ShootOneCircle(22.5f, 5, 1f); b.ShootOneCircle(67.5f, 5, 1f);
      b.ShootOneCircle(112.5f, 5, 1f); b.ShootOneCircle(157.5f, 5, 1f);
    }
    void Curve2() { // Fires a bullet at speed 4 in each quadrant
      b.ShootOneCircle(37.5f, 5, 1f); b.ShootOneCircle(82.5f, 5, 1f);
      b.ShootOneCircle(127.5f, 5, 1f); b.ShootOneCircle(172.5f, 5, 1f);
      b.ShootOneCircle(15, 5, 1f); b.ShootOneCircle(60, 5, 1f);
      b.ShootOneCircle(105, 5, 1f); b.ShootOneCircle(150, 5, 1f);
    }
    IEnumerator CurvePatternRepeat() { // sets FireRandom() on repeat for 10 seconds at speed 4
        InvokeRepeating("Curve1", 0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        InvokeRepeating("Curve2", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour
    IEnumerator RepeatFireRandomEasier() { // sets FireRandom() on repeat for 10 seconds at speed 4
        InvokeRepeating("FireRandomEasier", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour
    IEnumerator RepeatFireRandom() { // sets FireRandom() on repeat for 10 seconds at speed 4
        InvokeRepeating("FireRandom", 0f, 0.5f);
        yield return new WaitForSeconds(10f);
        CancelInvoke();
    } // end patternFour
    void FireRandom() { // Fires a bullet at speed 4 in each quadrant
        b.ShootOne(Random.Range(0f, 45f), Random.Range(4f, 10f)); b.ShootOne(Random.Range(45f, 90f), Random.Range(4f, 10f)); b.ShootOne(Random.Range(90f, 135f), Random.Range(4f, 10f)); b.ShootOne(Random.Range(135f, 180f), Random.Range(4f, 10f));
    } // end fireRandom
    void FireRandomEasier() { // Fires a bullet at speed 4 in each quadrant
        b.ShootOne(Random.Range(0f, 45f), 3); b.ShootOne(Random.Range(45f, 90f), 3); b.ShootOne(Random.Range(90f, 135f), 3); b.ShootOne(Random.Range(135f, 180f), 3);
    } // end fireRandom


  }
