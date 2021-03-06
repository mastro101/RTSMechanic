﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    GameObject gameObject { get; }
    Transform transform { get; }
    bool Selected { get; set; }
}
