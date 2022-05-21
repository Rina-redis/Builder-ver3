using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] popUps;
    [SerializeField] private GameObject player;
    private int currentPopUpIndex = 0;

    private void Update()
    {
        SetActivePopUp(currentPopUpIndex);
        switch (currentPopUpIndex)
        {
            case 0:
                if (player.transform.position.magnitude > 7)
                    currentPopUpIndex++;
                break;
            case 1:
                if (Game.Instance.gameStatistic.AliveBuildings > 0)
                    currentPopUpIndex++;
                break;
            case 2:
                if (Game.Instance.gameStatistic.TimeOfLive > 10)
                    currentPopUpIndex++;
                break;
            case 3:
                if (Game.Instance.gameStatistic.TimeOfLive > 20)
                    currentPopUpIndex++;
                break;
        }
     
    }

    IEnumerator StopAndResumeGame()
    {
        Time.timeScale = 0f;

        yield return new WaitForSeconds(10);

        Time.timeScale = 1f;
    }

    private void SetActivePopUp(int popUpIndex)
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
    }

}
