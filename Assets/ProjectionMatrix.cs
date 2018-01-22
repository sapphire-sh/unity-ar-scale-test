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

	Shader shader;

	new private Camera camera;

	void Awake() {
		camera = GetComponent<Camera>();
	}

	void Update() {
		switch(type) {
		case CameraType.Left:
			camera.projectionMatrix = camera.projectionMatrix;
			break;
		case CameraType.Right:
			Debug.Log(fov);
			var matrix = Matrix4x4.Perspective(fov, 16.0f / 9.0f, 0.3f, 1000.0f);
			camera.projectionMatrix = Matrix4x4.Scale(Vector3.one * 0.5f) * matrix;
			break;
		}
	}
	
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
		Graphics.Blit(source, destination, material);
	}

	float fov = 60.0f;

	const float padding = 50.0f;

	void OnGUI() {
		if(type == CameraType.Right) {
			fov = GUI.VerticalSlider(new Rect(Screen.width - padding, padding, 10.0f, Screen.height - padding * 2.0f), fov, 1.0f, 179.0f);
		}
	}
}
