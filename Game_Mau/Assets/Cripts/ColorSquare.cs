using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSquare : MonoBehaviour
{
    public GameManager Manager;
    public void OnmouseDown()
    {
        Manager.CheckSquare(gameObject);
    }
}
