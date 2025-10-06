import React from "react";
import "./Sidebar.css";

const Sidebar = ({ onSearchChange, onBrandChange, onPriceChange }) => (
    <div className="sidebar">
        <input
            class = "searchBar"
            type="text"
            placeholder="Search by name"
            onChange={e => onSearchChange(e.target.value)}
        />
        <select onChange={e => onBrandChange(e.target.value)}>
            <option value="">All Brands</option>
            <option value="Jordan">Jordan</option>
            <option value="Nike">Nike</option>
            <option value="Adidas">Adidas</option>
            <option value="New Balance">New Balance</option>
            <option value="Converse">Converse</option>
        </select>
        <input
            type="number"
            placeholder="Max Price"
            onChange={e => onPriceChange(e.target.value)}
        />
    </div>
);

export default Sidebar;