﻿using System.Collections;
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
		x *= 0.1f;

		float _forward = 0.0f;
		float _leftward = 0.0f;
		float _upward = 0.0f;

		if(Input.GetKey(forward)) {
			_forward += x;
		}
		if(Input.GetKey(backward)) {
			_forward -= x;
		}
		if(Input.GetKey(leftward)) {
			_leftward += x;
		}
		if(Input.GetKey(rightward)) {
			_leftward -= x;
		}
		if(Input.GetKey(upward)) {
			_upward += x;
		}
		if(Input.GetKey(downward)) {
			_upward -= x;
		}

		var p = new Vector3(-_leftward, _upward, _forward);

		transform.position += transform.rotation * p;
	}

	private void UpdateRotation(float x) {
		x *= 2.0f;

		var _e = transform.rotation.eulerAngles;
		float _pitch = _e.x;
		float _yaw = _e.y;
		float _roll = _e.z;

		if(Input.GetKey(pitchUpward)) {
			_pitch += x;
		}
		if(Input.GetKey(pitchDownward)) {
			_pitch -= x;
		}
		if(Input.GetKey(yawLeftward)) {
			_yaw += x;
		}
		if(Input.GetKey(yawRightward)) {
			_yaw -= x;
		}

		var e = new Vector3(_pitch, _yaw, _roll);
		var q = Quaternion.Euler(e);

		transform.localRotation = q;
	}

	void Update() {
		var t = Time.deltaTime;
		var x = t * velocity;

		UpdatePosition(x);
		UpdateRotation(x);
	}
}
