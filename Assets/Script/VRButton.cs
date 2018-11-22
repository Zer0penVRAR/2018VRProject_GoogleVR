using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour {

    #region Variables

    

    #endregion

    #region Other Methods

    public void ButtonClicked()
    {
        Destroy(this.gameObject);
    }

    #endregion
}