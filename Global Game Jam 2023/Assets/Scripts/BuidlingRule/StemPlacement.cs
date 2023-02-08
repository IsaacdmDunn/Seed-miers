using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Stem")]
public class StemPlacement : BuildingRule
{
    int id;
    // Start is called before the first frame update
    public override void Rule()
    {
        allTypesAllowed = true;
        tilesAllowed.Clear();
        for (int y = 1; y < map.mapY-1; y++)
        {
            for (int x = 1; x < map.mapX-1; x++)
            {
                
                id = (y * map.mapY) +x;
                
                if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot != null)
                {
                    
                   
                    
                    if (map.MapTiles[id].GetComponent<GameTile>().BuildingSlot.name == "Seed")
                    {
                        
                        tilesAllowed.Add(id + 1); //stores map id in tiles allowed
                        
                    }
                    else if(map.MapTiles[id].GetComponent<GameTile>().BuildingSlot.name == "Stems")
                    {
                        tilesAllowed.Add(id - map.mapY);
                        tilesAllowed.Add(id + map.mapY);
                        tilesAllowed.Add(id + 1);
                        tilesAllowed.Add(id - 1);
                    }
                    Debug.Log("stem");
                }
                foreach (int tileType in allowedTileTypes)
                {
                    
                }
                
                
            }
        }
    }

    
}
