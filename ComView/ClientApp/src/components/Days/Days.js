import React, { Component } from 'react';
import { Cookies } from 'react-cookie';
import { Spinner } from 'reactstrap';
import { ModalProducts } from './ModalProducts';
import { Link } from 'react-router-dom';
export class Days extends Component {
    static displayName = Days.name;

    constructor(props) {
        super(props);

        this.state = { days: [], loading: true };
    }

    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        if (typeof jwt !== "undefined") {
            this.populateDaysData(jwt);
        }
    }
    calculateTotalSpent(day) {
        let sum = 0;
        console.log(day)
        for (var i = 0; i < day.products.length; i++) {
            console.log(day.products[i])
            sum += day.products[i].amount;
        }

        return sum;
    }
    
     renderDaysTable(days, show) {
         return (
             <div className = "container">
             <div className="row">
                  <div className="col-11"></div>
                  <Link to="/days/create" className="add-button col-auto"><i className="fas fa-plus"></i> <span></span></Link>
              </div>
            <table className='table table-striped table-hover' aria-labelledby="tabelLabel">
                <thead style={{ backgroundColor: "#9D564E", color: "white" }}>
                    <tr>
                        <th>Date</th>
                        <th>Description</th>
                        <th>Products</th>
                             <th>Total spent (€)</th>
                             <th></th>
                    </tr>
                </thead>
                <tbody>
                    {days.map(day =>
                        <tr key={day.id}>
                            <td>{day.date.split('T')[0]}</td>
                            <td>{day.description}</td>
                            <td><ModalProducts day={day} /></td>
                            <td>{this.calculateTotalSpent(day)}</td>
                            <td><Link to={"/days/" + day.id} ><i style={{ fontSize: "20px" }} className="fas fa-info-circle"></i></Link></td>
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
            : this.renderDaysTable(this.state.days, this.state.show);
        return (
            <div>
                <h1 id="tabelLabel">Days</h1>
                {contents}
            </div>
        );
    }
    async populateDaysData(jwt) {
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
        this.setState({ days: data, loading: false });
    }
}
