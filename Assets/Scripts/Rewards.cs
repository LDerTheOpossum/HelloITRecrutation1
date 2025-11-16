using UnityEngine;

public class Rewards : MonoBehaviour
{
    private Vector2 mousePos = Vector2.zero;
    [SerializeField] private MoneyHandler moneyHandler;
    [SerializeField] private int value = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (moneyHandler == null)
        {
            GameObject moneyObject = GameObject.Find("Money Display");
            if (moneyObject != null)
                moneyHandler = moneyObject.GetComponent<MoneyHandler>();
            else Debug.Log("Money Display object not found on the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        if (Input.GetMouseButtonDown(1))
        {
            moneyHandler.MoneyIncrease(value);
            Destroy(gameObject);

        }
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos;
    }
}
