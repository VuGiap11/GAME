using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    public Color[] colorPalette;
    public Color curColor;
    public Color curOddColor;

    public GameObject[] colorSquares;
    public int oddColorSquares;

    public float difficultModifer; // gia trị để tạo độ khó
    public int round;

    void Start()
    {
        NextRound();
    }
    void NextRound()
    {
        difficultModifer /= 1.05f;
        round++;
        curColor = colorPalette[Random.Range(0, colorPalette.Length - 1)];
        float diff = (1.1f / 255f) * difficultModifer;
        curOddColor = new Color(curColor.r - diff, curColor.g-  diff, curColor.b- diff, curColor.a - diff);
        oddColorSquares = Random.Range(0, colorSquares.Length-1);
        for (int i = 0; i < colorSquares.Length; i++)
        {
            if (i == oddColorSquares)  
            {
                colorSquares[i].GetComponent<Image>().color = curOddColor;
            }else
            {
                colorSquares[i].GetComponent<Image>().color = curColor;
            }


        }

    }
    public void CheckSquare(GameObject obj)
    {
        if (colorSquares[oddColorSquares] == obj)
        {
            NextRound();
        }
        else
        {
            Debug.Log("End Game");
        }
    }

}
