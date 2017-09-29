using RGSMS.Math;
using UnityEngine;

public class testeinverseLerp : MonoBehaviour
{
	private void Start ()
	{
		Debug.Log(Mathr.InverseLerp(0.0f, 10.0f, 5.0f, INTERPOLATION.Linear));
        Debug.Log(Mathr.InverseLerp(0.0, 10.0, 5.0f, INTERPOLATION.Linear));

        Debug.Log(Mathr.Lerp(0.0, 10.0, 0.5f, INTERPOLATION.Linear));

        Debug.Log(Mathr.InverseLerp(Vector2.zero, new Vector2(10.0f, 10.0f), new Vector2(5.0f, 5.0f), INTERPOLATION.Linear));
    }
}
