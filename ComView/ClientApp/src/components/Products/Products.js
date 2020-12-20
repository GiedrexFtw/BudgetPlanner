import React, { Component } from 'react';
import { Cookies } from 'react-cookie';
import { Spinner } from 'reactstrap';
import { Link } from 'react-router-dom';
import { Redirect } from 'react-router';

export class Products extends Component {
    static displayName = Products.name;

  constructor(props) {
      super(props);
      
    this.state = { products: [], loading: true };
  }

    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("access_token");
        if (typeof jwt !== "undefined") {
            this.populateProductData(jwt);
        }
  }

    static renderProductsTable(products) {
      return (
          <div className="container">
              <div className="row">
                  <div className="col-11"></div>
                  <Link to="/products/create" className="add-button col-auto"><i className="fas fa-plus"></i> <span></span></Link>
              </div>
              
      <table className='table table-striped table-hover mb-4 pb-4 border-bottom border-secondary' aria-labelledby="tabelLabel">
                  <thead style={{ backgroundColor:"#9D564E", color:"white"}}>
                      <tr>
            <th>Category</th>
            <th>Title</th>
            <th>Description</th>
                          <th>Cost, Eur</th>
                          <th>Day</th>
                          <th></th>
          </tr>
        </thead>
        <tbody>
          {products.map(product =>
              <tr key={product.id}>
                  <td>{product.categoryName }</td>
              <td>{product.title}</td>
              <td>{product.description}</td>
                  <td>{product.amount}</td>
                  <td> {product.dayDate.split('T')[0]}</td>
                  <td><Link to={"/products/" + product.id} ><i style={{fontSize:"20px"}} className="fas fa-info-circle"></i></Link></td>
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
            : Products.renderProductsTable(this.state.products);
        return (
            <div>
                <h1 id="tabelLabel" >Products</h1>
                {contents}
            </div>
        );
    }
  async populateProductData(jwt) {
      const response = await fetch('https://localhost:6001/api/products', {
          headers: {
              "Authorization": "bearer " + jwt
          },
          redirect: "follow"
      });
      if (response.status !== 200) {
          window.location.replace("/login");
      }
      const data = await response.json();
      this.setState({ products: data, loading: false });
  }
}
