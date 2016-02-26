using UnityEngine;
using System.Collections;

public class StateTransitioner {
    public float transitionTime = 5.0f;
    public enum Direction { forward, backward, stopped }
    public float currentValue;

    public Direction CurrentDirection { get { return currentDirection; } }

    public float updateValue()
    {
        if (currentDirection == Direction.stopped)
        {
            transitionEnd = -1.0f;
            return currentValue;
        }

        normalizedTime = (transitionEnd - Time.time) / transitionTime;

        if (currentDirection == Direction.forward)
        {
            currentValue = Mathf.Lerp(1.0f, 0.0f, normalizedTime);
            if (currentValue > 0.99f)
            {
                currentDirection = Direction.stopped;
            }
        }
        else
        {
            currentValue = Mathf.Lerp(0.0f, 1.0f, normalizedTime);
            if (currentValue < 0.01f)
            {
                currentDirection = Direction.stopped;
            }
        }

        if (currentDirection == Direction.stopped)
        {
            transitionEnd = -1.0f;
        }
        return currentValue;
    }

    public void transitionDirectionTo(Direction newDirection)
    {
        if (currentDirection != newDirection)
        {
            if (transitionEnd < 0.0f)
            {
                transitionEnd = Time.time + transitionTime;
            }
            else
            {
                normalizedTime = 1.0f - (transitionEnd - Time.time) / transitionTime;
                transitionEnd = Time.time + transitionTime * normalizedTime;
            }
            currentDirection = newDirection;
        }
    }

    private Direction currentDirection = Direction.stopped;
    private float normalizedTime;
    private float transitionEnd = -1.0f;
}
