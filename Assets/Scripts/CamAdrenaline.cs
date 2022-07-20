using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamAdrenaline : MonoBehaviour
{
    [SerializeField] GameObject leftBomb, rightBomb, leftWall, RightWall;
    [SerializeField] CinemachineVirtualCamera zeroCamera, leftCamera, rightCamera;
    CinemachineTransposer transposer;

    private void Start()
    {
        transposer = leftCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer = rightCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        if(leftWall.transform.position.y - leftBomb.transform.position.y < 3)
        {
            leftCamera.gameObject.SetActive(true);
        }
        else if (leftWall.transform.position.y - leftBomb.transform.position.y > 3)
        {
            leftCamera.gameObject.SetActive(false);
        }

        if (RightWall.transform.position.y - rightBomb.transform.position.y < 3)
        {
            rightCamera.gameObject.SetActive(true);
        }
        else if (RightWall.transform.position.y - rightBomb.transform.position.y > 3)
        {
            rightCamera.gameObject.SetActive(false);
        }
    }
}
