using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Firestore;
using TMPro;
using UnityEngine.SceneManagement;

public class FirebaseLogin : MonoBehaviour
{
    //FIREBASE VARIABLES
    FirebaseAuth auth;
    FirebaseUser user;
    //GAMEOBJECT VARIABLES
    [Header("PANELS")]
    public GameObject loginPanel;
    public GameObject registerPanel;
    [Header("LOGIN OBJECTS")]
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;
    [Header("REGISTER OBJECTS")]
    public TMP_InputField registerName;
    public TMP_InputField registerSurname;
    public TMP_InputField registerCI;
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    //VALUES TO FIRESTORE SEND
    string email;
    string password;
    string identificadorAuth;
    //FLAGS
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase(); //FIREBASE STARTS
        EnableLoginPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag) //para intentar las veces necesarias 
        {
            SendRegisterDataFirestore();
        }
    }
    //REGISTER NEW USER 
    public void RegisterNewUser()
    {
        Debug.Log(registerName.text);
        Debug.Log(registerSurname.text);
        Debug.Log(registerCI.text);
        Debug.Log(registerEmail.text);
        Debug.Log(registerPassword.text);
        email = registerEmail.text;
        password = registerPassword.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;            
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            //
            //ClearRegisterPanelFields();
            flag = true;
            //SendRegisterDataFirestore(newUser.UserId); //envio del id a la funcion
            SendRegisterDataFirestore();

        });
    }
    //LOGIN USER
    public void LoginUser()
    {
        Debug.Log(loginEmail.text);
        Debug.Log(loginPassword.text);
        email = loginEmail.text;
        password = loginPassword.text;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            //
            ClearLoginPanelFields();
        });
        //
       
    }
    //FIRESTORE
    void SendRegisterDataFirestore()
    {
        Debug.Log("Envio de datos a FIRESTORE: "+ registerEmail.text);
        string userPath = "users/" + registerEmail.text; //ruta en firestore
        var user = new userFS
        {
            userName = registerName.text,
            userSurname = registerSurname.text,
            userCI = registerCI.text,
            userEmail = registerEmail.text,
            userPassword = registerPassword.text
        };
        var firestore = FirebaseFirestore.DefaultInstance;
        //firestore.Document(userPath).SetAsync(user);
        firestore.Document(userPath).SetAsync(user);
        Debug.Log("Se enviaron los datos correctamente a firestore");
        flag = false;
    }
    //CLEAR PANEL FIELDS
    void ClearLoginPanelFields()
    {
        loginEmail.text = "";
        loginPassword.text = "";
        string email = loginEmail.text;
        string password = loginPassword.text;
    }
    void ClearRegisterPanelFields()
    {
        registerName.text = "";
        registerSurname.text = "";
        registerCI.text = "";
        registerEmail.text = "";
        registerPassword.text = "";
    }
    //PANEL JUMP FUNCTIONS 
    public void GoToRegisterPanel()
    {
        EnableRegisterPanel();
        ClearLoginPanelFields();
    }
    public void GoToLoginPanel()
    {
        EnableLoginPanel();
        ClearRegisterPanelFields();
    }
    //ENABLE AND DISABLE PANELS
    void EnableLoginPanel()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
    }
    void EnableRegisterPanel()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
    }
    //FIREBASE SETUP
    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                //displayName = user.DisplayName ?? "";
                //emailAddress = user.Email ?? "";
                //photoUrl = user.PhotoUrl ?? "";
            }
        }
    }
}
