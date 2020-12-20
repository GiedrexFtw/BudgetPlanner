import React, { useState, useEffect, Component } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import "../Login/LoginForm.css";
import Select from 'react-select';
import { Cookies } from 'react-cookie';
import { Spinner } from 'react-bootstrap';


export class CreateProduct extends Component {
    static displayName = CreateProduct.name;

    constructor(props) {
        super(props)
        this.state = {
            categoryOptions: [],
            dayOptions: [],
            title: "",
            description: "",
            amount: 0,
            error: "",
            loading: true,
            selectedCategory: 0,
            selectedDay: 0
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        this.getCategoryOptions(jwt);
        this.getDayOptions(jwt);
        this.setState({ loading: false });
    }
    handleCategoryChange = (selectedOption) => {
        this.setState({ selectedCategory: selectedOption.value });
    }
    handleDayChange = (selectedOption) => {
        this.setState({ selectedDay: selectedOption.value });
    }
    async getCategoryOptions(jwt) {
        if (typeof jwt !== "undefined") {
            const response = await fetch('https://localhost:6001/api/categories', {
                headers: {
                    "Authorization": "bearer " + jwt
                },
                redirect: "follow"
            });
            if (response.status !== 200) {
                window.location.replace("/login");
            }
            const data = await response.json();
            var val = data.map(prod => ({ value: prod.id, label: prod.title }));
            this.state.categoryOptions = val;
            this.setState({ loading: false });
        }
    }
    async getDayOptions(jwt) {
        if (typeof jwt !== "undefined") {
            const response = await fetch('https://localhost:6001/api/days', {
                headers: {
                    "Authorization": "bearer " + jwt
                },
                redirect: "follow"
            });
            if (response.status !== 200) {
                window.location.replace("/login");
            }
            const data = await response.json();
            var val = data.map(prod => ({ value: prod.id, label: prod.date.split('T')[0] }));
            this.state.dayOptions = val;
            this.setState({ loading: false });
        }
    }
    validateForm() {
        if (this.state.title.length < 3 || this.state.amount <= 0 || this.selectedCategory === 0 || this.selectedDay === 0) {
            return false;
        }
        return true;
    }

    async handleSubmit(event) {
        event.preventDefault();
        if (event.target[0].value.length > 3 && event.target[2].value>0 && this.state.selectedCategory != 0 && this.state.selectedDay != 0) {
            let product = {
                Title: event.target[0].value,
                Description: event.target[1].value,
                Amount: event.target[2].value,
                CategoryId: this.state.selectedCategory,
                DayId: this.state.selectedDay
            };
            let cookie = new Cookies();
            let jwt = cookie.get("access_token");
            const response = await fetch('https://localhost:6001/api/products', {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                    "Authorization": "bearer " + jwt
                },
                redirect: "follow",
                body: JSON.stringify(product)
            });
            const data = await response.json();
            if (response.status != 201) {
                this.state.error = "The information entered is invalid! Please check all the mandatory fields and try again";
                return null;
            }
            this.props.history.push("/");
        }
    }
     renderForm() {
        //console.log(this.state.categoryOptions)
        return (
            <div className="Login">
                <p className="text-danger center font-weight-bold">{this.state.error}</p>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group size="lg" controlId="Title">
                        <Form.Label>Title</Form.Label>
                        <Form.Control
                            autoFocus
                            type="text"
                            value={this.state.title}
                            onChange={(e) => this.setState({title: e.target.value})}
                        />
                    </Form.Group>
                    <Form.Group size="lg" controlId="Description">
                        <Form.Label>Description</Form.Label>
                        <Form.Control
                            as="textarea"
                            rows={3}
                            value={this.state.description}
                            onChange={(e) => this.setState({ description: e.target.value })}
                        />
                    </Form.Group>
                    <Form.Group size="lg" controlId="Amount">
                        <Form.Label>Cost</Form.Label>
                        <Form.Control
                            type="number"
                            value={this.state.amount}
                            onChange={(e) => this.setState({ amount: e.target.value})}
                            //value={this.state.amount} onChange={event => this.setState({ amount: event.target.value.replace(/\D/, '') })}
                        />
                    </Form.Group>
                    <Form.Group size="lg" controlId="Category">
                        <Form.Label>Category</Form.Label>
                        <Select
                            options={this.state.categoryOptions}
                            onChange={this.handleCategoryChange}
                        />
                    </Form.Group>
                    <Form.Group size="lg" controlId="Day">
                        <Form.Label>Day</Form.Label>
                        <Select
                            options={this.state.dayOptions}
                            onChange={ this.handleDayChange}
                        />
                    </Form.Group>
                    <Button block size="lg" type="submit" disabled={!this.validateForm()}>
                        Create
                </Button>
                </Form>
            </div>
        )
    }
    
    render() {
        let contents = this.state.loading
            ? <div>
                <Spinner type="grow" color="warning">
                </Spinner>
                <Spinner type="grow" color="success">
                </Spinner>
                <Spinner type="grow" color="danger">
                </Spinner>
                <p><em>Loading...</em></p>
            </div>
            : this.renderForm();
        return (
            <div>
                <h1 className="center">LOGIN</h1>
                {contents}
            </div>
        );
    }
}
