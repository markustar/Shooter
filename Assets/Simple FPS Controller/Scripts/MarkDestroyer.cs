﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDestroyer : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

}
