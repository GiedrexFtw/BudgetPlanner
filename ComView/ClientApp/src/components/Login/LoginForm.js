import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useCookies } from "react-cookie";
import { useHistory } from 'react-router-dom';
import "./LoginForm.css";

export function LoginForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [cookies, setCookie] = useCookies(["access_token", "refresh_token"]);
    const [error, setError] = useState("");
    const history = useHistory();
    function validateForm() {
        return username.length > 3 && password.length > 3;
    }

    async function handleSubmit(event) {
        event.preventDefault();
        if (event.target[0].value.length > 3 && event.target[1].value.length > 3) {
            let tokens = await getTokens(event.target[0].value, event.target[1].value);
            if (tokens == null) {
                return;
            }
            let expires = new Date();
            
            expires.setTime(expires.getTime() + (tokens.expires_in * 1000));
            setCookie('access_token', tokens.jwtToken, { path: '/', expires });
            setCookie('refresh_token', tokens.refToken, { path: '/', expires });
            history.push('/');
        }
    }

    async function getTokens(username, password) {
        const response = await fetch('https://localhost:6001/api/login', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username: username, password: password })
            });
        const data = await response.json();
        if (response.status != 200) {
            setError("User with these credentials doesn't exist! Please try again.")
            return null;
        }
        console.log(data)
        return data;
    }

    return (
        <div className="Login">
            <p className="text-danger center font-weight-bold">{error}</p>
            <Form onSubmit={handleSubmit}>
                <Form.Group size="lg" controlId="username">
                    <Form.Label>Username</Form.Label>
                    <Form.Control
                        autoFocus
                        type="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="password">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </Form.Group>
                <Button block size="lg" type="submit" disabled={!validateForm()}>
                    Login
                </Button>
            </Form>
        </div>
    );
}

