using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;
    
    public GameObject target;

    float speed = 200f;

    void Update() {
        Swipe();
        Drag();
    }

    void Drag() {
        if (Input.GetMouseButton(1)) {
            if (previousMousePosition == null)
                previousMousePosition = Input.mousePosition;
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else {
            if (transform.rotation != target.transform.rotation) {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }

    void Swipe() {
        if (Input.GetMouseButtonDown(1)) {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1)) {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe)) {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe)) {
                target.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe)) {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe)) {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe)) {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe)) {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }

    bool LeftSwipe(Vector2 swipe) {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe) {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe) {
        return currentSwipe.y > 0 && currentSwipe.x < 0;
    }

    bool UpRightSwipe(Vector2 swipe) {
        return currentSwipe.y > 0 && currentSwipe.x > 0;
    }

    bool DownLeftSwipe(Vector2 swipe) {
        return currentSwipe.y < 0 && currentSwipe.x < 0;
    }

    bool DownRightSwipe(Vector2 swipe) {
        return currentSwipe.y < 0 && currentSwipe.x > 0;
    }
}