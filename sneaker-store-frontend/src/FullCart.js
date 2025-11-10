import React, { useState, useEffect } from "react";
//import { Link } from 'react-router'
import "./FullCart.css"
import CheckoutButton from "./Checkout";
import { getCartItems } from "./api/CartService";
export default function FullCart({total, setTotal, cartCount, setCartCount }) {
    const [shippingPrice, setShippingPrice] = useState(0);
    const [updatedTotal, setUpdatedTotal] = useState(total);
    const [cartItems, setCartItems] = useState([]);

    useEffect(() => {
        async function loadCart() {
            const items = await getCartItems();
            setCartItems(items);
            const newTotal = items.reduce((sum, item) => sum + item.price * item.quantity, 0);
            setTotal(newTotal);
            setUpdatedTotal(newTotal);
        }
        loadCart();
    }, []);


    function handleIncrement(index) {
        const items = [...cartItems];
        items[index].count += 1;
        setCartItems(items);
        setTotal(total + items[index].price);
        setUpdatedTotal(updatedTotal + items[index].price);
        setCartCount(cartCount + 1);
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
            setUpdatedTotal(updatedTotal - itemPrice);
        }
        setCartCount(cartCount - 1);
        setCartItems(items);
    }

    function handleTrash(index) {
        const items = [...cartItems];
        const itemPrice = items[index].price;
        const itemCount = items[index].count;
        items.splice(index, 1);
        setCartItems(items);
        setCartCount(cartCount - itemCount);
        setTotal(total - (itemPrice * itemCount));
        setUpdatedTotal(updatedTotal - (itemPrice * itemCount));
    }

    return (
        <>
            <h1 className="cartHeader">Shopping Cart</h1>
            <div className="shoppingCart">
                {cartItems.length > 0 &&
                    <div className="fullCart" >
                        {cartItems.map((item, index) => (
                            <ul key={item.id || index}>
                                <li>
                                    <img src={item.imageUrl} alt={item.name} />
                                    <div className="cart-info">
                                        <div className="description-wrapper">
                                            <strong className="item-name">{item.name}</strong>
                                            <p>${item.price}</p>
                                        </div>
                                        <div className="amount-wrapper">
                                            <button className="decrement" onClick={() => handleDecrement(index)}>- </button>
                                            <p className="amount">{item.count}</p>
                                            <button className="increment" onClick={() => handleIncrement(index)}> +</button>
                                            <button className="trash" onClick={() => handleTrash(index)}>🗑️</button>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        ))}
                    </div>}
                <div className="checkoutDiv">
                    <h2>Cart Summary</h2>
                    <p className="cart-count">{cartCount} item{cartCount !== 1 ? "s" : ""} in Cart</p>
                    <div className="shipping-method">
                        <label>Shipping Method</label>
                        <select className="shipping-dropdown" onChange={(e) => {
                            const selectedValue = e.target.value;
                            if (selectedValue === "standard") {
                                if (shippingPrice === 10) {
                                    setUpdatedTotal(updatedTotal - 10);

                                }
                                setShippingPrice(0);
                            } else if (selectedValue === "express") {
                                if (shippingPrice === 0) {
                                    setUpdatedTotal(total + 10);
                                }
                                setShippingPrice(10);
                            }

                        }}>
                            <option value="standard">Standard Shipping (Free)</option>
                            <option value="express">Express Shipping ($10.00)</option>
                        </select>
                    </div>
                    <div className="sub-total">
                        <p className="subtotal-p">Sub-total</p>
                        <p>${total.toFixed(2)}</p>
                    </div>
                    <div className="shipping">
                        <p className="shipping-p">Shipping</p>
                        <p>${shippingPrice}</p>
                    </div>

                    <div className="total">
                        <p className="total-p">Total</p>
                        <p>${updatedTotal.toFixed(2)}</p>
                    </div>n
                    <CheckoutButton cartItems={cartItems} shippingPrice={shippingPrice}>

                    </CheckoutButton>
                </div>

            </div>
        </>
    )
}
