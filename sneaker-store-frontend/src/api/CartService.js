const API_URL = "https://sneakerstoreapi.onrender.com/api/cart";

export async function getCartItems() {
    const res = await fetch(API_URL);
    return res.json();
}

export async function addToCart(item) {
    const res = await fetch("https://sneakerstoreapi.onrender.com/api/cart", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            imageUrl: item.imageUrl,
            name: item.name,
            price: item.price,
            quantity: 1, 

        }),
    });

    if (!res.ok) throw new Error("Failed to add item to cart");
    return res.json();
}

export async function updateCartItem(name, item) {
    const res = await fetch(`${API_URL}/${name}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(item),
    });
    return res.json();
}

export async function removeFromCart(name) {
    const res = await fetch(`${API_URL}/${name}`, {
        method: "DELETE",
    });
    return res.json();
}
