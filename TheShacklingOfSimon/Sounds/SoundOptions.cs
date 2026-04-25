#region

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

#endregion

namespace TheShacklingOfSimon.Sounds;

public class SoundOptions
{
    private static SoundOptions _instance = new SoundOptions();
    public static SoundOptions Instance => _instance;

    private float SFXVol;
    private float MusicVol;
    private bool IsMuted = false;

    public SoundOptions()
    {
        SFXVol = 1;
        MusicVol = 1;
    }

    public void ChangeSFXVol()
    {
        SoundManager.Instance.VolumeSFX(SFXVol);
    }

    public void ChangeMusicVol()
    {
        MediaPlayer.Volume = MusicVol;
    }

    private void Mute()
    {
        SoundManager.Instance.VolumeSFX(0);
        MediaPlayer.IsMuted = true;
        IsMuted = true;
    }
    private void Unmute()
    {
        SoundManager.Instance.VolumeSFX(SFXVol);
        MediaPlayer.IsMuted = false;
        IsMuted = false;
    }
    public void ToggleMute()
    {
        if (IsMuted)
            Unmute();
        else
            Mute();
    }
}