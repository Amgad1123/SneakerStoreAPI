import { React, useState} from "react";  
import { Link } from 'react-router';
import { registerUser } from "./api/auth.js";
import { useNavigate } from "react-router-dom";
import "./Register.css";
export default function Register() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await registerUser(email, password);
            alert(result);
            navigate("/Login");
        } catch (err) {
            setMessage(err.message);
        }
    };
    return (
        <div className="signup-form">
            <h2 className="reg-header">Register</h2>
            <div className="underLine"></div>
            <p className ="errors"></p>
            <form onSubmit={handleSubmit}>
                <div className="form-group">  
                    <label htmlFor="email">Email</label>
                    <input type="text" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)} required />
                </div>  
                <button type="submit" className="signIn">Register</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    )
}
