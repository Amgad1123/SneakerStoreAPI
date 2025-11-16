import React from "react";
import { removeFromCart } from "./api/CartService";

const CheckoutButton = ({ cartItems, shippingPrice }) => {
    function clearCart() {
        cartItems.forEach(item => {
            removeFromCart(item.name);
        })
    }
    const handleCheckout = async () => {
        try {
            //  Map cartItems to the structure Stripe expects
            let items = cartItems.map(item => ({
                name: item.name,
                price: item.price,
                quantity: item.quantity,
                imageUrl: item.imageUrl 
            }));

            if (shippingPrice > 0) {
                items.push({
                    name: "Express Shipping",
                    price: Number(shippingPrice),
                    quantity: 1,
                    imageUrl: "https://yourdomain.com/images/shipping-icon.png"
                });
            }

            // Call backend to create checkout session
            const response = await fetch("https://sneakerstoreapi.onrender.com/api/payments/create-checkout-session", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ items }),
            });

            if (!response.ok) throw new Error("Failed to create checkout session");

            const data = await response.json();

            // Redirect to Stripe Checkout
            window.location.href = data.url;
            clearCart();
            alert("Checkout successful!");
        } catch (error) {
            console.error("Checkout error:", error);
            alert("Checkout failed. Please try again.");
        }
    };

    return (
        <button onClick={handleCheckout} className="checkout-link">
            Checkout
        </button>
    );
};

export default CheckoutButton;
