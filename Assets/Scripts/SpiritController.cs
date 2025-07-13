using TMPro;
using UnityEngine;
using System.Collections;

public class SpiritController : MonoBehaviour
{
    // Spirit UI
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI healthDisplay;

    // Battle UI
    public TextMeshProUGUI battleAnnouncementDisplay;

    // Bools for spirit state
    bool isTurn = false;
    bool isAttacking = false;

    public GameObject battleController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Temporarily putting this in update
        nameDisplay.text = this.name;

        if (isTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isTurn = false;
                Attack();
            }
        }
        else if (isAttacking)
        {

        }
    }

    public void Attack()
    {
        isAttacking = true;
        battleAnnouncementDisplay.text = this.name + " is attacking!";
        StartCoroutine("WaitForAttackAnimation");
    }
    public void TakeTurn()
    {
        isTurn = true;
        battleAnnouncementDisplay.text = this.name + "'s Turn";
    }

    private IEnumerator WaitForAttackAnimation()
    {
        yield return new WaitForSeconds(2.5f);
        isAttacking = false;
        battleController.SendMessage("NextTurn");
    }

    public void LinkBattleAnnouncementDisplay(TextMeshProUGUI bAD)
    {
        battleAnnouncementDisplay = bAD;
    }

    public void LinkBattleController(GameObject bC)
    {
        battleController = bC;
    }
}
