using UnityEngine;

public class BattleController : MonoBehaviour
{

    // GameObjects that represent the physical location where Spirits are placed
    public GameObject friendlyPositionObject1, friendlyPositionObject2, friendlyPositionObject3, friendlyPositionObject4;
    public GameObject enemyPositionObject1, enemyPositionObject2, enemyPositionObject3, enemyPositionObject4;
    // Vector2s extracted from the GameObjects
    private Vector2 friendlyPosition1, friendlyPosition2, friendlyPosition3, friendlyPosition4;
    private Vector2 enemyPosition1, enemyPosition2, enemyPosition3, enemyPosition4;

    // Spirit GameObjects
    public GameObject friendlySpirit1, friendlySpirit2, friendlySpirit3, friendlySpirit4;
    public GameObject enemySpirit1, enemySpirit2, enemySpirit3, enemySpirit4;

        // Spirit Prefabs for testing
        public GameObject friendlySpiritPrefab, enemySpiritPrefab;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Extract the Vectors from the Position GameObjects and store them in variables for easier access
        friendlyPosition1 = friendlyPositionObject1.transform.position;
        friendlyPosition2 = friendlyPositionObject2.transform.position;
        friendlyPosition3 = friendlyPositionObject3.transform.position;
        friendlyPosition4 = friendlyPositionObject4.transform.position;
        enemyPosition1 = enemyPositionObject1.transform.position;
        enemyPosition2 = enemyPositionObject2.transform.position;
        enemyPosition3 = enemyPositionObject3.transform.position;
        enemyPosition4 = enemyPositionObject4.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
