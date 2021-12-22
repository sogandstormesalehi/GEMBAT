using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour {

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
            Invoke("FallDown", 0.2f);
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2.0f);
    }
}
