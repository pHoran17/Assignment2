﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Object.DestroyObject(other.gameObject);
    }
}
