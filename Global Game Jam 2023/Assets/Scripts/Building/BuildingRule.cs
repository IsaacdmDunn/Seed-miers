using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingRule : ScriptableObject
{
    [SerializeField] public string description = "This building can be placed anywhere";
    [SerializeField] public int[] allowedTileTypes;
    [SerializeField] public bool allTypesAllowed = false;
    [SerializeField] public List<int> tilesAllowed = new List<int>();
    [SerializeField] public bool allTilesAllowed = false;
    [SerializeField] public bool rotatable = false;
    [SerializeField] public bool recursive = false;

    [SerializeField] public int rotation = 0; //0=left, 1=right, 2=down, 3=up 

    [SerializeField] public MapSystem map;
    public int[] resources;
    public virtual void Rule() { }
    
}
