import React from "react";
import "./Navbar.css";
import { Link } from 'react-router-dom';
const Navbar = ({ cartCount, onCartClick}) => (
    <div className="navbar">    
        <Link to="/" className="logo-link">Sneaker Vault</Link>
        <div className="nav-buttons">
            <Link to="/Login" className="login-link">Login</Link>
            <Link to="/Register" className="register-link">Register</Link>
            <button onClick={onCartClick}>🛒 Cart ({cartCount})</button>
      
        </div>
    </div>
);

export default Navbar;