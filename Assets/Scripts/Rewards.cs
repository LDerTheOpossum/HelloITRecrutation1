using UnityEngine;

public class Rewards : MonoBehaviour
{
    private Vector2 mousePos = Vector2.zero;
    [SerializeField] private MoneyHandler moneyHandler;
    [SerializeField] private int value = 25;
    [SerializeField] private AudioSource sellAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sellAudioSource = GetComponent<AudioSource>();
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
        //Debug.Log(mousePos.x + " "+ mousePos.y);
        if (transform.position.x <= -8.89f || transform.position.x >= 8.89f || transform.position.y <= -5 || transform.position.y >= 5)
            transform.position = Vector3.zero;
        Debug.Log("object moved back into games boundries");
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moneyHandler.MoneyIncrease(value);
            AudioSource.PlayClipAtPoint(sellAudioSource.clip, Vector3.zero);
            Destroy(gameObject);

        }
    }
}
