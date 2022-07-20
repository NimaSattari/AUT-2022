using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] rocks;
    [SerializeField] Transform railObject1, railObject2;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform goal;
    [SerializeField] int howmanyrocks = 3;
    [SerializeField] List<int> rockList = new List<int>();
    [SerializeField] int whichRockNow = 0;
    [SerializeField] GameObject rockNow;
    [SerializeField] TextMeshProUGUI nextRockText;
    [SerializeField] List<TextMeshProUGUI> RockTexts = new List<TextMeshProUGUI>();
    [SerializeField] Image nextRockParent;
    private void Start()
    {
        int integer = Random.Range(0, 2);
        if(integer == 0)
        {
            goal = railObject1;
        }
        else
        {
            goal = railObject2;
        }
        MakeRockList();
    }
    int timer = 0;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && timer == 0)
        {
            timer = 1;
            if(rockList[whichRockNow] == 0)
            {
                rockNow = rocks[0];
            }
            if (rockList[whichRockNow] == 1)
            {
                rockNow = rocks[1];
            }
            if (rockList[whichRockNow] == 2)
            {
                rockNow = rocks[2];
            }
            if (rockList[whichRockNow] == 3)
            {
                rockNow = rocks[3];
            }
            TextMeshProUGUI nowRockText = RockTexts[whichRockNow];
            //RockTexts.Remove(nowRockText);
            Destroy(nowRockText);
            Instantiate(rockNow, transform.position - new Vector3(0, 1.55f, 0), Quaternion.identity, null);
            whichRockNow++;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "B1")
        {
            goal = railObject2;
        }
        if (other.tag == "B2")
        {
            goal = railObject1;
        }
    }

    private void MakeRockList()
    {
        for(int i = 0; i < howmanyrocks; i++)
        {
            int whatRock = Random.Range(0, 4);
            rockList.Add(whatRock);

            TextMeshProUGUI nextRockTextInstant = Instantiate(nextRockText, nextRockParent.transform);
            RockTexts.Add(nextRockTextInstant);
            if (whatRock == 0)
            {
                nextRockTextInstant.text = "Medium";
            }
            else if (whatRock == 1)
            {
                nextRockTextInstant.text = "Big";
            }
            else if (whatRock == 2)
            {
                nextRockTextInstant.text = "Small";
            }
            else if (whatRock == 3)
            {
                nextRockTextInstant.text = "Destroyer";
            }
        }
    }
}
