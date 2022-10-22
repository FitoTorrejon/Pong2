using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RightCounter : MonoBehaviour
{
    //text from the opposite side
    [SerializeField] TMP_Text pointsText;
    int currentPoints = 0;

    private void OnEnable()
    {
        pointsText.text = currentPoints.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        //count the points for the opposite side
        currentPoints++;
        pointsText.text = currentPoints.ToString();
    }
}
