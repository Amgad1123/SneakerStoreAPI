import React from "react";
import { Link } from 'react-router';
import "./Cart.css";

const Cart = ({ cartItems, setCartItems, total, setTotal }) => {
    function handleIncrement(index) {
        const items = [...cartItems];
        items[index].count += 1;
        setCartItems(items);
        setTotal(total + items[index].price);
    }

    function handleDecrement(index) {
        const items = [...cartItems];
        const itemPrice = items[index].price;

        if (items[index].count <= 1) {
            setTotal(total - itemPrice);
            items.splice(index, 1);
        } else {
            items[index].count -= 1;
            setTotal(total - itemPrice);
        }

        setCartItems(items);
    }

    return (
        <div className="cart">
            <h2>Your Cart</h2>
            {cartItems.length === 0 ? (
                <p>Your cart is empty 🛒</p>
            ) : (
                <div>
                    {cartItems.map((item, index) => (
                        <ul key={item.id || index}>
                            <li>
                                <img src={item.imageUrl} alt={item.name} />
                                <div>
                                    <strong>{item.name}</strong>
                                    <p>${item.price}</p>
                                </div>
                                <button className="decrement" onClick={() => handleDecrement(index)}>-</button>
                                <p className="amount">{item.count}</p>
                                <button className="increment" onClick={() => handleIncrement(index)}>+</button>
                            </li>
                        </ul>
                    ))}
                        <h2>Total: ${total.toFixed(2)}</h2>
                        <Link to= "/Cart" className = "cartButton">View Cart</Link>
                </div>
            )}
        </div>
    );
};

export default Cart;