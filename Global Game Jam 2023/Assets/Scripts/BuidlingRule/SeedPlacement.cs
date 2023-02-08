using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rules/Seed")]
public class SeedPlacement : BuildingRule
{
    
    // Start is called before the first frame update
    public override void Rule()
    {
        allTypesAllowed = true;
        int mapID = 19;
        int id = 0;
        for (int y = 0; y < map.mapY; y++)
        {
            for (int x = 19; x > 16; x--)
            {
                tilesAllowed.Add((y * map.mapY) + x); //stores map id in tiles allowed#
                id++;
                mapID--;
            }
            mapID += 20;
        }

    }

    
}
