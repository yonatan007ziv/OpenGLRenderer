﻿using GameEngine.Components.Objects;
using GameEngine.Components.Objects.Scriptable;
using GameEngine.Core.Components;
using System.Numerics;

namespace BoxColliderSample;

internal class WorldCamera : ScriptableWorldComponent
{
	private const float sensitivity = 25;

	public WorldCamera(WorldObject parent)
		: base(parent)
	{
		Meshes.Add(new MeshData("Camera.obj", "Red.mat"));
	}

	public override void Update(float deltaTime)
	{
		if (MouseLocked)
		{
			Vector2 cameraVector = new Vector2(GetAxis("XCamera"), GetAxis("YCamera"));

			// Clamp camera
			float clampedX = Math.Clamp(Transform.Rotation.X + cameraVector.Y * deltaTime * sensitivity, -90, 90);
			Transform.Rotation = new Vector3(clampedX, Transform.Rotation.Y - cameraVector.X * deltaTime * sensitivity, 0);
		}
	}
}