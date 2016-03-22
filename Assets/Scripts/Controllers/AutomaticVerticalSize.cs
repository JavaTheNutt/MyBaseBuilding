using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutomaticVerticalSize : MonoBehaviour
{
    [SerializeField]
    private float childHeight = 35f;

    private float childSpacingHeight;

	// Use this for initialization
	void Start ()
	{
        AdjustSize();
    }
	

    public void AdjustSize()
    {
        childSpacingHeight = this.GetComponent<VerticalLayoutGroup>().spacing + childHeight;
        Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
        size.y = this.transform.childCount*childSpacingHeight;
        this.GetComponent<RectTransform>().sizeDelta = size;
    }
}
