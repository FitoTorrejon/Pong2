using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private GameObject currentKey;

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TMP_Text leftUpKey, leftDownKey, rightUpKey, rightDownKey;


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

    private void Update()
    {
        if (currentKey != null)
            Debug.Log(currentKey.name);
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            keys[currentKey.name] = e.keyCode;
            currentKey.GetComponentInChildren<TMP_Text>().text = e.keyCode.ToString();
            currentKey = null;
        }
    }
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
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
