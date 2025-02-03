using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerNameSpace
{
    public class PlayerMovement
    {
        private PlayerInput playerInput;
        private float speed;

        public PlayerMovement(PlayerInput input, float speed)
        {
            playerInput = input;
            this.speed = speed;

            playerInput.GamePlay.Enable();
        }

        public void Move(Transform transform)
        {
            Vector2 inputDirection = playerInput.GamePlay.Movement.ReadValue<Vector2>();
            Vector3 movement = speed * Time.deltaTime * new Vector3(inputDirection.x, 0, inputDirection.y);
            transform.Translate(movement);
        }
    }
}
