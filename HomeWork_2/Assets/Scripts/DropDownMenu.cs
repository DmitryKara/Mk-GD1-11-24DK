using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    public Text menu;
    
    public void InputMenu(int index)
    {        
        switch(index)
        {
            case 0:
                menu.text = "Option A";
                break;
            case 1:
                menu.text = "Option B";
                break;
            case 2:
                menu.text = "Option C";
                break;
            case 3:
                menu.text = "Option D";
                break;
        }
    }
}
