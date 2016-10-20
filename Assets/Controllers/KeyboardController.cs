using UnityEngine;
using System.Collections;
using System;

public class KeyboardController : MonoBehaviour,IController {


    public CharacterBaseModel Character { get; private set; }

    // Use this for initialization
    void Start () {
        Character = GetComponent<CharacterBaseModel>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move(Input.GetAxisRaw("Horizontal"));
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Action();
    }

    public void Move(float movement)
    {
        Character.Move(movement);
    }

    public void Action()
    {
        Character.Action();
    }
}
