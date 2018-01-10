using UnityEngine;
using System.Collections;

public class InputUtil {

	public const string horizontal = "Horizontal";
	public const string vertical = "Vertical";

	#if UNITY_ANDROID && !UNITY_EDITOR

	public const string buttonA = "Button_A";
	public const string buttonB = "Button_B";
	public const string buttonX = "Button_X";
	public const string buttonY = "Button_Y";
	public const string menu = "Button_menu";
	public const string back = "Button_back";
	public const string triggerLeft = "Button_trigger_left";
	public const string triggerRight = "Button_trigger_right";

	#else

	public const string buttonA = "Button_A";
	public const string buttonB = "Button_B";
	public const string buttonX = "Button_X";
	public const string buttonY = "Button_Y";
	public const string menu = "Button_menu";
	public const string back = "Button_back";
	public const string triggerLeft = "Button_trigger_left";
	public const string triggerRight = "Button_trigger_right";
	public const string altLeft = "Keyboard_alt_left";
	public const string shiftLeft = "Keyboard_shift_left";
	

	#endif
}
