/****
 * Created by: Haley Kelly
 * Date Created: April 16, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: April 16, 2022
 *
 * Description: general inheritance script for all bosses.
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript: MonoBehaviour
{
  /*
  // eye tracking player method
		- build using two layered circle child gameobjects; rotate according to mouse movements
	// bullet storage arraylist
		- add specialized bullets from individual bosses
	// movement method
		- two parameters? - move(direction, length)
		- can be called repeatedly from child class to move in set directions
	// pre-attack method
		- enemy changes color; call before any attack is initiated
		- play an audio cue?
	// fire method
		- two parameters? - fire(direction, bullet type from arraylist)
		- called repeatedly from child class to create attack patterns
    */

    public GameObject boss; // attach eye white gameobject!
    public GameObject eyeWhite; // attach eye white gameobject!
    public GameObject eyePupil; // attach eye pupil gameobject!
    public RectTransform pupilTransform;
    public SpriteRenderer bossSpriteRenderer;

    public Vector3 newpos = new Vector3(0, 0, 0);
    public float movespeed = 2f;

    void Start(){

       pupilTransform = eyePupil.GetComponent<RectTransform>();
       bossSpriteRenderer = GetComponent<SpriteRenderer>();
       bossSpriteRenderer.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
    } // end start

    void EyeTrackingPlayer(){ // FINISHED
      // eye tracking player
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector3 mouseDelta = mousePosition - eyeWhite.transform.position; // amount of change between current mouse + circle transform
      float maxMagnitude = eyeWhite.GetComponent<SphereCollider>().radius; // limit eye movement to spherical radius

      if(mouseDelta.magnitude > maxMagnitude)
      {
          mouseDelta.Normalize(); // sets the vector to the same direction, but length is 1.0
          mouseDelta *= maxMagnitude;
      }
      eyePupil.transform.position = (eyeWhite.transform.position) + mouseDelta;
    } // end fire

    void FixedUpdate(){
      EyeTrackingPlayer();
      boss.transform.position = Vector3.MoveTowards(boss.transform.position, newpos, movespeed * Time.deltaTime);

    } // end fixedupdate



} // end bossscript
