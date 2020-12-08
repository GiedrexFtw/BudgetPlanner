import React, { Component } from 'react';
import { RegisterForm } from './RegisterForm';
import { Link } from 'react-router-dom';

export class Register extends Component {
    static displayName = Register.name;

    render() {
        return (
            <div>
                <h1 className="center">Register</h1>
                <RegisterForm />
                <p className="center">Already have an account? Press <Link tag={Link} to="/login">here</Link> to login.</p>
            </div>
        );
    }
}
