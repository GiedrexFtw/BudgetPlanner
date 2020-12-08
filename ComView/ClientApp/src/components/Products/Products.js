import React, { Component } from 'react';
import { Cookies } from 'react-cookie';
export class Products extends Component {
  static displayName = Products.name;

  constructor(props) {
    super(props);
    this.state = { products: [], loading: true };
  }

    componentDidMount() {
        let cookie = new Cookies();
        let jwt = cookie.get("accesss_token");
        if (typeof jwt !== undefined) {

        }
        else {
            this.populateProductData();
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

  async populateProductData() {
    const response = await fetch('https://localhost:6001/api/products');
      const data = await response.json();
    this.setState({ products: data, loading: false });
  }
}
