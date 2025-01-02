using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickController : MonoBehaviour
{
    public InputAction joystickAction;

    private void OnEnable()
    {
        joystickAction.Enable();
    }

    private void OnDisable()
    {
        joystickAction.Disable();
    }

    private void Update()
    {
        // 获取Joystick的原始输入数据
        Vector2 joystickRawInput = joystickAction.ReadValue<Vector2>();

        // 计算处理后的Joystick输入数据
        Vector2 joystickInput = CalculateJoystickMovement(joystickRawInput);

        // 打印处理后的输入到Debug Log
        Debug.Log("Joystick Processed Input: " + joystickInput);
    }

    Vector2 CalculateJoystickMovement(Vector2 rawInput)
    {
        // 在这里可以添加任何你需要的处理逻辑
        // 例如，你可以将输入向量归一化，修改灵敏度，等等。
        return rawInput;
    }
}
