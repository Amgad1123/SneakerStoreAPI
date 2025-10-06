import React from "react";
import "./Navbar.css";

const Navbar = ({cartCount,onCartClick }) => (
    <div className="navbar">
        <h1>Sneaker Store</h1>
        <div className="nav-buttons">
            <button>Sign In</button>
            <button>Register</button>
            <button onClick={onCartClick}>🛒 Cart ({cartCount})</button>
        
        </div>
    </div>
);

export default Navbar;