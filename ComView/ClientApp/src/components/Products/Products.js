import React, { Component } from 'react';
import { Cookies } from 'react-cookie';
import { Spinner } from 'reactstrap';
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
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Description</th>
            <th>Amount</th>
          </tr>
        </thead>
        <tbody>
          {products.map(product =>
            <tr key={product.id}>
              <td>{product.title}</td>
              <td>{product.description}</td>
              <td>{product.amount}</td>
            </tr>
          )}
        </tbody>
      </table>
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
