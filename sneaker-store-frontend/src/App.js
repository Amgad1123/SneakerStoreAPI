import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route} from "react-router-dom"; 
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import SneakerList from "./SneakerList";
import Cart from "./Cart";
import FullCart from "./FullCart";
import Register from "./Register";
import Login from "./Login";
//import { GoogleOAuthProvider } from '@react-oauth/google'

function App() {
    //const clientId = "Your-Google-OAuth-Client-ID"; 
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedBrand, setSelectedBrand] = useState("");
    const [maxPrice, setMaxPrice] = useState("");
    const [cartItems, setCartItems] = useState([]);
    const [total, setTotal] = useState(0);
    const [cartOpen, setCartOpen] = useState(false);
    const [openFullCart, setOpenFullCart] = useState(false);
    const [cartCount, setCartCount] = useState(0);
    const handleAddToCart = (sneaker) => {
        const existingIndex = cartItems.findIndex(item => item.id === sneaker.id);
        let totalAmount = total;
        if (existingIndex !== -1) {
            // Sneaker already in cart, increment count
            const updatedItems = [...cartItems];
            updatedItems[existingIndex].count += 1;
            setCartItems(updatedItems)
            setTotal(total + updatedItems[existingIndex].price);
        } else {
            // New sneaker, add with count 1
            const updatedItems = [...cartItems, { ...sneaker, count: 1 }];
            setCartItems(updatedItems);
            totalAmount += sneaker.price;
            setTotal(totalAmount);
        }

    };
    
    return (
        <Router>
            <Navbar total={total} setTotal={setTotal} cartCount={cartCount} onCartClick={() => setCartOpen(!cartOpen)} on />

            {cartOpen && <Cart total={total} setTotal={setTotal} onCartClick={() => { setOpenFullCart(true) }} cartCount={cartCount} setCartCount={setCartCount} cartItems={cartItems} setCartItems={setCartItems} openFullCart={openFullCart} setOpenFullCart={setOpenFullCart} setCartOpen={setCartOpen} />}
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
                        cartCount={cartCount}
                        setCartCount={setCartCount }
                    />
                </>
                }
                />
                <Route path="/Cart" element={
                    <FullCart
                        total={total} setTotal={setTotal} cartItems={cartItems} setCartItems={setCartItems} setCartCount={setCartCount} cartCount={cartCount}
                />}></Route>

                <Route path="/Register" element={
                    <Register
                       
                    />}></Route>

                <Route path="/Login" element={
                    <Login

                    />}></Route>
            </Routes>
           

        </Router>
    );
}

export default App;