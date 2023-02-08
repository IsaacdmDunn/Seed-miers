using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool left, right, up, down = false;
    public int id;
    [SerializeField] Sprite[] sprite;
    [SerializeField] bool spriteAffectedByNeighbours = false;
    float harvestTimer = 1f;
    float harvestInterval = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        if (spriteAffectedByNeighbours)
        {
            CheckNeighbours();
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        


        if (harvestTimer > harvestInterval)
        {
            harvestTimer = 0f;

            if (gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources != null)
            {



                for (int i = 0; i < gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources.Count; i++)
                {
                    if (gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources[i].resourceName != "None")
                    {
                        if (gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources[i].amount > 0)
                        {
                            if (gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().BuildingSlot.name == "SmallRoots")
                            {
                                gameObject.GetComponentInParent<BuildingSystem>().resourceManager.resources[(int)gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources[0].resourceTypes - 1] += 1;
                                gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().resources[0].amount -= 1;

                            }
                        }
                    }
                }
            }

            if (gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id].GetComponent<GameTile>().BuildingSlot.name == "Stems")
            {
                gameObject.GetComponentInParent<BuildingSystem>().resourceManager.resources[4] += 10;
            }
            else
            {
                gameObject.GetComponentInParent<BuildingSystem>().resourceManager.resources[4] -= 1;
            }

            gameObject.GetComponentInParent<BuildingSystem>().resourceManager.UpdateUI();
        }
        else
        {
            harvestTimer += Time.deltaTime;
        }
        
        
    }

    public void CheckNeighbours()
    {

        if (this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot != null)
        {
            left = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().right = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().ChangeSprite();
        }
        else
        {
            left = false;
        }

        if (this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot != null)
        {
            right = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().left = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + this.gameObject.GetComponentInParent<BuildingSystem>().player.map.mapY].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().ChangeSprite();
        }
        else
        {
            right = false;
        }

        if (this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - 1].GetComponent<GameTile>().BuildingSlot != null)
        {
            down = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - 1].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().up = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id - 1].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().ChangeSprite();
        }
        else
        {
            down = false;
        }

        if (this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + 1].GetComponent<GameTile>().BuildingSlot != null)
        {
            up = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + 1].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().down = true;
            this.gameObject.GetComponentInParent<BuildingSystem>().player.map.MapTiles[id + 1].GetComponent<GameTile>().BuildingSlot.GetComponent<Building>().ChangeSprite();
        }
        else
        {
            up = false;
        }

        ChangeSprite();



       
    }

    public void ChangeSprite()
    {
        if (spriteAffectedByNeighbours)
        {
            if (left && right && up && down)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[7];
                gameObject.transform.Rotate(0, 0, 0f);
            }
            else if (left && up && down)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[6];
                gameObject.transform.Rotate(0, 0, 90f);
            }
            else if (left && up && down)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[6];
                gameObject.transform.Rotate(0, 0, -90);
            }
            else if (left && right && down)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[6];
                gameObject.transform.Rotate(0, 0, 180f);
            }
            else if (left && right && up)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[6];
                gameObject.transform.Rotate(0, 0, 0f);
            }

            else if (up && down)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[4];
                gameObject.transform.Rotate(0, 0, 0f);
            }
            else if (left && right)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[5];
                gameObject.transform.Rotate(0, 0, 0f);
            }

            else if (left)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[3];
                gameObject.transform.Rotate(0, 0, 0f);
            }
            else if (right)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[2];
                gameObject.transform.Rotate(0, 0, 0f);
            }
            else if (up)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
                gameObject.transform.Rotate(0, 0, 0f);
            }
            else if (down)
            {
                Debug.Log(sprite.Length);
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                gameObject.transform.Rotate(0, 0, 0f);
            }
        }
    }
}
