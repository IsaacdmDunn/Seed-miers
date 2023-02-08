using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] int startingNitrogen;
    [SerializeField] int startingPhosphorus;
    [SerializeField] int startingPotassium;
    [SerializeField] int startingWater;
    [SerializeField] int startingEnergy;

    [SerializeField] Text nitroTxt;
    [SerializeField] Text phosrTxt;
    [SerializeField] Text potasTxt;
    [SerializeField] Text waterTxt;
    [SerializeField] Text enrgyTxt;

    public int[] resources;

    public void Start()
    {
        resources[0] = startingNitrogen;
        resources[1] = startingPhosphorus;
        resources[2] = startingPotassium;
        resources[3] = startingWater;
        resources[4] = startingEnergy;

        UpdateUI();
    }

    public bool HasResources(int[] _resources)
    {
        for (int i = 0; i < _resources.Length; i++)
        {
            if (resources[i] - _resources[i] <= 0 )
            {
                
                return false;
            }
        }

        for (int i = 0; i < _resources.Length; i++)
        {
            resources[i] -= _resources[i];
        }
        UpdateUI();
        return true;
    }

    public void UpdateUI()
    {
        nitroTxt.text = resources[0].ToString();
        phosrTxt.text = resources[1].ToString();
        potasTxt.text = resources[2].ToString();
        waterTxt.text = resources[3].ToString();
        enrgyTxt.text = resources[4].ToString();
    }


    public void Update()
    {
        
    }
}
