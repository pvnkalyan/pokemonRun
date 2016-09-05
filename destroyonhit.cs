using UnityEngine;
using System.Collections;

public class destroyonhit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

    }


}
