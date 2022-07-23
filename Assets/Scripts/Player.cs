using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RTLTMPro;

public class Player : MonoBehaviour
{
    [SerializeField] int howmanyrocks = 3;
    [SerializeField] float gameOverTimer = 10f;
    [SerializeField] float pathSpeed = 1f;
    [SerializeField] float autoTimer = 3f;
    [SerializeField] bool auto = false;

    [SerializeField] GameObject[] rocks;
    [SerializeField] Transform railObject1, railObject2;
    [SerializeField] RTLTextMeshPro nextRockTextPrefab;
    [SerializeField] Image nextRockParent;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] RTLTextMeshPro timerText;
    [SerializeField] GameObject deathCam;
    [SerializeField] GameObject winCam;
    [SerializeField] Rigidbody bowl;

    List<int> rockList = new List<int>();
    List<RTLTextMeshPro> RockTexts = new List<RTLTextMeshPro>();
    MusicPlayer music;
    Transform goal;
    int whichRockNow = 0;
    GameObject rockNow;
    public bool loseBool = false;
    public bool winBool = false;

    private void Start()
    {
        music = GameObject.FindObjectOfType<MusicPlayer>();
        int integer = Random.Range(0, 2);
        if(integer == 0)
        {
            goal = railObject1;
        }
        else
        {
            goal = railObject2;
        }
        if (!auto)
        {
            MakeRockList();
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal.position, pathSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && !auto && !loseBool && whichRockNow < howmanyrocks)
        {
            rockNow = rocks[rockList[whichRockNow]];

            RTLTextMeshPro nowRockText = RockTexts[whichRockNow];
            //RockTexts.Remove(nowRockText);

            Destroy(nowRockText);
            Instantiate(rockNow, transform.position - new Vector3(0, 1.55f, 0), Quaternion.identity, null);
            whichRockNow++;
        }
        if (auto && autoTimer <= 0)
        {
            rockNow = rocks[0];
            Instantiate(rockNow, transform.position - new Vector3(0, 1.55f, 0), Quaternion.identity, null);
            autoTimer = 4;
        }
        if (whichRockNow == howmanyrocks && !loseBool && !winBool)
        {
            winBool = true;
            StartCoroutine(WinProcess());
        }
        else
        {
            if (!auto && gameOverTimer > 0 && !loseBool && !winBool)
            {
                gameOverTimer -= Time.deltaTime;
                timerText.text = ((int)gameOverTimer).ToString();
                if(gameOverTimer <= 3)
                {
                    timerText.color = Color.red;
                }
            }
        }
        if (gameOverTimer <= 0 && !loseBool && !winBool)
        {
            LoseProcess();
        }
        if (auto)
        {
            autoTimer -= Time.deltaTime;
        }
    }

    public void LoseProcess()
    {
        loseBool = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        if (deathCam != null)
        {
            deathCam.SetActive(true);
        }
        if (music != null)
        {
            music.PlayLose();
        }
    }

    private IEnumerator WinProcess()
    {
        yield return new WaitForSeconds(5f);
        if (!loseBool)
        {
            winPanel.SetActive(true);
            if(bowl != null)
            {
                bowl.mass = 1000;
            }
            if (winCam != null)
            {
                winCam.SetActive(true);
            }
            if (music != null)
            {
                music.PlayWin();
            }
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

            RTLTextMeshPro nextRockTextInstant = Instantiate(nextRockTextPrefab, nextRockParent.transform);
            RockTexts.Add(nextRockTextInstant);
            if (whatRock == 0)
            {
                nextRockTextInstant.text = "متوسط";
            }
            else if (whatRock == 1)
            {
                nextRockTextInstant.text = "بزرگ";
            }
            else if (whatRock == 2)
            {
                nextRockTextInstant.text = "کوچک";
            }
            else if (whatRock == 3)
            {
                nextRockTextInstant.text = "نابودگر";
            }
            else if (whatRock == 4)
            {
                nextRockTextInstant.text = "متوسط";
            }
            else if (whatRock == 5)
            {
                nextRockTextInstant.text = "بزرگ";
            }
            else if (whatRock == 6)
            {
                nextRockTextInstant.text = "کوچک";
            }
        }
    }
}
