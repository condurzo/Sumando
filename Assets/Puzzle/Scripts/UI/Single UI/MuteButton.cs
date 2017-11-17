using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : SingleButton
{
    public AudioType type = AudioType.SOUNDS;

    protected override void Start()
    {
        Listen(true);
        SoundManager.OnSoundsChange += UpdateGraphics;
        base.Start();
    }

    void OnDestroy()
    {
        Listen(false);
    }

    void Listen(bool listen)
    {
        //SoundManager.OnValueChange d = null;
        switch (type)
        {
            //case AudioType.SOUNDS:
            //    d = SoundManager.OnSoundsChange;
            //    break;
            //case AudioType.MUSIC:
            //    d = SoundManager.OnMusicChange;
            //    break;
            case AudioType.SOUNDS:
                if (listen) SoundManager.OnSoundsChange += UpdateGraphics;
                else SoundManager.OnSoundsChange -= UpdateGraphics;
                break;
            case AudioType.MUSIC:
                if (listen) SoundManager.OnMusicChange += UpdateGraphics;
                else SoundManager.OnMusicChange -= UpdateGraphics;
                break;
        }

        //if (listen)
        //{
        //    d += UpdateGraphics;
        //}
        //else
        //{
        //    d -= UpdateGraphics;
        //}
    }

    protected override void Click()
    {
        SoundManager.Instance.MuteAudio(type);
    }

    protected override bool GetValue()
    {
        switch(type)
        {
            case AudioType.SOUNDS:
                return SoundManager.Instance.SfxOn;
            case AudioType.MUSIC:
                return SoundManager.Instance.MusicOn;
            default:
                return true;
        }
    }
}
