import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route} from "react-router-dom"; 
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import SneakerList from "./SneakerList";
import Cart from "./Cart";
import FullCart from "./FullCart";


function App() {
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedBrand, setSelectedBrand] = useState("");
    const [maxPrice, setMaxPrice] = useState("");
    const [cartItems, setCartItems] = useState([]);
    const [total, setTotal] = useState(0);
    const handleAddToCart = (sneaker) => {
        const existingIndex = cartItems.findIndex(item => item.id === sneaker.id);
        let totalAmount = total;
        if (existingIndex !== -1) {
            // Sneaker already in cart, increment count
            const updatedItems = [...cartItems];
            updatedItems[existingIndex].count += 1;
            setCartItems(updatedItems)
        } else {
            // New sneaker, add with count 1
            const updatedItems = [...cartItems, { ...sneaker, count: 1 }];
            setCartItems(updatedItems);
            totalAmount += sneaker.price;
            setTotal(totalAmount);
        }

    };
    const [cartOpen, setCartOpen] = useState(false);
    const [openFullCart, setOpenFullCart] = useState(false);
    return (
        <Router>
            <Navbar total={total} setTotal={setTotal} cartCount={cartItems.length} onCartClick={() => setCartOpen(!cartOpen)} on/>
         
            {cartOpen && <Cart total={total} setTotal={setTotal} cartItems={cartItems} setCartItems={setCartItems} onCartClick={()=> setOpenFullCart(!openFullCart) } />}
            <Routes>
           
                <Route path="/" element={<>
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
                </>
                }
                />
                <Route path="/Cart" element={
                    <FullCart
                    total={total} setTotal={setTotal} cartItems={cartItems} setCartItems={setCartItems}
                />}></Route>

            </Routes>
           

        </Router>
    );
}

export default App;