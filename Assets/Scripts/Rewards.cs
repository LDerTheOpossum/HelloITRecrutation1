using UnityEngine;

public class Rewards : MonoBehaviour
{
    private Vector2 mousePos = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos;
    }
}
