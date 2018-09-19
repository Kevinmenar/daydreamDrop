using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Throwable _grabbedThrowable; // The object we're grabbing
    private Rigidbody _rigidbody;
	private bool _isFloating;

	void Start ()
	{
	    _grabbedThrowable = null;
	    _rigidbody = GetComponent<Rigidbody>();
		_isFloating = false;
	}

    // Called by the Event System when we click on an object, receives a game object to hold.
    // The object given must have a throwable object, otherwise we don't do anything
    public void HoldGameObject(GameObject throwableObject)
    {
        Throwable throwable = throwableObject.GetComponent<Throwable>();
        if (throwable != null)
        {
			_isFloating = true;
            _grabbedThrowable = throwable;
            _grabbedThrowable.GetGrabbed(gameObject);
        }
    }

    // Called by the Event System when we release our click on a game object.
    // Release our held object and throw it based off our controller motino
    public void ReleaseGameObject()
    {
        // Only throw an object if we're holding onto something
        if (_grabbedThrowable != null)
        {
			_isFloating = false;
            _grabbedThrowable.GetReleased();
            _grabbedThrowable = null;
        }
    }

	public void holdReleaseController(GameObject throwableObject) {
		if (!_isFloating) {
			HoldGameObject(throwableObject);
		} else {
			ReleaseGameObject ();
		}
	}
}
