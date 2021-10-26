//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class AuthMananger : MonoBehaviour
//{
//	protected Firebase.Auth.FirebaseAuth auth;
//	protected Firebase.Auth.FirebaseUser user;
//	private string displayName;

//	public InputField inputFieldEmail;
//	public InputField inputFieldPassword;

//	private bool loginIndication = false;

//	//public InputField InputFieldEmail { get => inputFieldEmail; set => inputFieldEmail = value; }
//	//public InputField InputFieldEmail1 { get => inputFieldEmail; set => inputFieldEmail = value; }

//	// Start is called before the first frame update
//	void Start()
//    {
//		InitializeFirebase();

//	}

//    // Update is called once per frame
//    void Update()
//    {
//        if (loginIndication)
//		{
//			ActivedSession();
//			GetSessionPorfile();
//			GetActiveSession();
//			SceneManager.LoadScene(5); 
//		}
//    }


//	void InitializeFirebase()
//	{
//		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//		auth.StateChanged += AuthStateChanged;
//		AuthStateChanged(this, null);
//	}

//	void AuthStateChanged(object sender, System.EventArgs eventArgs)
//	{
//		if (auth.CurrentUser != user)
//		{
//			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
//			if (!signedIn && user != null)
//			{
//				Debug.Log("Signed out " + user.UserId);
//			}
//			user = auth.CurrentUser;
//			if (signedIn)
//			{
//				Debug.Log("Signed in " + user.UserId);
//				displayName = user.DisplayName ?? "";
//				//emailAddress = user.Email ?? "";
//				//photoUrl = user.PhotoUrl ?? "";
//			}
//		}
//	}

//	public void createUserByEmail()
//	{
//		string email = inputFieldEmail.text;
//		string password = inputFieldPassword.text;

//		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
//			if (task.IsCanceled)
//			{
//				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
//				return;
//			}
//			if (task.IsFaulted)
//			{
//				Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
//				return;
//			}

//			// Firebase user has been created.
//			Firebase.Auth.FirebaseUser newUser = task.Result;
//			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
//				newUser.DisplayName, newUser.UserId);
//		});
//	}



//	public void ActivedSession()
//	{
//		Firebase.Auth.FirebaseAuth auth;
//		Firebase.Auth.FirebaseUser user;

//		// Handle initialization of the necessary firebase modules:
//		void InitializeFirebase()
//		{
//			Debug.Log("Setting up Firebase Auth");
//			auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//			auth.StateChanged += AuthStateChanged;
//			AuthStateChanged(this, null);
//		}

//		// Track state changes of the auth object.
//		void AuthStateChanged(object sender, System.EventArgs eventArgs)
//		{
//			if (auth.CurrentUser != user)
//			{
//				bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
//				if (!signedIn && user != null)
//				{
//					Debug.Log("Signed out " + user.UserId);
//				}
//				user = auth.CurrentUser;
//				if (signedIn)
//				{
//					Debug.Log("Signed in " + user.UserId);
//				}
//			}
//		}

//		void OnDestroy()
//		{
//			auth.StateChanged -= AuthStateChanged;
//			auth = null;
//		}
//	}

//	public void GetSessionPorfile()
//	{
//		Firebase.Auth.FirebaseUser user = auth.CurrentUser;
//		if (user != null)
//		{
//			string name = user.DisplayName;
//			string email = user.Email;
//			System.Uri photo_url = user.PhotoUrl;
//			// The user's Id, unique to the Firebase project.
//			// Do NOT use this value to authenticate with your backend server, if you
//			// have one; use User.TokenAsync() instead.
//			string uid = user.UserId;
//		}
//	}

//	public void GetActiveSession()
//	{
//		Firebase.Auth.FirebaseAuth auth;
//		Firebase.Auth.FirebaseUser user;

//		// Handle initialization of the necessary firebase modules:
//		void InitializeFirebase()
//		{
//			Debug.Log("Setting up Firebase Auth");
//			auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//			auth.StateChanged += AuthStateChanged;
//			AuthStateChanged(this, null);
//		}

//		// Track state changes of the auth object.
//		void AuthStateChanged(object sender, System.EventArgs eventArgs)
//		{
//			if (auth.CurrentUser != user)
//			{
//				bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
//				if (!signedIn && user != null)
//				{
//					Debug.Log("Signed out " + user.UserId);
//				}
//				user = auth.CurrentUser;
//				if (signedIn)
//				{
//					Debug.Log("Signed in " + user.UserId);
//				}
//			}
//		}

//		void OnDestroy()
//		{
//			auth.StateChanged -= AuthStateChanged;
//			auth = null;
//		}
//	}

//	public void LoginSessionByEmail()
//	{
//		string email = inputFieldEmail.text;
//		string password = inputFieldPassword.text;

//		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
//			if (task.IsCanceled)
//			{
//				Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
//				return;
//			}
//			if (task.IsFaulted)
//			{
//				Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
//				return;
//			}

//			Firebase.Auth.FirebaseUser newUser = task.Result;
//			Debug.LogFormat("User signed in successfully: {0} ({1})",
//				newUser.DisplayName, newUser.UserId);
//			loginIndication = true;
//		});
//	}
//}
