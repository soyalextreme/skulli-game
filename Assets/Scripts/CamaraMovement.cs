using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    private void FixedUpdate() {
        Vector3 charPosition = Camera.main.transform.position;    
        Vector3 camaraPosition = transform.position - new Vector3(0, 0, 20);
        Camera.main.transform.position = Vector3.Lerp(charPosition, camaraPosition, 0.3f); 
    }
}
