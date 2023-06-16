using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();

    }

    private void SwipeCheck()
    {
        // Input.touchCount : parma��m�z�n ekrana dokunmasay�s�n� verir.
        //Parma��m�z�n hareketini kontrol ediyor (dokunmas�n� de�il) Yani sa�a, sola s�r�klediysek.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // parma��m�z� sa�a, sola do�ru kayd�rmam�z� takip ederek x de�erini al�yor ve daha k���k de�erler alabilmek i�in ekran geni�li�ene b�l�yoruz.
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); // Buradaki "Mouse X" tan�m�; Project Setting -> Input Manager -> Mouse X b�l�m�nde tan�mland��� �ekliyle kullan�lmal�d�r.
        }
        else
        {
            // S�r�klemeyi b�rakt���m�zda sola yada sa�a gitmesi engelleniyor.
            touchXDelta = 0;  
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx); // NewX de�eri edit�rde tan�mlad���m�z x de�eri (-limitx, limitx) aral���nda kalacakt�r.


        // Player yeni hesaplanan newX koordinat�nda, verilen h�z ve zamana g�re Z y�n�nde ileriye hareket ediyor.
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
