using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    Vector2 minBounds, maxBounds;
    void Start()
    {
        Cursor.visible=false;
        minBounds = new Vector2(-6.34f, -1.46f);
        maxBounds = new Vector2(7.7f, 4.34f);
    }


    void Update()
    {

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, minBounds.x, maxBounds.x);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, minBounds.y, maxBounds.y);

        transform.position = cursorPosition;
    }
}
