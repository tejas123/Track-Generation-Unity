using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private List<GameObject> allocatedTrackList;

    void Awake()
    {
        instance = this;
        allocatedTrackList = new List<GameObject>();
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public List<GameObject> AllocatedTrackList
    {
        get
        {
            return allocatedTrackList;
        }
    }
}


