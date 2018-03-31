using UnityEngine;

public class VectorRotation
{
	public static Vector2 RotateVector(Vector2 vector,float angle)
	{
		Vector2 rotatedVector = vector;
		float _x = rotatedVector.x;
		float _y = rotatedVector.y;
		float angleInRadian = (angle / 360) * (2 * Mathf.PI);
		float _cos = Mathf.Cos(angleInRadian);
		float _sin = Mathf.Sin(angleInRadian);
		rotatedVector.x = _x * _cos - _y * _sin;
		rotatedVector.y = _x * _sin + _y * _cos;
		return rotatedVector;
	}
}
