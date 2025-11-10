import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route} from "react-router-dom"; 
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import SneakerList from "./SneakerList";
import Cart from "./Cart";
import FullCart from "./FullCart";
import Register from "./Register";
import Login from "./Login";
import { addToCart, getCartItems } from "./api/CartService";
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


    const handleAddToCart = async (sneaker) => {
        try {
            const existingIndex = cartItems.findIndex(item => item.id === sneaker.id);

            if (existingIndex !== -1) {
                // Already exists → increment count
                const updatedItem = {
                    ...cartItems[existingIndex],
                    quantity: cartItems[existingIndex].quantity + 1,
                };

                await addToCart(updatedItem);
            } else {
                // New sneaker, add with count = 1
                await addToCart({
                    name: sneaker.name,
                    price: sneaker.price,
                    quantity: 1,
                    imageUrl: sneaker.imageUrl
                });
            }

            // Refresh the cart from backend
            const updatedCart = await getCartItems();
            setCartItems(updatedCart);

            console.log(cartItems)
            // Recalculate total
            const newTotal = updatedCart.reduce(
                (sum, item) => sum + item.price * item.quantity,
                0
            );
            setTotal(newTotal);

        } catch (error) {
            console.error("Error adding to cart:", error);
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
                <Route path="/success" element={<h2>✅ Payment successful! Thank you for your purchase.</h2>} />
                <Route path="/cancel" element={<h2>❌ Payment canceled. Try again later.</h2>} />
            </Routes>
           

        </Router>
    );
}

export default App;