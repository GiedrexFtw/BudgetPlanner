import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
       
          <div className="container" > 
              <div className="row"> 
                  <div className="col-12 mb-2">
                      <h1 style={{ textAlign: "center", color: "black" }}>Welcome to Comview!</h1>
                      <img src="https://i.imgflip.com/36capl.jpg" className="center"/>
                  </div>
              </div>
              
              <div className="row">
                  <div className="col-8-md mr-2">
                      <h3> What is Comview?</h3>
                      <p>Comview is a budget planner app, which allows you to track your expenses and make changes!</p>
                      <img src="https://s3-ap-south-1.amazonaws.com/blogmindler/bloglive/wp-content/uploads/2016/07/06131941/giphyeco.gif" className="center" />
                  </div>
                  <div className="col-4-md">
                      <h2> Comview allows you to:</h2>
                      <ul>
                          <li>Add, modify and change your expenses</li>
                          <li>Track each expense by category</li>
                          <li>Check your expenses in graphs</li>
                      </ul>
                  </div>
              </div>
        
              <p>But first, to track your expenses, please <Link tag={Link} className="text-danger border-bottom border-success font-weight-bold" to="/fetch-data">Login</Link>.</p>
      </div>
    );
  }
}
