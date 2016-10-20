using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            collider.gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
