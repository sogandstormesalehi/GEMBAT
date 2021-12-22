using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
