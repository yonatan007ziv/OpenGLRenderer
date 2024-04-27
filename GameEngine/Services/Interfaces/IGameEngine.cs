﻿using GameEngine.Core.API;
using GameEngine.Core.Components;
using GameEngine.Core.Components.Objects;
using System.Drawing;
using System.Numerics;

namespace GameEngine.Services.Interfaces;

// The interface in which you talk with the game engine as a product
public interface IGameEngine
{
	IGraphicsEngine GraphicsEngine { get; }
	ISoundEngine SoundEngine { get; }
	IInputEngine InputEngine { get; }
	IPhysicsEngine PhysicsEngine { get; }

	// Title of the window
	string Title { get; set; }

	// Used for ui interactions, (-1, -1) bottom left and (1, 1) top right
	Vector2 NormalizedMousePosition { get; }

	bool LogRenderingLogs { get; set; }
	bool LogInputs { get; set; }
	bool LogFps { get; set; }
	bool LogTps { get; set; }

	// The wanted tick rate for the update thread
	int TickRate { get; set; }
	// The wanted fps cap for the render thread
	int FpsCap { get; set; }

	float FpsDeltaTimeStopper { get; }
	float ElapsedSeconds { get; }

	bool MouseLocked { get; set; }
	TaskCompletionSource EngineLoadingTask { get; }

	// Starts the engine
	void Run();

	// Sets the custom resource folder slot
	void SetResourceFolder(string path);
	// Changes the window's background color
	void SetWindowBackgroundColor(Color color);

	// Gets a world object from id
	public WorldObject? GetWorldObjectFromId(int id);
	// Gets a ui object from id
	public UIObject? GetUIObjectFromId(int id);

	#region object management
	void AddWorldObject(WorldObject worldObject);
	void RemoveWorldObject(WorldObject worldObject);
	void AddUIObject(UIObject uiObject);
	void RemoveUIObject(UIObject uiObject);
	void AddWorldCamera(WorldObject camera, CameraRenderingMask cameraRenderingMask, ViewPort viewport);
	void RemoveWorldCamera(WorldObject camera);
	void AddUICamera(UIObject camera, CameraRenderingMask cameraRenderingMask, ViewPort viewport);
	void RemoveUICamera(UIObject camera);
	#endregion
}