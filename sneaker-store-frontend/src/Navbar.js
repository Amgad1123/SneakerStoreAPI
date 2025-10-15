import React from "react";
import "./Navbar.css";
import { Link } from 'react-router-dom';
const Navbar = ({ cartCount, onCartClick}) => (
    <div className="navbar">    
        <Link to="/" className="logo-link">Sneaker Vault</Link>
        <div className="nav-buttons">
            <button>Sign In</button>
            <button>Register</button>
            <button onClick={onCartClick}>🛒 Cart ({cartCount})</button>
        
        </div>
    </div>
);

export default Navbar;