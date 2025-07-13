using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class BattleController : MonoBehaviour
{

    // GameObjects that represent the physical location where Spirits are placed
    public GameObject friendlyPositionObject1, friendlyPositionObject2, friendlyPositionObject3, friendlyPositionObject4;
    public GameObject enemyPositionObject1, enemyPositionObject2, enemyPositionObject3, enemyPositionObject4;
    // Vector2s extracted from the GameObjects
    private Vector2 friendlyPosition1, friendlyPosition2, friendlyPosition3, friendlyPosition4;
    private Vector2 enemyPosition1, enemyPosition2, enemyPosition3, enemyPosition4;
    //Array to hold positions
    private Vector2[] enemyPositions = new Vector2[4];
    private Vector2[] friendlyPositions = new Vector2[4];

    // Spirit GameObjects
    public GameObject friendlySpirit1, friendlySpirit2, friendlySpirit3, friendlySpirit4;
    public GameObject enemySpirit1, enemySpirit2, enemySpirit3, enemySpirit4;
    // Lists that contain teams
    private List<GameObject> friendlyTeam = new List<GameObject>();
    private List<GameObject> enemyTeam = new List<GameObject>();
    // List that contains spirits in proper turn order
    private List<GameObject> spiritsInTurnOrder = new List<GameObject>();

    // Spirit Prefabs for testing
    public GameObject friendlySpiritPrefab, enemySpiritPrefab;

    // Bools that determine battle state
    bool battleOngoing = false;
    bool waitingForTurn = false;

    // UI text 
    public TextMeshProUGUI turnOrderDisplay;
    public TextMeshProUGUI battleAnnouncementDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        friendlySpirit1 = Instantiate(friendlySpiritPrefab);
        friendlySpirit1.name = "Carl";
        friendlySpirit2 = Instantiate(friendlySpiritPrefab);
        friendlySpirit2.name = "Billy";
        friendlySpirit3 = Instantiate(friendlySpiritPrefab);
        friendlySpirit3.name = "Steve";
        friendlySpirit4 = Instantiate(friendlySpiritPrefab);
        friendlySpirit4.name = "John";
        enemySpirit1 = Instantiate(enemySpiritPrefab);
        enemySpirit1.name = "Miranda";
        enemySpirit2 = Instantiate(enemySpiritPrefab);
        enemySpirit2.name = "Tiphany";
        enemySpirit3 = Instantiate(enemySpiritPrefab);
        enemySpirit3.name = "Jessica";
        enemySpirit4 = Instantiate(enemySpiritPrefab);
        enemySpirit4.name = "Angelina";


        // Extract the Vectors from the Position GameObjects and store them in variables for easier access
        friendlyPosition1 = friendlyPositionObject1.transform.position;
        friendlyPosition2 = friendlyPositionObject2.transform.position;
        friendlyPosition3 = friendlyPositionObject3.transform.position;
        friendlyPosition4 = friendlyPositionObject4.transform.position;
        enemyPosition1 = enemyPositionObject1.transform.position;
        enemyPosition2 = enemyPositionObject2.transform.position;
        enemyPosition3 = enemyPositionObject3.transform.position;
        enemyPosition4 = enemyPositionObject4.transform.position;
        friendlyPositions[0] = friendlyPosition1;
        friendlyPositions[1] = friendlyPosition2;
        friendlyPositions[2] = friendlyPosition3;
        friendlyPositions[3] = friendlyPosition4;
        enemyPositions[0] = enemyPosition1;
        enemyPositions[1] = enemyPosition2;
        enemyPositions[2] = enemyPosition3;
        enemyPositions[3] = enemyPosition4;


        // Add the spirits to their proper team
        friendlyTeam.Add(friendlySpirit1);
        friendlyTeam.Add(friendlySpirit2);
        friendlyTeam.Add(friendlySpirit3);
        friendlyTeam.Add(friendlySpirit4);
        enemyTeam.Add(enemySpirit1);
        enemyTeam.Add(enemySpirit2);
        enemyTeam.Add(enemySpirit3);
        enemyTeam.Add(enemySpirit4);

        //Link the spirits to announcer and battle controller
        foreach (GameObject spir in friendlyTeam)
        {
            spir.SendMessage("LinkBattleAnnouncementDisplay", battleAnnouncementDisplay);
            spir.SendMessage("LinkBattleController", this.gameObject);
        }
        foreach (GameObject spir in enemyTeam)
        {
            spir.SendMessage("LinkBattleAnnouncementDisplay", battleAnnouncementDisplay);
            spir.SendMessage("LinkBattleController", this.gameObject);
        }

        //Send the spirits to their proper position
        for (int i = 0; i < 4; i++)
        {
            friendlyTeam[i].transform.position = friendlyPositions[i];
        }
        for (int i = 0; i < 4; i++)
        {
            enemyTeam[i].transform.position = enemyPositions[i];
        }

        //Link the battle controller and announcer to each spirit
        foreach (GameObject spir in enemyTeam)
        {
            spir.SendMessage("LinkBattleAnnouncementDisplay", battleAnnouncementDisplay);
            spir.SendMessage("LinkBattleController", this.gameObject);
        }

        //Determine the turn order which also starts the first turn
        DetermineTurnOrder();
        battleOngoing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Iterate through the turns, retermine the turn order if it ends
        if (battleOngoing)
        {

        }
    }

    public void DetermineTurnOrder()
    {
        List<GameObject> temp = new List<GameObject>();

        //Add both teams to the temp list
        foreach (GameObject spir in friendlyTeam)
        {
            temp.Add(spir);
        }
        foreach (GameObject spir in enemyTeam)
        {
            temp.Add(spir);
        }

        int n = temp.Count;

        //Shuffle the temp list into the turn order
        while (n > 0)
        {
            n--;
            int i = Random.Range(0, temp.Count - 1);
            spiritsInTurnOrder.Add(temp[i]);
            temp.RemoveAt(i);
        }

        UpdateTurnOrderDisplay();
        spiritsInTurnOrder[0].SendMessage("TakeTurn");
    }

    public void UpdateTurnOrderDisplay()
    {
        turnOrderDisplay.text = "Turn Order";
        foreach (GameObject spir in spiritsInTurnOrder)
        {
            turnOrderDisplay.text += "\n" + spir.name;
        }
    }

    public void NextTurn()
    {
        spiritsInTurnOrder.RemoveAt(0);
        if (spiritsInTurnOrder.Count == 0)
        {
            DetermineTurnOrder();
            return;
        }

        spiritsInTurnOrder[0].SendMessage("TakeTurn");
    }
}

