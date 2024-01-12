using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIkontroll : MonoBehaviour
{
    public Slider _musicslider, _sfxslider;

    public void Togglemusic()
    {
        Audiomanager.Instance.Togglemusic();
    }
    public void Togglesfx()
    {
        Audiomanager.Instance.Togglesfx();
    }
    public void Musicvolume()
    {
        Audiomanager.Instance.Musicvolume(_musicslider.value);
    }
    public void SFXvolume()
    {
        Audiomanager.Instance.SFXvolume(_sfxslider.value);
    }
}
