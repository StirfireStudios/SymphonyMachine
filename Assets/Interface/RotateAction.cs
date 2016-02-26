using UnityEngine;
using System.Collections;

public class RotateAction : MonoBehaviour
{
    public float transitionTime = 1.0f;
    public enum Direction { left, right, none }
    public Direction testRotateDirection = Direction.none;
    public Vector3 singleRotation = new Vector3();
    public Transform objectToRotate = null;

    // Update is called once per frame
    public void Update()
    {
        transitioner.transitionTime = transitionTime;
     
        if (testRotateDirection != Direction.none)
        {
            transitionTo(testRotateDirection);
            testRotateDirection = Direction.none;
        }


        if (transitioner.CurrentDirection == StateTransitioner.Direction.stopped)
        {
            currentDirection = Direction.none;
            return;
        }

        Vector3 newRotation = new Vector3();

        if (currentDirection == Direction.left)
        {
            newRotation = startRotation + transitioner.updateValue() * singleRotation;
        }
        else
        {
            newRotation = startRotation - transitioner.updateValue() * singleRotation;
        }

        if (objectToRotate != null)
        {
            objectToRotate.localEulerAngles = newRotation;
        }
        else
        {
            this.transform.localEulerAngles = newRotation;
        }

    }

    public void OnTriggerRotateLeft()
    {
        transitionTo(Direction.left);
    }

    public void OnTriggerRotateRight()
    {
        transitionTo(Direction.right);
    }

    private void transitionTo(Direction direction)
    {
        if (currentDirection == Direction.none)
        {
            currentDirection = direction;
            transitioner.currentValue = 0.0f;
            transitioner.transitionDirectionTo(StateTransitioner.Direction.forward);
            if (objectToRotate == null)
            {
                startRotation = this.transform.localEulerAngles;
            }
            else
            {
                startRotation = objectToRotate.transform.localEulerAngles;
            }
            return;
        }

        if (currentDirection != direction && transitioner.CurrentDirection == StateTransitioner.Direction.forward)
        {
            Debug.Log("Reversal!");
            transitioner.transitionDirectionTo(StateTransitioner.Direction.backward);
            return;
        }

        if (currentDirection == direction && transitioner.CurrentDirection == StateTransitioner.Direction.backward)
        {
            Debug.Log("Resume!");
            transitioner.transitionDirectionTo(StateTransitioner.Direction.backward);
            return;
        }
    }

    private StateTransitioner transitioner = new StateTransitioner();
    private Vector3 startRotation = new Vector3();
    private Direction currentDirection = Direction.none;
}
