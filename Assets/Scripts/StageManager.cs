using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{


    public GameObject[] _Stage;


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (_Stage[0] == true)
        {
            _Stage[0].SetActive(false);
        }
        if (_Stage[1] == true)
        {
            _Stage[1].SetActive(false);
        }
    }

    void StageLoader(int ID)
    {

        _Stage[ID].SetActive(true);

    }



}
