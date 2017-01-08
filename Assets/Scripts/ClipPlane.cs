using UnityEngine;
using System.Collections;
using System.Linq;

[ExecuteInEditMode]
public class ClipPlane : MonoBehaviour {

	public void Start() { }

	//preview size for the planes. Shown when the object is selected.
	public float planePreviewSize = 5.0f;

	//Positions and rotations for the planes. The rotations will be converted into normals to be used by the shaders.
	Vector3 plane1Position = Vector3.zero;
	Vector3 plane1Rotation = new Vector3(0, 0, 0);

	//Only used for previewing a plane. Draws diagonals and edges of a limited flat plane.
	private void DrawPlane(Vector3 position, Vector3 euler) {
		var forward = Quaternion.Euler(euler) * Vector3.forward;
		var left = Quaternion.Euler(euler) * Vector3.left;

		var forwardLeft = position + forward * planePreviewSize * 0.5f + left * planePreviewSize * 0.5f;
		var forwardRight = forwardLeft - left * planePreviewSize;
		var backRight = forwardRight - forward * planePreviewSize;
		var backLeft = forwardLeft - forward * planePreviewSize;

		Gizmos.DrawLine(position, forwardLeft);
		Gizmos.DrawLine(position, forwardRight);
		Gizmos.DrawLine(position, backRight);
		Gizmos.DrawLine(position, backLeft);

		Gizmos.DrawLine(forwardLeft, forwardRight);
		Gizmos.DrawLine(forwardRight, backRight);
		Gizmos.DrawLine(backRight, backLeft);
		Gizmos.DrawLine(backLeft, forwardLeft);
	}

	private void OnDrawGizmosSelected() {
		DrawPlane(plane1Position, plane1Rotation);
	}

	//Ideally the planes do not need to be updated every frame, but we'll just keep the logic here for simplicity purposes.
	public void Update()
	{
		var sharedMaterial = GetComponent<MeshRenderer>().sharedMaterial;
		sharedMaterial.SetVector("_planePos", plane1Position);
		//plane normal vector is the rotated 'up' vector.
		sharedMaterial.SetVector("_planeNorm", Quaternion.Euler(plane1Rotation) * Vector3.up);
	}
}