import { React, useState } from "react";
import { GoogleLogin } from '@react-oauth/google';
import { jwtDecode }  from 'jwt-decode';
import { Link } from 'react-router';
import { loginUser } from "./api/auth";
import { useNavigate } from "react-router-dom";
import "./Register.css";
export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const data = await loginUser(email, password);
            localStorage.setItem("token", data.token); // ✅ Store JWT
            logout();
            navigate("/")
            alert("Login successful!");
        } catch (err) {
            setMessage(err.message);
        }
    };

     function logout() {
         //login register and logout frontend display 
         const loginButton = document.querySelector(".login-link");
         const nav = document.querySelector(".nav-buttons");
         loginButton.style.display = "none";
         const registerButton = document.querySelector(".register-link");
         registerButton.style.display = "none";
         const logoutButton = document.createElement("Button");
         logoutButton.textContent = "Logout";
         logoutButton.setAttribute("style", "background: transparent; color: #fff; border: 1px solid #fff; padding: 0.5rem; cursor: pointer; text - decoration: none; ")
         nav.append(logoutButton);
         logoutButton.addEventListener("click", () => {
             registerButton.style.display = "inline-block";
             loginButton.style.display = "inline-block";
             logoutButton.style.display = "none";
         });
    }
    const handleGoogleSuccess = async (credentialResponse) => {
        try {
            const token = credentialResponse.credential;
            const decoded = jwtDecode(token);
            console.log("Google decoded user:", decoded);

            const res = await fetch("https://sneakerstoreapi.onrender.com/api/auth/google", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ token }),
            });

            const data = await res.json();
            if (data.success) {
                localStorage.setItem("token", data.jwt); 
                logout();
                navigate("/");
                alert("Login successful!");
            } else {
                setMessage(data.message || "Google login failed");
            }
        } catch (err) {
            setMessage("Google login error");
        }
    };
    return (
        <div className="signin-form">
            <h2 className="signIn-header">Login</h2>
            <div className="underLine"></div>
            {message && <p className="errors">{message}</p>}
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input type="text" id="email" name="email" onChange={(e) => setEmail(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)} required />
                    <Link to="/Register" className = "registerLink">New here? Click to register</Link>
                </div>
                <div className="google-login">
                    <GoogleLogin
                        onSuccess={handleGoogleSuccess}
                        onError={() => {
                            setMessage("Google Login Failed");
                        }}
                    />
                </div>

                <button type="submit" className = "signIn">Login</button>
            </form>
        </div>
    )
}
