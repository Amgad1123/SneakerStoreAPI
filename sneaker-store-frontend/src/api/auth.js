const API_BASE_URL = "http://localhost:5158";

export async function registerUser(email, password) {
    const response = await fetch(`${API_BASE_URL}/api/auth/register`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
        const message = await response.text();
        throw new Error(message || "Failed to register");
    }

    return await response.text(); // "User registered successfully"
}

export async function loginUser(email, password) {
    const response = await fetch(`${API_BASE_URL}/api/auth/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
        const message = await response.text();
        throw new Error(message || "Failed to login");
    }

    return await response.json(); // { token: "..." }
}
