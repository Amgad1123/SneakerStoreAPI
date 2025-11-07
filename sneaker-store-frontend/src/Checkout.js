import React from "react";

const CheckoutButton = ({ cartItems, shippingPrice }) => {
    const handleCheckout = async () => {
        try {
            // 🧾 Map your cartItems to the structure Stripe expects
            let items = cartItems.map(item => ({
                name: item.name,
                price: item.price,
                quantity: item.count,
            }));

            if (shippingPrice > 0) {
                items.push({
                    name: "Express Shipping",
                    price: shippingPrice,
                    quantity: 1
                });
            }

            // 🎯 Call backend to create checkout session
            const response = await fetch("http://localhost:5158/api/payments/create-checkout-session", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ items }),
            });

            if (!response.ok) throw new Error("Failed to create checkout session");

            const data = await response.json();

            // 🚀 Redirect to Stripe Checkout
            window.location.href = data.url;
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
