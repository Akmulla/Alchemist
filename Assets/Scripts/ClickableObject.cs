using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (eventData.button == PointerEventData.InputButton.Left)
        //    Debug.Log("Left click");
        //else if (eventData.button == PointerEventData.InputButton.Middle)
        //    Debug.Log("Middle click");
        if ((eventData.button == PointerEventData.InputButton.Right)&&(Player.player.CheckIfDefault()))
            UIController.ui.DrinkBottle(GetComponent<Bottle>().bottle);
            //Debug.Log("Right click");
    }
}
