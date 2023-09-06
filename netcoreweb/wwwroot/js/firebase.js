// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getAuth } from "firebase/auth";
import { getFirestore } from "firebase/firestore";

// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyC78iFQ7Hwyj1GLg2leu4h9nxX_A71J87A",
    authDomain: "gutsprojectv1.firebaseapp.com",
    projectId: "gutsprojectv1",
    storageBucket: "gutsprojectv1.appspot.com",
    messagingSenderId: "37469903159",
    appId: "1:37469903159:web:9ce98dd754575459dea2b2",
    measurementId: "G-56EGXMKRC7"
};

// Initialize Firebase
const app = app.initializeApp(firebaseConfig);
const auth = app.auth();
const db = app.firestore(); // Use firestore instead of database

function register() {
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    if (validate_password(password) == false) {
        alert("Password is not valid");
        return;
    }

    auth.createUserWithEmailAndPassword(email, password)
        .then(function () {
            var user = auth.currentUser;

            var user_data = { email: email, last_login: Date.now() };
            db.collection('users').doc(user.uid).set(user_data);
        })
        .catch(function (error) {
            alert("Error: " + error.message);
        });
}

function validate_password(password) {
    // Implement your password validation logic here
    // For example, you can check the length or complexity of the password
    if (password.length < 6) {
        return false;
    } else {
        return true;
    }
}

function validate_field(field) {
    if (field == null || field <= 0) {
        return false;
    } else {
        return true;
    }
}