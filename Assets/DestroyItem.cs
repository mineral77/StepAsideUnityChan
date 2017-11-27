using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {


    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
