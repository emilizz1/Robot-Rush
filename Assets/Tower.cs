﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targtEnemy;

	void Update ()
    {
        objectToPan.LookAt(targtEnemy);
	}
}
