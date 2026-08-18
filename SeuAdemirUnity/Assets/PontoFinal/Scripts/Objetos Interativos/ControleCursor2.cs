using UnityEngine;

public class ControleCursor : MonoBehaviour
{
    private bool mouseLiberado = false;
    private bool mouseBloqueado = false;


    void Update()
    {
        if (mouseLiberado)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (mouseBloqueado)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    public void LiberarMouse()
    {
        mouseLiberado = true;
        mouseBloqueado = false;
    }

    public void BloquearMouse()
    {
        mouseBloqueado = true;
        mouseLiberado = false;
    }
}


