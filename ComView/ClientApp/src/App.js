import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/LayoutComponents/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Categories } from './components/Categories/Categories';
import { NotFound } from './components/NotFound';
import { GuardedRoute } from './GuardedRoute';
import './custom.css';

import { Products } from './components/Products/Products';
import { CreateProduct } from './components/Products/CreateProduct';
import { DetailsProduct } from './components/Products/DetailsProduct';
import { EditProduct } from './components/Products/EditProduct';

import { Days } from './components/Days/Days';
import { CreateDay } from './components/Days/CreateDay';
import { DetailsDay } from './components/Days/DetailsDay';
import { EditDay } from './components/Days/EditDay';

import { Reports } from './components/Reports/Reports';
import { CreateReport } from './components/Reports/CreateReport';
import { DetailsReport } from './components/Reports/DetailsReport';
import { EditReport } from './components/Reports/EditReport';
import { BrowserRouter } from 'react-router-dom';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Switch>
                <Route exact path='/' component={Home} />


                <GuardedRoute exact path='/products' component={Products} />
                <GuardedRoute path='/products/create' component={CreateProduct} />
                <GuardedRoute exact path='/products/:id' component={DetailsProduct} />
                <GuardedRoute exact path='/products/:id/edit' component={EditProduct} />


                <GuardedRoute exact path='/days' component={Days} />
                <GuardedRoute path='/days/create' component={CreateDay} />
                <GuardedRoute exact path='/days/:id' component={DetailsDay} />
                <GuardedRoute exact path='/days/:id/edit' component={EditDay} />
                <GuardedRoute exact path='/reports' component={Reports} />
                <GuardedRoute path='/reports/create' component={CreateReport} />
                <GuardedRoute path='/reports/:id' component={DetailsReport} />
                <GuardedRoute path='/reports/:id/edit' component={EditReport} />
                <GuardedRoute path='/categories' component={Categories} />
                <Route path='/login' component={Login} />
                <Route path='/register' component={Register} />
                <Route>
                    <NotFound />
                </Route>
                </Switch>
      </Layout>
    );
  }
}
