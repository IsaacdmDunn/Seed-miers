using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public enum ResourceTypes
    {
        None,
        Nitrogen,
        Phosphorus,
        Potassium,
        Energy,
        Water,
    }
    public int amount = 0;
    public string resourceName = "None";
    public ResourceTypes resourceTypes;
}
