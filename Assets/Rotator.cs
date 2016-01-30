using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
    public float transitionTime = 1.0f;
    public enum Direction { left, right, none }  
    public Direction testRotateDirection = Direction.none;
    public Vector3 singleRotation = new Vector3();

	// Update is called once per frame
	public void Update () 
    {
        if (testRotateDirection != Direction.none)
        {
            transitionTo(testRotateDirection);
            testRotateDirection = Direction.none;
        }

        if (transitioner.CurrentDirection == StateTransitioner.Direction.stopped)
        {
            currentDirection = Direction.none;
        }

        if (currentDirection == Direction.left)
        {
            this.transform.localEulerAngles = startRotation + transitioner.updateValue() * singleRotation;
        }
        else
        {
            this.transform.localEulerAngles = startRotation - transitioner.updateValue() * singleRotation;
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
            startRotation = this.transform.localEulerAngles;
            return;
        }

        if (currentDirection != direction && transitioner.CurrentDirection == StateTransitioner.Direction.forward)
        {
            transitioner.transitionDirectionTo(StateTransitioner.Direction.backward);
            return;
        }

        if (currentDirection == direction && transitioner.CurrentDirection == StateTransitioner.Direction.backward)
        {
            transitioner.transitionDirectionTo(StateTransitioner.Direction.backward);
            return;
        }
    }

    private StateTransitioner transitioner = new StateTransitioner();
    private Vector3 startRotation = new Vector3();
    private Direction currentDirection = Direction.none;
}
