using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ljud : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            Audiomanager.Instance.PlaySFX("Dash");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Audiomanager.Instance.PlaySFX("GLock");
        }
    }

}
