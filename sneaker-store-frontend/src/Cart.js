import React from "react";
import "./Cart.css";

const Cart = ({ cartItems }) => {
    return (
        <div className="cart">
            <h2>Your Cart</h2>
            {cartItems.length === 0 ? (
                <p>Your cart is empty 🛒</p>
            ) : (
                <ul>
                    {cartItems.map((item, index) => (
                        <li key={index}>
                            <img src={item.imageUrl} alt={item.name} />
                            <div>
                                <strong>{item.name}</strong>
                                <p>${item.price}</p>
                            </div>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default Cart;