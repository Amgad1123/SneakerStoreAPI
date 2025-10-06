import React, { useState } from "react";
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import SneakerList from "./SneakerList";
import Cart from "./Cart";


function App() {
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedBrand, setSelectedBrand] = useState("");
    const [maxPrice, setMaxPrice] = useState("");
    const [cartItems, setCartItems] = useState([]);
    const handleAddToCart = (sneaker) => {
        setCartItems((prevItems) => [...prevItems, sneaker]);
    };
    const [cartOpen, setCartOpen] = useState(false);
    return (
        <div className="app-container">
            <Navbar cartCount={cartItems.length} onCartClick={() => setCartOpen(!cartOpen)}
/>  
            <div className="main-content">
                <Sidebar
                    onSearchChange={setSearchTerm}
                    onBrandChange={setSelectedBrand}
                    onPriceChange={setMaxPrice}
                />
                <SneakerList
                    searchTerm={searchTerm}
                    selectedBrand={selectedBrand}
                    maxPrice={maxPrice}
                    onAddToCart={handleAddToCart}
                />
            </div>
            {cartOpen && <Cart cartItems={cartItems} />}
        </div>
    );
}

export default App;