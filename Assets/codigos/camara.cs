using UnityEngine;

public class camara : MonoBehaviour
{

    public Transform target; // El jugador
    public int smoothSpeed = 10;

    // Límites de la cámara
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Posición deseada basada en el jugador
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Suavizado del movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicar límites
        float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
    }
}
