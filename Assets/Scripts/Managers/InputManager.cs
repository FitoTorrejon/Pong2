using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TMP_Text leftUpKey, leftDownKey, rightUpKey, rightDownKey;

    private bool changingLeftUp, changingLeftDown, changingRightUp, changingRightDown;


    private void Start()
    {
        keys.Add("LeftUp", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftUp", "W")));
        keys.Add("LeftDown", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftDown", "S")));
        keys.Add("RightUp", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightUp", "UpArrow")));
        keys.Add("RightDown", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightDown", "DownArrow")));

        leftUpKey.text = keys["LeftUp"].ToString();
        leftDownKey.text = keys["LeftDown"].ToString();
        rightUpKey.text = keys["RightUp"].ToString();
        rightDownKey.text = keys["RightDown"].ToString();
    }


    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if (changingLeftUp)
            {
                keys["LeftUp"] = e.keyCode;
                leftUpKey.text = e.keyCode.ToString();
                changingLeftUp = false;
            }
            else if (changingLeftDown)
            {
                keys["LeftDown"] = e.keyCode;
                leftDownKey.text = e.keyCode.ToString();
                changingLeftDown = false;
            }
            else if (changingRightUp)
            {
                keys["RightUp"] = e.keyCode;
                rightUpKey.text = e.keyCode.ToString();
                changingRightUp = false;
            }
            else if (changingRightDown)
            {
                keys["RightDown"] = e.keyCode;
                rightDownKey.text = e.keyCode.ToString();
                changingRightDown = false;
            }
        }
    }

    public void ChangeLeftDown()
    {
        changingLeftDown = true;
    }
    public void ChangeLeftUp()
    {
        changingLeftUp = true;
    }
    public void ChangeRightDown()
    {
        changingRightDown = true;
    }
    public void ChangeRightUp()
    {
        changingRightUp = true;
    }

    public void CancelChangeKey()
    {
        changingLeftDown = false;
        changingLeftUp = false;
        changingRightDown = false;
        changingRightUp = false;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

}
