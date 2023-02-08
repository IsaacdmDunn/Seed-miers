using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] public GameObject buildingManager;
    [SerializeField] public MapSystem map;
    [SerializeField] BuildingSystem buildingSystem;
    [SerializeField] ResourceManager resourceManager;
    bool placementTileAllowed = false;
    bool placementTileTypeAllowed = false;
    int y;
    int x;
    public void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            y = Mathf.RoundToInt(transform.position.x);
            x = Mathf.RoundToInt(transform.position.y);
            int id = (y * map.mapY) + x;

            if (buildingSystem.ActiveRule.allTilesAllowed)
            {
                placementTileAllowed = true;
            }
            else
            {
                for (int i = 0; i < buildingSystem.ActiveRule.tilesAllowed.Count; i++)
                {
                    if (buildingSystem.ActiveRule.tilesAllowed[i] == id)
                    {
                        placementTileAllowed = true;
                        break;
                    }
                }
            }

            if (buildingSystem.ActiveRule.allTypesAllowed) {
                placementTileTypeAllowed = true;
            }
            else
            {
                for (int i = 0; i < buildingSystem.ActiveRule.allowedTileTypes.Length; i++)
                {
                    if (buildingSystem.ActiveRule.tilesAllowed[i] == map.MapTiles[id].GetComponent<GameTile>().TileType)
                    {
                        placementTileTypeAllowed = true;
                        break;
                    }
                }
            }

            if (placementTileAllowed && placementTileTypeAllowed)
            {
                if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot == null && map.MapTiles[id].GetComponent<GameTile>().allowBuilding == true && resourceManager.HasResources(buildingSystem.ActiveRule.resources))
                {
                    GameObject newBuidling = Instantiate(buildingSystem.SelectedBuilding, new Vector3(y, x, 0), Quaternion.identity, buildingManager.transform);
                    newBuidling.name = $"{buildingSystem.SelectedBuilding.name}";/*: X{x}Y{y}*/
                    newBuidling.GetComponent<Building>().id = id;

                    map.MapTiles[id].GetComponent<GameTile>().BuildingSlot = newBuidling;
                    buildingSystem.ActiveRule.Rule();

                    
                }
                Debug.Log("allowed");
                placementTileAllowed = false;
                placementTileTypeAllowed = false;
            }
            else
            {
                Debug.Log("fuck you Baltimore");
            }
           
            
           
        }
    }


    
}
