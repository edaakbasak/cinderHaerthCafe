using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // De�i�kenler
    [Header("Camera Target")]
    public Transform target; // Kameran�n takip edece�i obje (Player'�m�z�n Transform'u)

    [Header("Camera Settings")]
    public Vector3 offset; // Kameran�n hedeften ne kadar uzakta duraca�� (X, Y, Z mesafesi)

    // LateUpdate, t�m Update fonksiyonlar� �al��t�ktan sonra, her frame'in sonunda �al���r.
    // Karakter hareket ettikten sonra kameran�n pozisyonunu g�ncellemek i�in en ideal yerdir.
    // Bu, tak�lmalar� ve titremeleri �nler.
    void LateUpdate()
    {
        // E�er bir hedefimiz yoksa (mesela Player �l�rse) hata vermemesi i�in kontrol.
        if (target == null)
        {
            return; // Fonksiyondan ��k, a�a��daki kodu �al��t�rma.
        }

        // Bu kameran�n pozisyonunu, hedefin pozisyonu + belirledi�imiz mesafe olarak ayarla.
        transform.position = target.position + offset;
    }
}