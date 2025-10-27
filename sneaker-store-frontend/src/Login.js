import { React, useState } from "react";
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
            alert("Login successful!");
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
            })
           navigate("/")
        } catch (err) {
            setMessage(err.message);
        }
    };
    return (
        <div className="signin-form">
            <h2 className="signIn-header">Login</h2>
            <div className="underLine"></div>
            <p className="errors"></p>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input type="text" id="email" name="email" onChange={(e) => setEmail(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)} required />
                </div>
                <button type="submit" className = "signIn">Login</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    )
}
