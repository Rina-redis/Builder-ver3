using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
     public void SetVolume (float volume)
    {
        PlayerPrefs.SetString("Volume", volume.ToString());

    }
}
