import React, { Component } from 'react';
import { LoginForm } from './LoginForm.js';
import { Link } from 'react-router-dom';

export class Login extends Component {
    static displayName = Login.name;

    render() {
        return (
            <div>
                <h1 className="center">LOGIN</h1>
                <LoginForm/>
                <p className="center">Don't have an account yet? Press <Link tag={Link} to="/register">here</Link> to register.</p>
            </div>
        );
    }
}
