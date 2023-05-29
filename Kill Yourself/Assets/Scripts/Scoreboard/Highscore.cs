using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Highscore
{
    public string name;
    public int milliseconds;

    public Highscore(string name, int milliseconds)
    {
        this.name = name;
        this.milliseconds = milliseconds;
    }

    public Highscore(string name, TimeSpan time)
    {
        this.name = name;
        this.milliseconds = (int)time.TotalMilliseconds;
    }

    public string GetTimeString()
    {
        return new TimeSpan(0, 0, 0, 0, milliseconds).ToString("mm\\:ss\\.FFF");
    }
}

[Serializable]
public class Highscores
{
    public List<Highscore> list;
}