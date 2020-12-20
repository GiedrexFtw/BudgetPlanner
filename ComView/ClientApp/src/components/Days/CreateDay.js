
import React, { useState, useEffect, Component } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import "../Login/LoginForm.css";
import Select from 'react-select';
import { Cookies } from 'react-cookie';
import { Spinner } from 'react-bootstrap';
var DatePicker = require("reactstrap-date-picker");

export class CreateDay extends Component {
    static displayName = CreateDay.name;

    constructor(props) {
        super(props)
        this.state = {
            description: "",
            value: new Date().toISOString()
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleChange(value, formattedValue) {
        this.setState({
            value: value, // ISO String, ex: "2016-11-19T12:00:00.000Z"
            
        })
    }
    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        this.setState({ loading: false });
    }
    validateForm() {
        return true;
    }

    async handleSubmit(event) {
        event.preventDefault();
        console.log(event.target[0])
        console.log(this.state.value)
            let day = {
                Date: this.state.value,
                Description: event.target[1].value,
            };
            let cookie = new Cookies();
            let jwt = cookie.get("access_token");
            const response = await fetch('https://localhost:6001/api/days', {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                    "Authorization": "bearer " + jwt
                },
                redirect: "follow",
                body: JSON.stringify(day)
            });
            await response;
            if (response.status != 201) {
                this.state.error = "The information entered is invalid! Please check all the mandatory fields and try again";
                return null;
            }
            this.props.history.push("/days");
        
    }
    renderForm() {
        //console.log(this.state.categoryOptions)
        return (
            <div className="Login">
                <p className="text-danger center font-weight-bold">{this.state.error}</p>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group size="lg" controlId="Title">
                        <Form.Label>Choose date</Form.Label>
                            <DatePicker id="example-datepicker"
                                value={this.state.value}
                                onChange={(v, f) => this.handleChange(v, f)} />
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
                <h1 className="center">Create Day</h1>
                {contents}
            </div>
        );
    }
}
