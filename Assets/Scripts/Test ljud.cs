using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testljud : MonoBehaviour
{
    public void testljud()
    {

        if (Input.GetButton("retard"))
        {
            Audiomanager.Instance.PlaySFX("testtest");
        }
    }
}
