using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
    public GameObject upgradePanel; // UI panel for upgrade selection
    public Button[] upgradeButtons; // Buttons for upgrade choices
    public List<string> allUpgrades = new List<string> { "Speed Boost", "Extra Health", "Stronger Bullets", "Multi-Shot", "Forcefield", "Piercing Shot" };
    public List<Sprite> upgradeSprites; // List of upgrade icons, must match the order of allUpgrades
    private GameObject player;
    //storing the script that manages spawns so we know when to spawn the next round
    private GameObject forceField;
    private GameObject shot;
    private manageSpawn manageSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        forceField = GameObject.FindWithTag("forceField");
        shot = GameObject.FindWithTag("playerBullet");
        //finding the game manager so we can get its script to manage spawns 
        //this way we can change some of its variables
        GameObject gameManager = GameObject.FindWithTag("GameController");
        manageSpawn = gameManager.GetComponent<manageSpawn>();
        upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showUpgrades(){
        //Time.timeScale = 0;
        //TESTING
        Debug.Log("Attempting to show upgrade panel...");
        upgradePanel.SetActive(true);
        Debug.Log("Upgrade panel active state: " + upgradePanel.activeSelf);
        //TESTING

        List<string> selectedUpgrades = new List<string>();
        List<Sprite> selectedSprites = new List<Sprite>();

        while(selectedUpgrades.Count < 3){
            int index = Random.Range(0, allUpgrades.Count);
            if (!selectedUpgrades.Contains(allUpgrades[index]))
            {
                selectedUpgrades.Add(allUpgrades[index]);
                selectedSprites.Add(upgradeSprites[index]);
            }
        }

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].GetComponentInChildren<Text>().text = selectedUpgrades[i];
            upgradeButtons[i].GetComponent<Image>().sprite = selectedSprites[i];

            int index = allUpgrades.IndexOf(selectedUpgrades[i]);
            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() => applyUpgrade(index));
        }

    }

    public void applyUpgrade(int index){
        if (manageSpawn.upgradeChosen) return;

       string upgrade = allUpgrades[index];

        switch (upgrade)
        {
            case "Speed Boost":
                player.GetComponent<shipMovement>().thrustSpeed += 1.5f;
                break;
            case "Extra Health":
                player.GetComponent<PlayerHealth>().maxHealth += 10;
                break;
            case "Stronger Bullets":
                player.GetComponent<playerUpgradePrefs>().playerDamage += 5;
                break;
            case "Multi-Shot":
                player.GetComponent<playerUpgradePrefs>().multiShot = true;
                allUpgrades.RemoveAt(index);
                upgradeSprites.RemoveAt(index);
                break;
            case "Forcefield":
                forceField.GetComponent<Forcefield>().ActivateForcefield();
                allUpgrades.RemoveAt(index);
                upgradeSprites.RemoveAt(index);
                break;
            case "Piercing Shot":
                player.GetComponent<playerUpgradePrefs>().pierceShot = true;
                allUpgrades.RemoveAt(index);
                upgradeSprites.RemoveAt(index);
                break;
        }

        upgradePanel.SetActive(false);
        manageSpawn.upgradeChosen = true;
    }
}
