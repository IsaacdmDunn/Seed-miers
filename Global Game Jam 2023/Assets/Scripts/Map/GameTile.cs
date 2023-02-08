using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    public int TileType;
    public int mapX;
    public int mapY;
    public string tileName;
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject BuildingSlot;
    [SerializeField] public GameObject EffectSlot;
    public List<Resource> resources = new List<Resource>();
    public bool allowBuilding = true;

    private void Start()
    {
        int randomResource = Random.Range(0, 4);
        resources.Add(new Resource());
        
        resources[0].resourceTypes = (Resource.ResourceTypes)randomResource;
        switch (randomResource)
        {
            case 0:
                resources[0].resourceName = "None";
                break;
            case 1:
                resources[0].resourceName = "Nitrogen";
                break;
            case 2:
                resources[0].resourceName = "Phosphorus";
                break;
            case 3:
                resources[0].resourceName = "Potassium";
                break;
        }

        mapX = Mathf.RoundToInt(gameObject.transform.position.x);
        mapY = Mathf.RoundToInt(gameObject.transform.position.y);

        switch (TileType)
        {
            case 0:
                tileName = "Dirt";
                break;
            case 1:
                tileName = "Sandy Loam"; //sandy loam who is she
                resources[0].amount = Random.Range(0, 50);
                break;
            case 2:
                tileName = "Detritus"; //sandy loam who is she
                resources[0].amount = Random.Range(0, 1000);
                break;
            case 3:
                tileName = "Sky"; 
                break;
        }
    }

    public void OnMouseEnter()
    {
        cursor.transform.position = new Vector3(mapX, mapY, 1);
        cursor.GetComponent<TileDescription>().onUpdate = true;
        allowBuilding = true;
    }

    public void OnMouseExit()
    {
        allowBuilding = false;
    }

}
