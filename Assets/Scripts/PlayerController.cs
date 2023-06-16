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
        // Input.touchCount : parmaðýmýzýn ekrana dokunmasayýsýný verir.
        //Parmaðýmýzýn hareketini kontrol ediyor (dokunmasýný deðil) Yani saða, sola sürüklediysek.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // parmaðýmýzý saða, sola doðru kaydýrmamýzý takip ederek x deðerini alýyor ve daha küçük deðerler alabilmek için ekran geniþliðene bölüyoruz.
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); // Buradaki "Mouse X" tanýmý; Project Setting -> Input Manager -> Mouse X bölümünde tanýmlandýðý þekliyle kullanýlmalýdýr.
        }
        else
        {
            // Sürüklemeyi býraktýðýmýzda sola yada saða gitmesi engelleniyor.
            touchXDelta = 0;  
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx); // NewX deðeri editörde tanýmladýðýmýz x deðeri (-limitx, limitx) aralýðýnda kalacaktýr.


        // Player yeni hesaplanan newX koordinatýnda, verilen hýz ve zamana göre Z yönünde ileriye hareket ediyor.
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
