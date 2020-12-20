import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useCookies } from "react-cookie";
import { useHistory } from "react-router-dom";
//import "./RegisterForm.css";

export function RegisterForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [email, setEmail] = useState("");
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [error, setError] = useState("");
    const showPasswordInvalidMessage =
        password != confirmPassword ? <p className="text-danger"> The passwords entered do not match! </p> : '';
    const showGlyphicon = password != confirmPassword ? "glyphicon glyphicon-remove form-control-feedback" : "glyphicon glyphicon-ok form-control-feedback";
    const [cookies, setCookie] = useCookies(["access_token", "refresh_token"]);
    const history = useHistory();

    function validateForm() {
        return username.length > 3 && password.length > 3 && email.length > 5;
    }

    async function handleSubmit(event) {
        event.preventDefault();
        if (password === confirmPassword) {
            let user = {};
            for (var i = 0; i < event.target.length-2; i++) {
                user[event.target[i].name] = event.target[i].value;
            }
            let tokens = await getTokens(user);
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
    async function getTokens(user) {
        const response = await fetch('https://localhost:6001/api/register', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        const data = await response.json();
        if (response.status != 200) {
            setError("The information entered is invalid! Please check all the mandatory fields and try again");
            return null;
        }
        console.log(data)
        return data;
    }

    return (
        <div className="Login">
            <p className="text-danger">{error}</p>
            <Form onSubmit={handleSubmit}>
                <Form.Group size="lg" controlId="username">
                    <Form.Label>Username*</Form.Label>
                    <Form.Control
                        autoFocus
                        type="username"
                        name="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="name">
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        type="text"
                        name="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="surname">
                    <Form.Label>Surname</Form.Label>
                    <Form.Control
                        type="text"
                        name="surname"
                        value={surname}
                        onChange={(e) => setSurname(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="email">
                    <Form.Label>Email*</Form.Label>
                    <Form.Control
                        type="email"
                        name="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </Form.Group>
                <Form.Group size="lg" controlId="password" className="has-error has-success has-feedback">
                    <Form.Label>Password*</Form.Label>
                    <Form.Control
                        type="password"
                        name="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className={showGlyphicon}
                    />
                </Form.Group>
                { showPasswordInvalidMessage }
                <Form.Group size="lg" controlId="confirmPassword" className="has success has-error has-feedback">
                    <Form.Label>Confirm password*</Form.Label>
                    <Form.Control
                        type="password"
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                        className={showGlyphicon }
                    />
                </Form.Group>
                <Button block size="lg" type="submit" disabled={!validateForm()} style={{ backgroundColor:"#f4511e"}}>
                    Register
                </Button>
            </Form>
        </div>
    );
}