using UnityEngine;

public class ControleCursor : MonoBehaviour
{
    private bool mouseLiberado = false;
    private bool mouseBloqueado = false;

    private void Awake()
    {
        // Já começa bloqueado e invisível instantaneamente ao abrir a cena
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


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


