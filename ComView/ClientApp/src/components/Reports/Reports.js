import React, { Component } from 'react';
import { Cookies } from 'react-cookie';
import { Spinner } from 'reactstrap';
import { ModalDays } from './ModalDays';
import { Link } from 'react-router-dom';
export class Reports extends Component {
    static displayName = Reports.name;

    constructor(props) {
        super(props);

        this.state = { reports: [], loading: true };
    }

    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        if (typeof jwt !== "undefined") {
            this.populateReportsData(jwt);
        }
    }

    renderReportsTable(days, show) {
        return (
            <div className="container mb-4 pb-4">
                <div className="row">
                    <div className="col-11"></div>
                    <Link to="/reports/create" className="add-button col-auto"><i className="fas fa-plus"></i> <span></span></Link>
                </div>
                <table className='table table-striped table-hover' aria-labelledby="tabelLabel">
                    <thead style={{ backgroundColor: "#9D564E", color: "white" }}>
                        <tr>
                            <th>Date</th>
                            <th>Type</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>IsExportable</th>
                            <th>Days</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.reports.map(report =>
                            <tr key={report.id}>
                                <td>{report.date.split('T')[0]}</td>
                                <td>{report.type}</td>
                                <td>{report.title}</td>
                                <td>{report.description}</td>
                                <td>{report.isExportable}</td>
                                <td><ModalDays report={report} /></td>
                                <td><Link to={"/reports/" + report.id} ><i style={{ fontSize: "20px" }} className="fas fa-info-circle"></i></Link></td>
                            </tr>
                        )}
                    </tbody>
                </table>
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
            : this.renderReportsTable(this.state.reports, this.state.show);
        return (
            <div>
                <h1 id="tabelLabel">Reports</h1>
                {contents}
            </div>
        );
    }
    async populateReportsData(jwt) {
        const response = await fetch('https://localhost:6001/api/reports', {
            headers: {
                "Authorization": "bearer " + jwt
            },
            redirect: "follow"
        });
        if (response.status !== 200) {
            window.location.replace("/login");
        }
        const data = await response.json();
        this.setState({ reports: data, loading: false });
    }
}
