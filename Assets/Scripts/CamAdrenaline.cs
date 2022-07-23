using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamAdrenaline : MonoBehaviour
{
    [SerializeField] GameObject leftBomb, rightBomb, leftWall, RightWall;
    [SerializeField] CinemachineVirtualCamera zeroCamera, leftCamera, rightCamera;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Player player;

    void Update()
    {
        if (leftWall.transform.position.y - leftBomb.transform.position.y <= 3)
        {
            leftCamera.gameObject.SetActive(true);
            if (!audioSource.isPlaying && !player.loseBool && !player.winBool)
            {
                audioSource.Play();
            }
        }
        else if (leftWall.transform.position.y - leftBomb.transform.position.y > 3)
        {
            leftCamera.gameObject.SetActive(false);
        }
        if (RightWall.transform.position.y - rightBomb.transform.position.y <= 3)
        {
            rightCamera.gameObject.SetActive(true);
            if (!audioSource.isPlaying && !player.loseBool && !player.winBool)
            {
                audioSource.Play();
            }
        }
        else if (RightWall.transform.position.y - rightBomb.transform.position.y > 3)
        {
            rightCamera.gameObject.SetActive(false);
        }
    }
}
