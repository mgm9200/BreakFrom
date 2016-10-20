using UnityEngine;
using System.Collections;

public class CharacterView : MonoBehaviour {

    public Animator anim;
    public CharacterBaseModel character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {   
        anim.SetBool("Ground", character.Grounded);
        anim.SetFloat("Speed", Mathf.Abs(character.Movement));
        anim.SetFloat("vSpeed", character.vSpeed);
        anim.SetBool("Hang", character.Hang);
    }

    
}
