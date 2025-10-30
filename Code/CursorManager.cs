using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D CursorNormal;
    [SerializeField] private Texture2D CursorShoot;
    [SerializeField] private Texture2D CursorReLoad;
    private Vector2 hotspot = new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(CursorNormal, hotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(CursorShoot, hotspot, CursorMode.Auto);    

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(CursorNormal, hotspot, CursorMode.Auto);
        }
        if (Input.GetMouseButton(1))
        {
            Cursor.SetCursor(CursorReLoad, hotspot, CursorMode.Auto);
            
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(CursorNormal, hotspot, CursorMode.Auto);
        }
    }
}
