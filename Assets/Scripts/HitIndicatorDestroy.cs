using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitIndicatorDestroy : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("ProbablyDestroyVerySoon");
    }

    IEnumerator ProbablyDestroyVerySoon()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
