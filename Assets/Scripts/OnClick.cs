using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();
    }

    public void changeToLF()
    {
        Attractor.LazyFlight = true;
        Attractor.CircleATree = false;
        Attractor.FollowTheLeader = false;
    }

    public void changeToCaT()
    {
        Attractor.LazyFlight = false;
        Attractor.CircleATree = true;
        Attractor.FollowTheLeader = false;
    }

    public void changeToFtL()
    {
        Attractor.LazyFlight = false;
        Attractor.CircleATree = false;
        Attractor.FollowTheLeader = true;
    }
}
