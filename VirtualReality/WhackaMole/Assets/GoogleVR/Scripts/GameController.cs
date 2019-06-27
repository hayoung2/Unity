using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour { 

    public GameObject moleContainer;

    private Mole[] moles;

    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();

        moles[Random.Range(0, moles.Length)].Rise();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

