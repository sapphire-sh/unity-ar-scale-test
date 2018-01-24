using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public KeyCode forward = KeyCode.W;
	public KeyCode backward = KeyCode.S;
	public KeyCode leftward = KeyCode.A;
	public KeyCode rightward = KeyCode.D;
	public KeyCode upward = KeyCode.E;
	public KeyCode downward = KeyCode.Q;

	public KeyCode pitchUpward = KeyCode.DownArrow;
	public KeyCode pitchDownward = KeyCode.UpArrow;
	public KeyCode yawLeftward = KeyCode.RightArrow;
	public KeyCode yawRightward = KeyCode.LeftArrow;

	public float velocity = 10.0f;

	private void UpdatePosition(float x) {
		x *= 0.2f * transform.parent.localScale.x;

		float _forward = 0.0f;
		float _leftward = 0.0f;
		float _upward = 0.0f;

		bool isUpdated = false;
		if(Input.GetKey(forward)) {
			_forward += x;
			isUpdated = true;
		}
		if(Input.GetKey(backward)) {
			_forward -= x;
			isUpdated = true;
		}
		if(Input.GetKey(leftward)) {
			_leftward += x;
			isUpdated = true;
		}
		if(Input.GetKey(rightward)) {
			_leftward -= x;
			isUpdated = true;
		}
		if(Input.GetKey(upward)) {
			_upward += x;
			isUpdated = true;
		}
		if(Input.GetKey(downward)) {
			_upward -= x;
			isUpdated = true;
		}

		if(isUpdated) {
			var p = new Vector3(-_leftward, _upward, _forward);
			transform.position += transform.rotation * p;
		}
	}

	private void UpdateRotation(float x) {
		x *= 2.0f;

		var _e = transform.localRotation.eulerAngles;
		float _pitch = _e.x;
		float _yaw = _e.y;
		float _roll = _e.z;

		bool isUpdated = false;
		if(Input.GetKey(pitchUpward)) {
			_pitch += x;
			isUpdated = true;
		}
		if(Input.GetKey(pitchDownward)) {
			_pitch -= x;
			isUpdated = true;
		}
		if(Input.GetKey(yawLeftward)) {
			_yaw += x;
			isUpdated = true;
		}
		if(Input.GetKey(yawRightward)) {
			_yaw -= x;
			isUpdated = true;
		}

		if(isUpdated) {
			var e = new Vector3(_pitch, _yaw, _roll);
			var q = Quaternion.Euler(e);
			transform.localRotation = q;
		}
	}

	void Update() {
		var t = Time.deltaTime;
		var x = t * velocity;

		UpdatePosition(x);
		UpdateRotation(x);
	}
}
