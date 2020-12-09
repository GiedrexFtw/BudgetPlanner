import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/LayoutComponents/Layout';
import { Home } from './components/Home';
import { Products } from './components/Products/Products';
import { Days } from './components/Days/Days';
import { Reports } from './components/Reports/Reports';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Categories } from './components/Categories/Categories';

import { NotFound } from './components/NotFound';
import { GuardedRoute } from './GuardedRoute';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Switch>
                <Route exact path='/' component={Home} />
                <GuardedRoute path='/products' component={Products} />
                <GuardedRoute path='/categories' component={Categories} />
                <GuardedRoute path='/days' component={Days} />
                <GuardedRoute path='/reports' component={Reports} />
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
