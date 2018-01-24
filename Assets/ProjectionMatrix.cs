using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ProjectionMatrix : MonoBehaviour {
	private enum CameraType {
		Left = 1,
		Right,
	}

	[SerializeField]
	CameraType type;

	[SerializeField]
	Material material;

	[SerializeField]
	GameObject focus;

	Shader shader;

	void Start() {
		switch(type) {
		case CameraType.Left:
			break;
		case CameraType.Right:
			var parent = transform.parent;
			var focusPos = focus.transform.position;
			var invPos = parent.InverseTransformPoint(focusPos);
			var invRot = Quaternion.Inverse(parent.rotation);

			parent.localScale = Vector3.one * 2.0f;
			parent.localPosition = -(invRot * invPos * 2.0f) + focusPos;
			parent.localRotation = invRot;

			break;
		}
	}
	
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
		Graphics.Blit(source, destination, material);
	}
}
