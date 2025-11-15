import React, { useEffect, useState } from "react";
import "./SneakerList.css";

const SneakerList = ({ searchTerm, selectedBrand, maxPrice, onAddToCart, setCartCount, cartCount }) => {
    const [sneakers, setSneakers] = useState([]);

    useEffect(() => {
        fetch("https://sneakerstoreapi.onrender.com/api/sneakers")
            .then((res) => res.json())
            .then((data) => setSneakers(data))
            .catch((err) => console.error("Error fetching sneakers:", err));
    }, []);

    //  Step 1: Filter sneakers
    const filteredSneakers = sneakers.filter((sneaker) => {
        const matchesSearch = sneaker.name.toLowerCase().includes(searchTerm.toLowerCase());
        const matchesBrand =
            !selectedBrand || sneaker.brand.toLowerCase() === selectedBrand.toLowerCase();
        const matchesPrice =
            !maxPrice || parseFloat(sneaker.price) <= parseFloat(maxPrice);

        return matchesSearch && matchesBrand && matchesPrice;
    });

    //  Step 2: Pad with placeholders
    const placeholdersNeeded = Math.max(0, 12 - filteredSneakers.length);
    const paddedSneakers = [...filteredSneakers];

    for (let i = 0; i < placeholdersNeeded; i++) {
        paddedSneakers.push({ id: `placeholder-${i}`, placeholder: true });
    }

    return (
        <div className="sneaker-list">
            {paddedSneakers.map((sneaker) => (
                <div
                    key={sneaker.id}
                    className={`sneaker-card ${sneaker.placeholder ? "placeholder" : ""}`}
                >
                    {!sneaker.placeholder ? (
                        <>
                            <img src={sneaker.imageUrl} alt={sneaker.name} />
                            <h3>{sneaker.name}</h3>
                            <p>${sneaker.price}</p>
                            <button onClick={() => {
                                onAddToCart(sneaker)
                                setCartCount(cartCount + 1);
                            }}>Add to Cart</button>
                        </>
                    ) : null}
                </div>
            ))}
        </div>
    );
};

export default SneakerList;