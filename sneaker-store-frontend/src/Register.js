import { React, useState} from "react";  
import { Link } from 'react-router';
import { registerUser } from "./api/auth.js";
import { useNavigate } from "react-router-dom";
import "./Register.css";
export default function Register() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await registerUser(email, password);
            alert(result);
            navigate("/Login");
        } catch (err) {
            const container = document.getElementById("errorList");

            const errors = Array.isArray(err) ? err : [err];

            container.innerHTML = errors
                .map(e => `<li style="color:red;">${e}</li>`)
                .join("");
        }
       
    };

    return (
        <div className="signup-form">
            <h2 className="reg-header">Register</h2>
            <div className="underLine"></div>
            <ul id="errorList"></ul>
            <form onSubmit={handleSubmit}>
                <div className="form-group">  
                    <label htmlFor="email">Email</label>
                    <input type="text" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)} required />
                    <Link to="/Login">Already a member? Click to sign in</Link>
                </div>           
                <button type="submit" className="signIn">Register</button>
            </form>
        </div>
    )
}
