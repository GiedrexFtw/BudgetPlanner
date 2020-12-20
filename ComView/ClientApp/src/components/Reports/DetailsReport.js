import React, { useState, useEffect, Component } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { Cookies } from 'react-cookie';
import { Spinner } from 'react-bootstrap';
import { Link } from "react-router-dom";


export class DetailsReport extends Component {
    static displayName = DetailsReport.name;

    constructor(props) {
        super(props)
        this.state = {
            loading: true,
            report: null,
            id: this.props.match.params.id,
        }
        this.redirectToEdit = this.redirectToEdit.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
    }
    componentDidMount() {
        var id = this.props.match.params.id;
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        this.getProduct(jwt, id);
    }
    async handleDelete(id) {
        //var id = this.props.match.params.id;
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        var r = window.confirm("Press a button!\nEither OK or Cancel.\nThe button you pressed will be displayed in the result window.");
        if (r == true) {
            if (typeof jwt !== "undefined") {
                const response = await fetch('https://localhost:6001/api/reports/' + this.state.id, {
                    method: "DELETE",
                    headers: {
                        "Authorization": "bearer " + jwt
                    },
                    redirect: "follow"
                });
                await response;
                this.props.history.push("/reports/");
            }
        }

    }
    redirectToEdit() {
        //window.location.replace("/days/edit/" + this.props.match.params.id
        this.props.history.push(this.props.match.params.id + "/edit");
    }
    async getProduct(jwt, id) {
        if (typeof jwt !== "undefined") {
            const response = await fetch('https://localhost:6001/api/reports/' + id, {
                headers: {
                    "Authorization": "bearer " + jwt
                },
                redirect: "follow"
            });
            if (response.status !== 200) {
                window.location.replace("/login");
            }
            const data = await response.json();
            this.setState({ loading: false, report: data });
        }
    }

    renderForm() {
        return (
            <div className="container details mb-4">
                <div className="row">
                    <div className="col-md-6 img">
                        <img src="https://1.bp.blogspot.com/-nzm908Pfunw/VqXgeRNp4LI/AAAAAAAACJI/wgeVntLSIT8/w1200-h630-p-k-no-nu/status-report.png" width="500px" height="200px" alt="" className="img-rounded center" />
                    </div>
                    <div className="col-md-6 details-desc" style={{ fontSize: "18px" }}>
                        <blockquote>
                            <h5><b>Date:</b> {this.state.report.date.split('T')[0]}</h5>
                            <h5><b>Type:</b> {this.state.report.type}</h5>
                            <h5><b>Title:</b> {this.state.report.title}</h5>
                            <small><cite title="Source Title"><b>Desciption:</b> {this.state.report.description}  <i className="icon-map-marker"></i></cite></small><br/>
                            <small><cite title="Source Title"><b>IsExportable:</b> {this.state.report.isexportable}  <i className="icon-map-marker"></i></cite></small>
                        </blockquote>
                        <Button onClick={this.redirectToEdit} className="col-md-3 mr-5 btn btn-info"  ><i className="fas fa-edit"></i></Button>
                        <Button style={{ backgroundColor: "#dc3545" }} className="col-md-3 btn btn-danger" onClick={this.handleDelete} ><i className="fas fa-trash-alt"></i> </Button>
                    </div>
                </div>
                <div className="row">
                    <Link to="/reports" className="btn btn-info" >Back to list</Link>
                </div>
            </div>
        );
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
                <h1 className="center mb-4 pb-4"></h1>
                {contents}
            </div>
        );
    }
}
