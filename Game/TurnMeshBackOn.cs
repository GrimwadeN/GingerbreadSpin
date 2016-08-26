using UnityEngine;
using System.Collections;

public class TurnMeshBackOn : MonoBehaviour {

    public void MeshSwitch(bool swap)
    {
        if(swap == false)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else if(swap == true)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
